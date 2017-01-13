using System;
using Topshelf;

namespace RealtimeService
{
	class Program
	{
		static void Main(string[] args)
		{
			HostFactory.Run(s => {
				s.Service<ServiceMonitorService>();
				s.SetDisplayName("实时消息服务");
				s.StartAutomatically();
			});

			Console.ReadKey();
		}
	}
}
