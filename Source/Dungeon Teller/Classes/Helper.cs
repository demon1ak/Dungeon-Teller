using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Dungeon_Teller.Classes
{
	class Helper
	{
		public static Bitmap bmpTank = Properties.Resources.role_tank_32x32;
		public static Bitmap bmpHeal = Properties.Resources.role_heal_32x32;
		public static Bitmap bmpDps = Properties.Resources.role_dps_32x32;

        public static string dname = "";
		public static Bitmap ConvertToGrayScale(Bitmap original)
		{
			//create a blank bitmap the same size as original
			Bitmap newBitmap = new Bitmap(original.Width, original.Height);

			//get a graphics object from the new image
			Graphics g = Graphics.FromImage(newBitmap);

			//create the grayscale ColorMatrix
			ColorMatrix colorMatrix = new ColorMatrix(
			   new float[][] 
              {
                 new float[] {.3f, .3f, .3f, 0, 0},
                 new float[] {.59f, .59f, .59f, 0, 0},
                 new float[] {.11f, .11f, .11f, 0, 0},
                 new float[] {0, 0, 0, 1, 0},
                 new float[] {0, 0, 0, 0, 1}
              });

			//create some image attributes
			ImageAttributes attributes = new ImageAttributes();

			//set the color matrix attribute
			attributes.SetColorMatrix(colorMatrix);

			//draw the original image on the new image
			//using the grayscale color matrix
			g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
			   0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

			//dispose the Graphics object
			g.Dispose();
			return newBitmap;
		}

		public static string getFormatedTimeString(int seconds)
		{
			double minutes = seconds / 60;
			int secs = seconds % 60;
			int mins = (int)Math.Floor(minutes);

			string FormatedTimeString = String.Format("{0} mins {1} secs", mins, secs);

			return FormatedTimeString;
		}

		public static string excerptString(String str)
		{
			if (str.Length > 30)
				str = str.Substring(0, 27) + "...";

			return str;
		}

		public static void setNotQueued(DTModule module)
		{
			module.lbl_Status.Text = "not queued";
			module.lbl_Status.ForeColor = System.Drawing.Color.Red;
			module.lbl_Wait.Text = "n/a";
			module.lbl_QueueTime.Text = "n/a";

			if (module.lbl_Tank != null)
			{
				module.lbl_Tank.Text = "n/a";
				module.lbl_Healer.Text = "n/a";
				module.lbl_Dps.Text = "n/a";
				module.pic_Tank.Image = Helper.ConvertToGrayScale(bmpTank);
				module.pic_Heal.Image = Helper.ConvertToGrayScale(bmpHeal);
				module.pic_Dps.Image = Helper.ConvertToGrayScale(bmpDps);
			}
		}

		public static void setReady(DTModule module, string name)
		{
			module.lbl_Status.Text = String.Format("{0} (ready)", excerptString(name));

			module.lbl_Status.ForeColor = System.Drawing.Color.Green;
			module.lbl_Wait.Text = "n/a";
			module.lbl_QueueTime.Text = "n/a";

			if (module.lbl_Tank != null)
			{
				module.lbl_Tank.Text = "full";
				module.lbl_Healer.Text = "full";
				module.lbl_Dps.Text = "full";
				module.pic_Tank.Image = bmpTank;
				module.pic_Heal.Image = bmpHeal;
				module.pic_Dps.Image = bmpDps;
			}
		}

		public static void setQueued(Label lbl)
		{
			lbl.Text = "queued";
			lbl.ForeColor = System.Drawing.Color.Blue;
		}

		public static void BgRefresh(DTModule module, QueueStats.BGDataStruct queue)
		{
			int estimatedWait = queue.estimatedWait / 1000;
			int queuedTime = (System.Environment.TickCount - queue.timeWaited) / 1000;
            string bname =queue.battlefieldName;
            //try
            //{
            //    bname = Forms.ProcessSelector.BattlefieldIDs[queue.battlefieldID];
            //}
            //catch (Exception ex)
            //{
            //    bname = "Couldn't Get Dungeon Name";
            //}
			module.lbl_Status.Text = String.Format("{0} (queued)", bname);

			if (estimatedWait != 0)
				module.lbl_Wait.Text = Helper.getFormatedTimeString(estimatedWait);
			else
				module.lbl_Wait.Text = "n/a";

			module.lbl_QueueTime.Text = Helper.getFormatedTimeString(queuedTime);
		}
		public static void LfgRefresh(DTModule module, QueueStats.LFGDataStruct queue, int typetest)
		{
            int totaltanks = 1;
            int totaldps = 3;
            int totalheals = 1;
            try
            {
                dname = Forms.ProcessSelector.DungeonIDs[queue.LfgDungeonsId];
            }
            catch (Exception ex)
            {
                dname = "Couldn't Get Dungeon Name";
            }
            if (typetest == 2)
            {
                totaltanks = 2;
                totaldps = 17;
                totalheals = 6;
            }
			var LfgDungeon = QueueStats.LfgDungeons[queue.LfgDungeonsId];
			module.lbl_Status.Text =  String.Format("{0} (queued)", excerptString(dname));

			if (queue.myWait != -1)
				module.lbl_Wait.Text = Helper.getFormatedTimeString(queue.myWait);
			else
				module.lbl_Wait.Text = "n/a";

			int queuedTime = (System.Environment.TickCount - queue.queuedTime) / 1000;
			module.lbl_QueueTime.Text = Helper.getFormatedTimeString(queuedTime);

			int tank = totaltanks - queue.tankNeeds;
			int healer = totalheals - queue.healerNeeds;
			int dps = totaldps - queue.dpsNeeds;

			module.pic_Tank.Image = (queue.tankNeeds == 0) ? bmpTank : Helper.ConvertToGrayScale(bmpTank);
			module.pic_Heal.Image = (queue.healerNeeds == 0) ? bmpHeal : Helper.ConvertToGrayScale(bmpHeal);
			module.pic_Dps.Image = (queue.dpsNeeds == 0) ? bmpDps : Helper.ConvertToGrayScale(bmpDps);
          // MessageBox.Show(string.Format("Total tanks: {0}, Total heals: {1}, Total dps: {2}", queue.tankNeeds, totalheals, totaldps));
			module.lbl_Tank.Text = tank + " / " + totaltanks;
			module.lbl_Healer.Text = healer + " / " + totalheals;
			module.lbl_Dps.Text = dps + " / " + totaldps;
		}
	}
}
