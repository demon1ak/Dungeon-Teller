using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace Dungeon_Teller.Classes
{
	class QueueStats
	{
		static QueueStats()
		{
			LfgDungeons = new DBC<LfgDungeonsRec>(new IntPtr(Offsets.dbc.LfgDungeons.val));
			BattleMasterList = new DBC<BattleMasterListRec>(new IntPtr(Offsets.dbc.BattleMasterList.val));
			Map = new DBC<MapRec>(new IntPtr(Offsets.dbc.Map.val));

		}

		public static DBC<LfgDungeonsRec> LfgDungeons;
		public static DBC<BattleMasterListRec> BattleMasterList;
		public static DBC<MapRec> Map;

		public struct LFGDataStruct
		{
			public int LfgDungeonsId;
			public int myWait;
			public int averageWait;
			public int tankWait;
			public int healerWait;
			public int damageWait;
			public byte tankNeeds;
			public byte healerNeeds;
			public byte dpsNeeds;
			public byte pad0;
			public uint time;
			public int queuedTime;
		}

		public struct BGDataStruct
		{
			public int status;
			public string battlefieldName;
			public int estimatedWait;
			public int timeWaited;
            public int battlefieldID;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct BattleMasterListRec
		{
            [FieldOffset(0)]
            public uint m_id; //Possibly useful
            [FieldOffset(16)]
			public uint _battlefieldName; //Issues

			public string BattlefieldName
			{
				get
				{
					return Memory.Read<string>(_battlefieldName);
				}
			}
            public uint BattlefieldID
            {
                get
                {
                    return Memory.Read<uint>(m_id);
                }
            }
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct MapRec
		{
			[FieldOffset(20)]
			public uint _battlefieldName;

			public string BattlefieldName
			{
				get
				{
					return Memory.Read<string>(_battlefieldName);
				}
			}
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct LfgDungeonsRec
		{
            [FieldOffset(0)]
            public int m_ID;
            [FieldOffset(4)]
            public uint m_name_lang;
			[FieldOffset(72)]
			public int totalTanks;
			[FieldOffset(76)]
			public int totalHealers;
			[FieldOffset(80)]
			public int totalDPS;
			[FieldOffset(100)]
			public int m_category; //1=Dungeon;2=Raid;3=Scenario(need impl)

			public string DungeonName
			{
				get
				{
					return Memory.Read<string>(m_name_lang);
				}
			}
		}

		public static BGDataStruct getBgQeueStats(uint id)
		{
			BGDataStruct bgQueue = new BGDataStruct();
			uint bgQueueCur;
			int i = 1;

			bgQueueCur = Convert.ToUInt32(Memory.Read<uint>(Memory.BaseAddress + Offsets.bgQueueStats.BasePtr.val));

			while (i < id)
			{
				bgQueueCur = Convert.ToUInt32(Memory.Read<uint>(bgQueueCur + Offsets.bgQueueStats.NextPtr.val));
				i++;
			}

			if ((bgQueueCur & 1) == 1 || bgQueueCur == 0)
			{
				bgQueue.status = 0;
				bgQueue.estimatedWait = 0;
				bgQueue.timeWaited = 0;
				bgQueue.battlefieldName = "";
                //bgQueue.TESTVAL = bgQueueCur;
			}
			else
			{
				bgQueue.status = Memory.Read<int>(bgQueueCur + Offsets.bgQueueStats.Status.val);
				bgQueue.estimatedWait = Memory.Read<int>(bgQueueCur + Offsets.bgQueueStats.EstimatedWait.val);
				bgQueue.timeWaited = Memory.Read<int>(bgQueueCur + Offsets.bgQueueStats.TimeWaited.val);

				if (bgQueue.status != 2)
				{
					int bml_id = Memory.Read<int>(bgQueueCur + Offsets.bgQueueStats.BattleMasterListIdPtr.val);
					bgQueue.battlefieldName = BattleMasterList[bml_id].BattlefieldName;
                    bgQueue.battlefieldID = bml_id;
                    try
                    {
                        bgQueue.battlefieldName = Forms.ProcessSelector.BattlefieldIDs[bgQueue.battlefieldID];
                    }
                    catch (Exception ex) {bgQueue.battlefieldName ="N/A"; }
				}
				else
				{
					int map_id = Memory.Read<int>(bgQueueCur + Offsets.bgQueueStats.MapId.val);
					bgQueue.battlefieldName = Map[map_id].BattlefieldName;
                    bgQueue.battlefieldID = map_id;
				}
			}

			return bgQueue;
		}

		public static int getLfgProposal()
		{
			short dungeon_id = Memory.Read<short>(Memory.BaseAddress + Offsets.lfgProposal.val);
			return (int)dungeon_id;
		}

		public static int getBattleFieldMapId()
		{
			uint Cur = Memory.Read<uint>(Memory.BaseAddress + 0xACCAE8);
			int MapId = Memory.Read<int>(Cur + 40);

			return MapId;
		}

		public static LFGDataStruct getLfgQueueStats(uint LE_LFG_CATEGORY)
		{
			LFGDataStruct lfgQueue = new LFGDataStruct();
			uint structSize = (uint)Marshal.SizeOf(lfgQueue);
			lfgQueue = Memory.ReadStruct<LFGDataStruct>(Memory.BaseAddress + Offsets.lfgQueueStats.val + (structSize * (LE_LFG_CATEGORY - 1)));

			return lfgQueue;
		}

	}
}