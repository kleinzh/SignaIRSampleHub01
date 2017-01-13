using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(SignaIRSampleHub01.Startup))]
namespace SignaIRSampleHub01
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			//配置集线器
		//	app.MapSignalR();
		}
	}
}