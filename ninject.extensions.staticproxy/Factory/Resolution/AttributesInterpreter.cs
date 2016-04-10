namespace Ninject.Extensions.StaticProxy.Factory.Resolution
{
    using Ninject.Extensions.StaticProxy.Utilities;
    using Ninject.Parameters;
    using Ninject.Planning.Bindings;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    internal class AttributesInterpreter : IAttributesInterpreter
    {
        public IResolutionParameters Interpret(IInvocation invocation)
        {
            var result = new ResolutionParameters();

            object[] methodAttributes = invocation.Method.GetCustomAttributes(false).ToArray();

            result.TypeToResolve = DetermineReturnType(methodAttributes, invocation.Method);

            IList<Func<IBindingMetadata, bool>> constraints = GetMethodConstraints(methodAttributes).ToList();
            IList<IParameter> resoutionParameters = new List<IParameter>();

            ParameterInfo[] parameters = invocation.Method.GetParameters();
            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterInfo parameter = parameters[i];
                var argumentData = new ArgumentData
                {
                    ArgumentValue = invocation.Arguments[i],
                    ParameterName = parameter.Name,
                    ParameterType = parameter.ParameterType
                };

                object[] parameterAttributes = parameter.GetCustomAttributes(false).ToArray();

                constraints.AddRange(GetParameterConstraints(parameterAttributes, argumentData));

                resoutionParameters.AddRange(GetParameters(parameterAttributes, argumentData));
            }

            result.Constraint = CombineConstraints(constraints);
            result.Parameters = resoutionParameters;

            return result;
        }

        private static Func<IBindingMetadata, bool> CombineConstraints(IEnumerable<Func<IBindingMetadata, bool>> constraints)
        {
            return metadata => constraints.All(x => x(metadata));
        }

        private static Type DetermineReturnType(IEnumerable<object> methodAttributes, MethodInfo method)
        {
            IReturnTypeAttribute[] methodReturnTypeAttributes = methodAttributes.OfType<IReturnTypeAttribute>().ToArray();
            switch (methodReturnTypeAttributes.Length)
            {
                case 0:
                    return method.ReturnType;
                case 1:
                    return methodReturnTypeAttributes[0].ReturnType;
                default:
                    throw CreateExceptionForTooManyReturnTypeAttributes(methodReturnTypeAttributes);
            }
        }

        private static Exception CreateExceptionForTooManyReturnTypeAttributes(IReturnTypeAttribute[] methodReturnTypeAttributes)
        {
            var sb = new StringBuilder();
            sb.AppendFormat(
                CultureInfo.InvariantCulture,
                "There are {0} attributes implementing {1} on the method. But there may be only 0 or 1. The attributes are:",
                methodReturnTypeAttributes.Length,
                typeof(IReturnTypeAttribute).Name)
                .AppendLine();

            foreach (IReturnTypeAttribute methodReturnTypeAttribute in methodReturnTypeAttributes)
            {
                sb.AppendLine()
                    .AppendFormat(CultureInfo.InvariantCulture, " - {0}", methodReturnTypeAttribute.GetType().FullName);
            }

            return new InvalidOperationException(sb.ToString());
        }

        private static IEnumerable<Func<IBindingMetadata, bool>> GetMethodConstraints(IEnumerable<object> methodAttributes)
        {
            return methodAttributes
                .OfType<IConstraintAttribute>()
                .Select(x => x.Constraint);
        }

        private static IEnumerable<Func<IBindingMetadata, bool>> GetParameterConstraints(IEnumerable<object> parameterAttributes, ArgumentData argument)
        {
            return parameterAttributes.OfType<IParameterisedConstraintAttribute>()
                .Select(x => x.CreateConstraint(argument));
        }

        private static IEnumerable<IParameter> GetParameters(IEnumerable<object> parameterAttributes, ArgumentData argument)
        {
            return parameterAttributes.OfType<IParameterAttribute>()
                .SelectMany(x => x.RetrieveParameters(argument));
        }
    }
}