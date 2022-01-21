using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace ScheduleCenter.Shared
{
    public static class DependencyInjectionModel
    {
        public static void AddDependencyInjection (this IServiceCollection services) 
        {
            var baseTypes = new Type[] { typeof(IScopedDependency), typeof(ISingletonDependency), typeof(ITransientDependency) };
            var types = AssemblyHelper.FindAll().Distinct();


            //获取所有实现自动注入接口和配置自动注入特性的程序
            types = types.Where(type => type.IsClass && !type.IsAbstract && (baseTypes.Any(x => x.IsAssignableFrom(type))));

            foreach (var type in types)
            {
                //获取接口注入
                var typeInfo = type.GetTypeInfo();
                var serviceTypes = typeInfo.ImplementedInterfaces
                    .Where(x => x.HasMatchingGenericArity(typeInfo)
                    && !x.HasAttribute<IgnoreDependencyAttribute>()
                    && x != typeof(IDisposable)
                    ).Select(t => t.GetRegistrationType(typeInfo));

                var lifetime = GetServiceLifetime(type);

                if (lifetime == null)
                {
                    break;
                }

                //如果没有继承接口，则注入自己
                if (serviceTypes.Count() == 0)
                {
                    services.Add(new ServiceDescriptor(type, type, lifetime.Value));
                    continue;
                }
                //如果有继承的接口，则循环注入
                foreach (var serviceType in serviceTypes.Where(x => !x.HasAttribute<IgnoreDependencyAttribute>()))
                {
                    services.Add(new ServiceDescriptor(serviceType, type, lifetime.Value));
                }
            }
        }

        /// <summary>
        /// 获取注入生命周期类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static ServiceLifetime? GetServiceLifetime(Type type)
        {
            if (typeof(IScopedDependency).IsAssignableFrom(type))
            {
                return ServiceLifetime.Scoped;
            }

            if (typeof(ITransientDependency).IsAssignableFrom(type))
            {
                return ServiceLifetime.Transient;
            }

            if (typeof(ISingletonDependency).IsAssignableFrom(type))
            {
                return ServiceLifetime.Singleton;
            }
            return null;
        }
    }
}
