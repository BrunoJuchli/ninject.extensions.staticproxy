namespace Ninject.Extensions.StaticProxy.Factory.Resolution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ninject.Syntax;

    internal class InstanceResolver : IInstanceResolver
    {
        public object Resolve(IResolutionRoot resolutionRoot, IResolutionParameters resolutionParameters)
        {
            Type type = resolutionParameters.TypeToResolve;

            if (type.IsGenericType)
            {
                var genericType = type.GetGenericTypeDefinition();
                if (genericType == typeof(IEnumerable<>) ||
                    genericType == typeof(ICollection<>) ||
                    genericType == typeof(IList<>) ||
                    genericType == typeof(List<>))
                {
                    return this.GetAllAsList(resolutionRoot, type.GetGenericArguments()[0], resolutionParameters);
                }
            }

            if (type.IsArray)
            {
                var argumentType = type.GetElementType();
                return this.GetAllAsArray(resolutionRoot, argumentType, resolutionParameters);
            }

            return resolutionRoot.Get(
                type,
                resolutionParameters.Constraint,
                resolutionParameters.Parameters.ToArray());
        }

        public object GetAllAsList(IResolutionRoot resolutionRoot, Type type, IResolutionParameters resolutionParameters)
        {
            var listType = typeof(List<>).MakeGenericType(type);
            var list = listType.GetConstructor(new Type[0]).Invoke(new object[0]);
            var addMethod = listType.GetMethod("Add");

            IEnumerable<object> values = resolutionRoot.GetAll(type, resolutionParameters.Constraint, resolutionParameters.Parameters.ToArray());

            foreach (var value in values)
            {
                addMethod.Invoke(list, new[] { value });
            }

            return list;
        }

        public object GetAllAsArray(IResolutionRoot resolutionRoot, Type type, IResolutionParameters resolutionParameters)
        {
            var list = this.GetAllAsList(resolutionRoot, type, resolutionParameters);
            return typeof(Enumerable)
                .GetMethod("ToArray")
                .MakeGenericMethod(type)
                .Invoke(null, new[] { list });
        }
    }
}