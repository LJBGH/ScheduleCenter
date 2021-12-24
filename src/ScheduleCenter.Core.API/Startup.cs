using ScheduleCenter.Core.API.Startups;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ScheduleCenter.AspNetCore.Filter;
using ScheduleCenter.WebSockets;
using ScheduleCenter.WebSockets.WatsonWebSocket;

namespace ScheduleCenter.Core.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(x=> 
            {
                x.Filters.Add<AuditActionFilter>(); //�����־������
                x.Filters.Add<PermissionAuthorizationFilter>(); //��Ȩ������
            });

            //������չģ��ע��
            services.AddCommonService(Configuration);

            //WatsonWebSocket����
            //WatsonWebSocketHelper.StartWatsonWebsocket();

        }

        //Autofacģ��ע��
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //�����ע��
            builder.ServicesInject();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //�����������
            app.UseCommonExtension();


            app.UseRouting();

            //��Ȩ��֤�м����������·��֮�󣬲�Ȼ�ᱨ��
            app.UseAuthentication(); //��֤
            app.UseAuthorization(); //��Ȩ

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
