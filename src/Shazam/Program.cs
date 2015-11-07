using System;
using System.Threading;
using System.Windows.Forms;
using Shazam.Forms;

namespace Shazam
{
	static class Program
	{
		// If you use this code in a different project, make sure to generate a new guid
		private static Mutex mutex = new Mutex(true, "{BF7771CF-25E1-40C5-89B3-4DE5E255F66D}");

		[STAThread]
		static void Main()
		{
			if (mutex.WaitOne(TimeSpan.Zero, true))
			{
				try
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new ShazamTray());
				}
				finally
				{
					mutex.ReleaseMutex();
				}
			}
		}
	}
}