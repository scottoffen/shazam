using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace Shazam
{
	class Program
	{
		static void Main(string[] args)
		{
			var service = new MonitoredService() { AutoStart = true, AutoStop = false, DisplayName = "MySQL Server", ServiceName = "MySQL56" };
			//var service = new MonitoredService() { AutoStart = true, AutoStop = false, DisplayName = "Adobe Flash Player Update Service", ServiceName = "AdobeFlashPlayerUpdateSvc" };

			if (service.IsValidService)
			{
				Console.WriteLine(service.Status);
				service.Start();
				Console.WriteLine(service.Status);

				while (!service.CanStop)
				{
					Console.Write(service.Status.ToString() + " : can't stop");
					System.Threading.Thread.Sleep(1000);
					Console.WriteLine(": trying again.");
					service.Start();
				}

				service.Stop();
				Console.WriteLine(service.Status);
			}
			else
			{
				Console.WriteLine("Invalid Service");
			}

			Console.ReadLine();
		}
	}
}
