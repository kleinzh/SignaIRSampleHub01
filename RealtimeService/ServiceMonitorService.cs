using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.Host.HttpListener;
using Microsoft.Owin.Cors;
using Microsoft.AspNet.SignalR;

namespace RealtimeService
{
	public class ServiceMonitorService : ServiceControl
	{
		private IDisposable app;

		private static string domain = "http://192.168.10.89:3333";

		static ServiceMonitorService()
		{
			domain = ConfigurationManager.AppSettings["Domain"] ?? domain;
			Console.WriteLine("获取配置:" + domain);
		}

		public bool Start(HostControl hostControl)
		{
			Console.WriteLine("事实消息服务运行在:" + domain);

			app = WebApp.Start(domain, builder =>
			{
				builder.UseCors(CorsOptions.AllowAll);
				builder.MapSignalR(new HubConfiguration
				{
					EnableJSONP = true,
					EnableDetailedErrors = true,
					EnableJavaScriptProxies = true
				});
			});
			return true;
		}

		public bool Stop(HostControl hostControl)
		{
			if (app != null)
			{
				app.Dispose();
			}
			return true;
		}
	}
}
