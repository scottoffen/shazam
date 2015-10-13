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

		private string _serviceName;

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

		internal MonitoredService(ServiceController service) : base()
		{
			_service = service;
			DisplayName = _service.DisplayName;
			IsValidService = true;
		}

		public string ServiceName
		{
			get
			{
				return (_service == null) ? _serviceName :_service.ServiceName;
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
					_serviceName = value;
					_service = null;
				}
			}
		}

		[JsonIgnore]
		public ServiceControllerStatus Status
		{
			get
			{
				if (IsValidService)
				{
					_service.Refresh();
					return _service.Status;					
				}
				else
				{
					return ServiceControllerStatus.Stopped;
				}
			}
		}

		[JsonIgnore]
		public bool CanStop
		{
			get
			{
				if (IsValidService)
				{
					_service.Refresh();
					return _service.CanStop;
				}
				else
				{
					return false;
				}
			}
		}

		public void Start()
		{
			if (!IsValidService) return;
			if (_service.Status.Equals(ServiceControllerStatus.Running)) return;
			
			var attempts = 0;
			var wait = true;

			while ((wait) && (attempts < RetryAttempts))
			{
				try
				{
					if (!_service.Status.Equals(ServiceControllerStatus.StartPending)) _service.Start();
					_service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(DefaultTimeout));
					wait = (Status != ServiceControllerStatus.Running);
					attempts += 1;
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
			if (!IsValidService) return;
			if (_service.Status.Equals(ServiceControllerStatus.Stopped)) return;

			var attempts = 0;
			var wait = _service.CanStop;

			while ((wait) && (attempts < RetryAttempts))
			{
				try
				{
					if (!_service.Status.Equals(ServiceControllerStatus.StopPending)) _service.Stop();
					_service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(DefaultTimeout));
					wait = (Status != ServiceControllerStatus.Stopped);
					attempts += 1;
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