using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RealtimeService
{
	/// <summary>
	/// 服务监控器
	/// </summary>
	public  class ServiceMonitorHub : Hub
	{
		static ServiceMonitorHub()
		{
			new Thread(new ThreadStart(() =>
			{
				while (true)
				{
					GlobalHost.ConnectionManager.GetHubContext<ServiceMonitorHub>().Clients.All.sendMessage(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "Kelin zhang");
					//休眠3秒，实现每秒推送服务运行状态
					System.Threading.Thread.Sleep(3000);
				}
			})).Start();
		}
	}
}
