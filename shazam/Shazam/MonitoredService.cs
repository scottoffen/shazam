using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.ServiceProcess;
using Newtonsoft.Json;

namespace Shazam
{
	internal class MonitoredService
	{
		private ServiceController _service;
		private const int _retry = 5;
		private const int _timeout = 1000;

		public string DisplayName { get; set; }
		public bool AutoStart { get; set; }
		public bool AutoStop { get; set; }

		[JsonIgnore] public bool IsValidService { get; private set; }
		[JsonIgnore] public int  DefaultTimeout { get; set; }
		[JsonIgnore] public int RetryAttempts { get; set; }

		internal MonitoredService()
		{
			DefaultTimeout = _timeout;
			RetryAttempts = _retry;
		}

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

		public ServiceControllerStatus Status
		{
			get
			{
				if (_service == null) throw new Exception("Invalid Service");
				_service.Refresh();
				return _service.Status;
			}
		}

		public bool CanStop
		{
			get
			{
				if (_service == null) throw new Exception("Invalid Service");
				_service.Refresh();
				return _service.CanStop;
			}
		}

		public void Start()
		{
			if (_service == null) throw new Exception("Invalid Service");

			if ((_service.Status.Equals(ServiceControllerStatus.Running)) ||
				(_service.Status.Equals(ServiceControllerStatus.StartPending)))
			{
				return;
			}

			var attempts = 0;
			var wait = true;

			while ((wait) && (attempts < RetryAttempts))
			{
				try
				{
					_service.Start();
					_service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(DefaultTimeout));
					wait = (Status != ServiceControllerStatus.Running);
				}
				catch (System.ServiceProcess.TimeoutException e)
				{
					attempts += 1;
				}
				catch (Exception e)
				{
					throw e;
				}
			}
		}

		public void Stop()
		{
			if (_service == null) throw new Exception("Invalid Service");

			if ((_service.Status.Equals(ServiceControllerStatus.Stopped)) ||
				(_service.Status.Equals(ServiceControllerStatus.StopPending)))
			{
				return;
			}

			var attempts = 0;
			var wait = true;

			while ((wait) && (attempts < RetryAttempts))
			{
				try
				{
					_service.Stop();
					_service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(DefaultTimeout));
					wait = (Status != ServiceControllerStatus.Stopped);
				}
				catch (System.ServiceProcess.TimeoutException e)
				{
					attempts += 1;
				}
				catch (Exception e)
				{
					throw e;
				}
			}
		}

		public void Restart()
		{
			this.Stop();
			this.Start();
		}
	}
}

//TODO: Start and Stop should wait to see if the result is pending before attempting again