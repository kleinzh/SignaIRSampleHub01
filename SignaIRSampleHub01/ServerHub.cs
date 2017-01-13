using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;

namespace SignaIRSampleHub01
{
	public class ServerHub : Hub
	{

		static ServerHub()
		{
			new Thread(new ThreadStart(() =>
			{
				while (true)
				{
					//var hubContext = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
					//hubContext.Clients.All.sendMessage("Your application description page.");

					GlobalHost.ConnectionManager.GetHubContext<ServerHub>().Clients.All.sendMessage(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "Kelin zhang");
					//休眠一秒，实现每秒推送服务运行状态
					System.Threading.Thread.Sleep(3000);
				}
			})).Start();
		}


		/// <summary>
		/// 调用所有客户端的sendMessage方法
		/// </summary>
		/// <param name="message"></param>
		public void SendMsg(string message)
		{
			dynamic test = Clients;
			Clients.All.sendMessage(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message);
		}


		public void Hello()
		{
			Clients.All.hello();
		}
	}
}