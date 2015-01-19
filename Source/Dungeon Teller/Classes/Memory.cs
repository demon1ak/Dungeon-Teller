using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Dungeon_Teller.Classes
{
	class Memory
	{
		private const int DEFAULT_MEMORY_SIZE = 0x1000;
        public const byte ASCII_CHAR_LENGTH = 1;
		#region Imports
		[DllImport("kernel32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool ReadProcessMemory(IntPtr hProcess, uint lpBaseAddress, [Out] byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

		[DllImport("kernel32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool WriteProcessMemory(IntPtr hProcess, uint lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		[DllImport("kernel32.dll"), SuppressUnmanagedCodeSecurity]
		internal static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true), SuppressUnmanagedCodeSecurity]
		internal static extern bool CloseHandle(IntPtr hHandle);

		[DllImport("kernel32", EntryPoint = "VirtualAllocEx")]
		public static extern uint VirtualAllocEx(IntPtr hProcess, uint dwAddress, int nSize, uint dwAllocationType, uint dwProtect);

		[DllImport("kernel32", EntryPoint = "VirtualFreeEx")]
		public static extern bool VirtualFreeEx(IntPtr hProcess, uint dwAddress, int nSize, uint dwFreeType);
		#endregion

		#region Properties
		private static Process ProcessObject
		{
			get;
			set;
		}

		public static int ProcessId
		{
			get { return ProcessObject.Id; }
		}

		public static IntPtr WindowHandle
		{
			get { return ProcessObject.MainWindowHandle; }
		}

		public static ProcessModule MainModule
		{
			get { return ProcessObject.MainModule; }
		}

		public static uint BaseAddress
		{
			get { return (uint)MainModule.BaseAddress; }
		}

		public static IntPtr ProcessHandle
		{
			get;
			private set;
		}
		#endregion

		#region ProcessHandle
		public static bool OpenProcess(int processId)
		{
			Process.EnterDebugMode();
			ProcessObject = Process.GetProcessById(processId);
			ProcessHandle = OpenProcess(0x000F0000 | 0x00100000 | 0xFFF, false, processId);
			if (ProcessHandle != IntPtr.Zero)
				return true;
			return false;
		}

		public static void CloseProcess()
		{
			CloseHandle(ProcessHandle);
			Process.LeaveDebugMode();
		}
		#endregion

		#region WriteBytes
		public static int WriteBytes(uint address, byte[] val)
		{
			int written;
			if (WriteProcessMemory(ProcessHandle, address, val, (uint)val.Length, out written))
			{
				return written;
			}

			throw new Exception(string.Format("Could not write the specified bytes! {0:X8} [{1}]", address, Marshal.GetLastWin32Error()));
		}

		public static void Write<T>(uint address, T value)
		{
			if (value is string)
			{
				WriteBytes(address, Encoding.ASCII.GetBytes(value as string));
			}
			else
			{
				int numBytes = Marshal.SizeOf(value);
				unsafe
				{
					byte* bytes = stackalloc byte[numBytes];
					Marshal.StructureToPtr(value, (IntPtr)bytes, true);
					byte[] writeBytes = new byte[numBytes];
					Marshal.Copy((IntPtr)bytes, writeBytes, 0, numBytes);
					WriteBytes(address, writeBytes);
				}
			}
		}
		#endregion

		#region ReadBytes
		public static byte[] ReadBytes(uint address, int count)
		{
			var ret = new byte[count];
			int numRead;
			if (ReadProcessMemory(ProcessHandle, address, ret, count, out numRead) && numRead == count)
			{
				return ret;
			}
			return null;
		}

		private static T ReadInternal<T>(uint address)
		{
			object ret;
			try
			{
				if (typeof(T) == typeof(string))
				{
					List<byte> byte_list = new List<byte>();
					uint offset = 0;

					while (true)
					{
						byte byte_step = Memory.Read<byte>(address + offset);

						if (byte_step != 0)
							byte_list.Add(byte_step);
						else
							break;

						offset++;
					}

					byte[] bytes = byte_list.ToArray();

					ret = Encoding.UTF8.GetString(bytes);

					return (T)ret;
				}

				int numBytes = Marshal.SizeOf(typeof(T));
				if (typeof(T) == typeof(IntPtr))
				{
					ret = (IntPtr)BitConverter.ToInt64(ReadBytes(address, numBytes), 0);
					return (T)ret;
				}

				else
				{
					switch (Type.GetTypeCode(typeof(T)))
					{
						case TypeCode.Boolean:
							ret = ReadBytes(address, 1)[0] != 0;
							break;
						case TypeCode.Char:
							ret = (char)ReadBytes(address, 1)[0];
							break;
						case TypeCode.SByte:
							ret = (sbyte)ReadBytes(address, numBytes)[0];
							break;
						case TypeCode.Byte:
							ret = ReadBytes(address, numBytes)[0];
							break;
						case TypeCode.Int16:
							ret = BitConverter.ToInt16(ReadBytes(address, numBytes), 0);
							break;
						case TypeCode.UInt16:
							ret = BitConverter.ToUInt16(ReadBytes(address, numBytes), 0);
							break;
						case TypeCode.Int32:
							ret = BitConverter.ToInt32(ReadBytes(address, numBytes), 0);
							break;
						case TypeCode.UInt32:
							ret = BitConverter.ToUInt32(ReadBytes(address, numBytes), 0);
							break;
						case TypeCode.Int64:
							ret = BitConverter.ToInt64(ReadBytes(address, numBytes), 0);
							break;
						case TypeCode.UInt64:
							ret = BitConverter.ToUInt64(ReadBytes(address, numBytes), 0);
							break;
						case TypeCode.Single:
							ret = BitConverter.ToSingle(ReadBytes(address, numBytes), 0);
							break;
						case TypeCode.Double:
							ret = BitConverter.ToDouble(ReadBytes(address, numBytes), 0);
							break;
						default:
							IntPtr dataStore = Marshal.AllocHGlobal(numBytes);
							byte[] data = ReadBytes(address, numBytes);
							Marshal.Copy(data, 0, dataStore, numBytes);
							ret = Marshal.PtrToStructure(dataStore, typeof(T));
							Marshal.FreeHGlobal(dataStore);
							break;
					}
				}
				return (T)ret;
			}
			catch { return default(T); }
		}

		public static T Read<T>(params IntPtr[] addresses)
		{
			uint[] addressesUInt = new uint[addresses.Length];
			for (int i = 0; i < addressesUInt.Length; i++) addressesUInt[i] = (uint)addresses[i];

			return Read<T>(addressesUInt);
		}

		public static T Read<T>(params uint[] addresses)
		{
			if (addresses.Length == 0)
			{
				return default(T);
			}
			if (addresses.Length == 1)
			{
				return ReadInternal<T>(addresses[0]);
			}

			uint last = 0;
			for (int i = 0; i < addresses.Length; i++)
			{
				if (i == addresses.Length - 1)
				{
					return ReadInternal<T>(addresses[i] + last);
				}
				last = ReadInternal<uint>(last + addresses[i]);
			}

			return default(T);
		}

		public static T ReadStruct<T>(uint address) where T : struct
		{
			IntPtr localStore = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));
			Marshal.Copy(ReadBytes(address, Marshal.SizeOf(typeof(T))), 0, localStore, Marshal.SizeOf(typeof(T)));
			var ret = (T)Marshal.PtrToStructure(localStore, typeof(T));
			Marshal.FreeHGlobal(localStore);
			return ret;
		}
		#endregion

		#region FindPattern

		public static uint FindPattern(string szPattern, string szMask, params char[] Delimiter)
		{
			return FindPattern(ProcessHandle, (uint)MainModule.BaseAddress, MainModule.ModuleMemorySize, szPattern, szMask, Delimiter);
		}

		public static uint FindPattern(IntPtr hProcess, ProcessModule pMod, string szPattern, string szMask, params char[] Delimiter)
		{
			return FindPattern(hProcess, (uint)pMod.BaseAddress, pMod.ModuleMemorySize, szPattern, szMask, Delimiter);
		}

		public static uint FindPattern(IntPtr hProcess, ProcessModule[] pMods, string szPattern, string szMask, params char[] Delimiter)
		{
			return FindPattern(hProcess, new ProcessModuleCollection(pMods), szPattern, szMask, Delimiter);
		}

		public static uint FindPattern(IntPtr hProcess, ProcessModuleCollection pMods, string szPattern, string szMask, params char[] Delimiter)
		{
			uint dwRet = 0;

			foreach (ProcessModule pMod in pMods)
				if ((dwRet = FindPattern(hProcess, pMod, szPattern, szMask, Delimiter)) != 0)
					break;

			return dwRet;
		}

		public static uint FindPattern(IntPtr hProcess, uint dwStart, int nSize, string szPattern, string szMask, params char[] Delimiter)
		{
			if (Delimiter == null)
				Delimiter = new char[1] { ' ' };

			string[] saPattern = szPattern.Split(Delimiter);
			byte[] bPattern = new byte[saPattern.Length];

			for (int i = 0; i < saPattern.Length; i++)
				bPattern[i] = Convert.ToByte(saPattern[i], 0x10);

			return FindPattern(hProcess, dwStart, nSize, bPattern, szMask);
		}

		public static uint FindPattern(IntPtr hProcess, ProcessModule pMod, byte[] bPattern, string szMask)
		{
			return FindPattern(hProcess, (uint)pMod.BaseAddress, pMod.ModuleMemorySize, bPattern, szMask);
		}

		public static uint FindPattern(IntPtr hProcess, ProcessModule[] pMods, byte[] bPattern, string szMask)
		{
			return FindPattern(hProcess, new ProcessModuleCollection(pMods), bPattern, szMask);
		}

		public static uint FindPattern(IntPtr hProcess, ProcessModuleCollection pMods, byte[] bPattern, string szMask)
		{
			uint dwRet = 0;

			foreach (ProcessModule pMod in pMods)
				if ((dwRet = FindPattern(hProcess, pMod, bPattern, szMask)) != 0)
					break;

			return dwRet;
		}

		public static uint FindPattern(IntPtr hProcess, uint dwStart, int nSize, byte[] bPattern, string szMask)
		{
			if (bPattern == null || bPattern.Length == 0)
				throw new ArgumentNullException("bData");

			if (bPattern.Length != szMask.Length)
				throw new ArgumentException("bData and szMask must be of the same size");

			byte[] bData = ReadBytes(dwStart, nSize);
			if (bData == null)
				throw new Exception("Could not read memory in FindPattern.");

			return (uint)(dwStart + FindPattern(bData, bPattern, szMask));
		}

		public static uint FindPattern(byte[] bData, byte[] bPattern, string szMask)
		{
			if (bData == null || bData.Length == 0)
				throw new ArgumentNullException("bData");

			if (bPattern == null || bPattern.Length == 0)
				throw new ArgumentNullException("bPattern");

			if (szMask == string.Empty)
				throw new ArgumentNullException("szMask");

			if (bPattern.Length != szMask.Length)
				throw new ArgumentException("Pattern and Mask lengths must be the same.");

			int ix, iy;
			bool bFound = false;
			int PatternLength = bPattern.Length;
			int DataLength = bData.Length - PatternLength;

			for (ix = 0; ix < DataLength; ix++)
			{
				bFound = true;
				for (iy = 0; iy < PatternLength; iy++)
				{
					if ((szMask[iy] == 'x' && bPattern[iy] != bData[ix + iy]) ||
						(szMask[iy] == '!' && bPattern[iy] == bData[ix + iy]))
					{
						bFound = false;
						break;
					}
				}

				if (bFound)
					return (uint)ix;
			}

			return 0;
		}

		#endregion

		#region AllocateMemory
		public static uint AllocateMemory(int nSize, uint dwAddress, uint dwAllocationType, uint dwProtect)
		{
			return VirtualAllocEx(ProcessHandle, dwAddress, nSize, dwAllocationType, dwProtect);
		}

		public static uint AllocateMemory(int nSize, uint dwAllocationType, uint dwProtect)
		{
			return AllocateMemory(nSize, 0, dwAllocationType, dwProtect);
		}

		public static uint AllocateMemory(int nSize)
		{
			return AllocateMemory(nSize, MemoryAllocType.MEM_COMMIT, MemoryProtectType.PAGE_EXECUTE_READWRITE);
		}

		public static uint AllocateMemory()
		{
			return AllocateMemory(DEFAULT_MEMORY_SIZE);
		}
		#endregion

		#region FreeMemory
		public static bool FreeMemory(uint dwAddress, int nSize, uint dwFreeType)
		{
			if (dwFreeType == MemoryFreeType.MEM_RELEASE)
				nSize = 0;

			return VirtualFreeEx(ProcessHandle, dwAddress, nSize, dwFreeType);
		}

		public static bool FreeMemory(uint dwAddress)
		{
			return FreeMemory(dwAddress, 0, Memory.MemoryFreeType.MEM_RELEASE);
		}
		#endregion

		#region MemoryAllocType, MemoryProtectType, MemoryFreeType
		public static class MemoryAllocType
		{
			public const uint MEM_COMMIT = 0x00001000;
			public const uint MEM_RESERVE = 0x00002000;
			public const uint MEM_RESET = 0x00080000;
			public const uint MEM_PHYSICAL = 0x00400000;
			public const uint MEM_TOP_DOWN = 0x00100000;
		}

		public static class MemoryProtectType
		{
			public const uint PAGE_EXECUTE = 0x10;
			public const uint PAGE_EXECUTE_READ = 0x20;
			public const uint PAGE_EXECUTE_READWRITE = 0x40;
			public const uint PAGE_EXECUTE_WRITECOPY = 0x80;
			public const uint PAGE_NOACCESS = 0x01;
			public const uint PAGE_READONLY = 0x02;
			public const uint PAGE_READWRITE = 0x04;
			public const uint PAGE_WRITECOPY = 0x08;
			public const uint PAGE_GUARD = 0x100;
			public const uint PAGE_NOCACHE = 0x200;
			public const uint PAGE_WRITECOMBINE = 0x400;
		}

		public static class MemoryFreeType
		{
			public const uint MEM_DECOMMIT = 0x4000;
			public const uint MEM_RELEASE = 0x8000;
		}
		#endregion


        public static string ReadAsciiString(uint dwAddress, int nLength)
        {
            IntPtr lpBuffer = IntPtr.Zero;
            int iBytesRead, nSize;
            string sRet;

            try
            {
                nSize = nLength * ASCII_CHAR_LENGTH;
                lpBuffer = Marshal.AllocHGlobal(nSize + ASCII_CHAR_LENGTH);
                Marshal.WriteByte(lpBuffer, nLength, 0);

                iBytesRead = ReadRawMemory(ProcessHandle, dwAddress, lpBuffer, nSize);
                if (iBytesRead != nSize)
                    throw new Exception();

                sRet = Marshal.PtrToStringAnsi(lpBuffer);
            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (lpBuffer != IntPtr.Zero)
                    Marshal.FreeHGlobal(lpBuffer);
            }

            return sRet;
        }


        /// <summary>
        ///   Reads Memory from an external process into a buffer of allocated Memory in the local process.
        /// </summary>
        /// <param name = "hProcess">Handle to the external process from which Memory will be read.</param>
        /// <param name = "dwAddress">Address in external process from which Memory will be read.</param>
        /// <param name = "lpBuffer">Pointer to a buffer of allocated Memory of at least nSize bytes.</param>
        /// <param name = "nSize">Number of bytes to be read.</param>
        /// <returns>Returns the number of bytes actually read.</returns>
        public static int ReadRawMemory(IntPtr hProcess, uint dwAddress, IntPtr lpBuffer, int nSize)
        {
            try
            {
                int lpBytesRead;
                if (!ReadProcessMemory(hProcess, dwAddress, lpBuffer, nSize, out lpBytesRead))
                    throw new Exception("ReadProcessMemory failed");

                return lpBytesRead;
            }
            catch
            {
                return 0;
            }
        }

        [DllImport("kernel32", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess,
            uint dwAddress,
            IntPtr lpBuffer,
            int nSize,
            out int lpBytesRead);


    }
}
