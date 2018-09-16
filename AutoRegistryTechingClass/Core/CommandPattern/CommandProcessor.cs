using System;
using Microsoft.Extensions.DependencyInjection;
using AutoRegistryTechingClass.Core.CommandPattern.Internal;
using System.Reflection;
using Microsoft.Practices.ServiceLocation;

namespace AutoRegistryTechingClass.Core.CommandPattern
{
    public class CommandProcessor : ICommandProcessor
    {
        public CommandProcessor()
        {
        }

        public void Process<TCommand>(TCommand command)
        {
            Type handlerType = typeof(IHandler<>).MakeGenericType(command.GetType());
            var handlers = ServiceLocator.Current.GetAllInstances(handlerType);
            MethodInfo handleMethod = handlerType.GetMethod("Handle");
            foreach (var handler in handlers)
            {
                handleMethod.Invoke(handler, new object[] { command });
            }
        }
    }
}
