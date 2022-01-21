using Microsoft.Extensions.DependencyInjection;
using ScheduleCenter.WebSockets.SocketDictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScheduleCenter.WebSockets.WebSockets
{
    public static class WebSocketModule
    {
        public static void AddWebSocket(this IServiceCollection service)
        {

            //WebSocket服务注入
            service.AddSingleton<IWebSocketDictionary, WebSocketDictionary>();
        }
    }
}
