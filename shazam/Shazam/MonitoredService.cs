using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.ServiceProcess;

namespace Shazam
{
	internal class MonitoredService
	{
		private ServiceController _service;
		private const int _defaultTimeoutInMilliseconds = 100;

		public string DisplayName { get; set; }
		public bool AutoStart { get; set; }
		public bool AutoStop { get; set; }
		public bool IsValidService { get; private set; }

		public string ServiceName
		{
			get
			{
				if (_service == null) throw new Exception("Invalid Service");
				return _service.ServiceName;
			}
			set
			{
				try
				{
					_service = new ServiceController(value);
					var s = _service.Status;
					this.IsValidService = true;
				}
				catch
				{
					this.IsValidService = false;
					_service = null;
				}
			}
		}

		public void Start(int timeoutInMilliseconds = _defaultTimeoutInMilliseconds)
		{
			if (_service == null) throw new Exception("Invalid Service");

			if ((_service.Status.Equals(ServiceControllerStatus.Running)) ||
				(_service.Status.Equals(ServiceControllerStatus.StartPending)))
			{
				return;
			}

			try
			{
				var timeout = TimeSpan.FromMilliseconds(timeoutInMilliseconds);
				_service.Start();
				_service.WaitForStatus(ServiceControllerStatus.Running, timeout);
			}
			catch (Exception e)
			{
				//TODO: Better exception handling
				Console.WriteLine(e.Message);
			}
		}

		public ServiceControllerStatus Status
		{
			get
			{
				if (_service == null) throw new Exception("Invalid Service");
				return _service.Status;
			}
		}

		public bool CanStop
		{
			get { return (_service != null) ? _service.CanStop : false; }
		}

		public void Stop(int timeoutInMilliseconds = _defaultTimeoutInMilliseconds)
		{
			if (_service == null) throw new Exception("Invalid Service");

			if ((_service.Status.Equals(ServiceControllerStatus.Stopped)) ||
			    (_service.Status.Equals(ServiceControllerStatus.StopPending)))
			{
				return;
			}

			try
			{
				var timeout = TimeSpan.FromMilliseconds(timeoutInMilliseconds);
				_service.Stop();
				_service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public void Restart(int timeoutInMilliseconds = _defaultTimeoutInMilliseconds)
		{
			this.Stop(timeoutInMilliseconds);
			this.Start(timeoutInMilliseconds);
		}
	}
}
