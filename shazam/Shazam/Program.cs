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
				Console.WriteLine(String.Format("{0} is {1}", service.DisplayName, service.Status));

				if (service.Status.Equals(ServiceControllerStatus.Stopped))
				{
					Console.Write("Starting...");

					while (!service.Status.Equals(ServiceControllerStatus.Running))
					{
						service.Start();
					}

					Console.WriteLine("done.");
				}

				if (service.Status.Equals(ServiceControllerStatus.Running))
				{
					Console.Write("Stopping...");

					while (!service.Status.Equals(ServiceControllerStatus.Stopped))
					{
						service.Stop();
					}

					Console.WriteLine("done.");
				}

				Console.WriteLine(String.Format("{0} is {1}", service.DisplayName, service.Status));
			}
			else
			{
				Console.WriteLine("Invalid Service");
			}

			Console.ReadLine();
		}
	}
}
