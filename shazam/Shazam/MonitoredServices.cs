﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Shazam
{
	internal class MonitoredServices
	{
		private static MonitoredServices _instance;
		private List<MonitoredService> _services;
		private readonly string _file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".shazam");

		public static MonitoredServices GetInstance()
		{
			return _instance ?? (_instance = new MonitoredServices());
		}

		private MonitoredServices(string json = null)
		{
			json = json ?? GetJsonString();

			try
			{
				//TODO: Parse each element individually instead of as an entire list
				_services = JsonConvert.DeserializeObject<List<MonitoredService>>(json);
			}
			catch
			{
				_services = new List<MonitoredService>();
			}
			finally
			{
				if (_services == null)
				{
					_services = new List<MonitoredService>();
				}
			}
		}

		private string GetJsonString ()
		{
			var json = "[]";

			if (File.Exists(_file))
			{
				json = File.ReadAllText(_file);
			}
			else
			{
				try
				{
					using (var output = new StreamWriter(_file))
					{
						output.WriteLine(json);
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}

			return json;
		}

		private int IndexOf(MonitoredService service)
		{
			return _services.FindIndex(s => s.ServiceName.Equals(service.ServiceName, StringComparison.CurrentCultureIgnoreCase));
		}

		private int IndexOf(string serviceName)
		{
			return _services.FindIndex(s => s.ServiceName.Equals(serviceName, StringComparison.CurrentCultureIgnoreCase));
		}

		private bool Contains (MonitoredService service)
		{
			return (this.IndexOf(service) > -1);
		}

		public void Add(MonitoredService service)
		{
			if (this.Contains(service))
			{
				this.Remove(service);
			}

			_services.Add(service);
		}

		public void Remove(MonitoredService service)
		{
			var index = this.IndexOf(service);
			_services.RemoveAt(index);
		}

		public MonitoredService Get(string serviceName)
		{
			var idx = this.IndexOf(serviceName);
			return (idx == -1) ? null : _services[idx];
		}

		public List<MonitoredService> List
		{
			get { return new List<MonitoredService>(_services); }
		}

		public void Save()
		{
			using (var output = new StreamWriter(_file))
			{
				output.Write(JsonConvert.SerializeObject(_services, Formatting.Indented));
			}
		}
	}
}