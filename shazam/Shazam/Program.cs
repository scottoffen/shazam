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
			var service = new MonitoredService() { AutoStart = true, AutoStop = false, DisplayName = "MySQL Server", ServiceName = "MySQL55" };
			var servicea = new MonitoredService() { AutoStart = true, AutoStop = false, DisplayName = "MySQL Server", ServiceName = "MySQL56" };
			var serviceb = new MonitoredService(new ServiceController("RavenDB"));

			Console.WriteLine(String.Format("{0} : {1}, {2}", service.DisplayName, service.Status, service.IsValidService));
			Console.WriteLine(String.Format("{0} : {1}, {2}", servicea.DisplayName, servicea.Status, servicea.IsValidService));
			Console.WriteLine(String.Format("{0} : {1}, {2}", serviceb.DisplayName, serviceb.Status, serviceb.IsValidService));

			var services = MonitoredServices.GetInstance();
			services.Add(servicea);
			services.Add(serviceb);

			Console.Write(String.Format("{0} Services", services.Count));

			Console.ReadLine();
		}
	}
}
