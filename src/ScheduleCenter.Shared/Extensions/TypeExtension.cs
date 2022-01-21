using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ScheduleCenter.Shared
{
    public static class TypeExtension
    {
        /// <summary>
        /// 是否具有匹配的泛型度
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static bool HasMatchingGenericArity(this Type interfaceType, TypeInfo typeInfo)
        {
            if (typeInfo.IsGenericType)
            {
                var interfaceTypeInfo = interfaceType.GetTypeInfo();

                if (interfaceTypeInfo.IsGenericType)
                {
                    var argumentCount = interfaceType.GenericTypeArguments.Length;
                    var parameterCount = typeInfo.GenericTypeParameters.Length;

                    return argumentCount == parameterCount;
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取注册类型
        /// </summary>
        /// <param name="interfaceType"></param>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static Type GetRegistrationType(this Type interfaceType, TypeInfo typeInfo)
        {
            if (typeInfo.IsGenericTypeDefinition)
            {
                var interfaceTypeInfo = interfaceType.GetTypeInfo();

                if (interfaceTypeInfo.IsGenericType)
                {
                    return interfaceType.GetGenericTypeDefinition();
                }
            }

            return interfaceType;
        }
    }
}
