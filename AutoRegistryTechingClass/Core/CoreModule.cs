using Autofac;
using AutoRegistryTechingClass.Core.CommandPattern;
using AutoRegistryTechingClass.Core.CommandPattern.Internal;
using AutoRegistryTechingClass.Core.Event;

namespace AutoRegistryTechingClass.Core
{
    public class CoreModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CommandProcessor>().As<ICommandProcessor>().SingleInstance();
            builder.RegisterType<EventPublisher>().As<IEventPublisher>().SingleInstance();

            base.Load(builder);
        }
    }
}
