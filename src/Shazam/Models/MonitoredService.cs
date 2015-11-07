using System;
using System.ServiceProcess;
using Newtonsoft.Json;

namespace Shazam.Models
{
	internal class MonitoredService
	{
		private ServiceController _service;
		private const int _retry = 5;
		private const int _timeout = 1000;

		private string _serviceName;

        [JsonProperty(PropertyName = "displayname")]
		public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "autostart")]
		public bool AutoStart { get; set; }

        [JsonProperty(PropertyName = "autostop")]
		public bool AutoStop { get; set; }

		[JsonIgnore]
		public bool IsValidService { get; private set; }

        [JsonProperty(PropertyName = "defaulttimeout")]
		public int DefaultTimeout { get; set; }

        [JsonProperty(PropertyName = "retryattempts")]
		public int RetryAttempts { get; set; }

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

        [JsonProperty(PropertyName = "servicename")]
		public string ServiceName
		{
			get
			{
				return (_service == null) ? _serviceName : _service.ServiceName;
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
			if (ServiceIsPending()) return;

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
				catch (System.ServiceProcess.TimeoutException)
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
			if (ServiceIsPending()) return;

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
				catch (System.ServiceProcess.TimeoutException)
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

		private bool ServiceIsPending()
		{
			var wait = true;
			var attempts = 0;

			ServiceControllerStatus desiredStatus = _service.Status;
			switch (_service.Status)
			{
				case ServiceControllerStatus.ContinuePending:
					desiredStatus = ServiceControllerStatus.Running;
					break;
				case ServiceControllerStatus.PausePending:
					desiredStatus = ServiceControllerStatus.Paused;
					break;
				case ServiceControllerStatus.StartPending:
					desiredStatus = ServiceControllerStatus.Running;
					break;
				case ServiceControllerStatus.StopPending:
					desiredStatus = ServiceControllerStatus.Stopped;
					break;
				default:
					wait = false;
					break;
			}

			while ((wait) && (attempts < RetryAttempts))
			{
				var timeout = TimeSpan.FromMilliseconds(DefaultTimeout);
				attempts += 1;

				try
				{
					_service.WaitForStatus(desiredStatus, timeout);
					wait = (_service.Status != desiredStatus);
				}
				catch (System.ServiceProcess.TimeoutException)
				{
					wait = true;
				}
			}

			return wait;
		}
	}
}