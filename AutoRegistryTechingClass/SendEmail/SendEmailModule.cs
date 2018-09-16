using Autofac;
using AutoRegistryTechingClass.Core.CommandPattern.Internal;
using AutoRegistryTechingClass.Core.Domain.AutoRegistry;
using AutoRegistryTechingClass.SendEmail.Config;
using AutoRegistryTechingClass.SendEmail.EventHandler;
using AutoRegistryTechingClass.SendEmail.Service;

namespace AutoRegistryTechingClass.SendEmail
{
    public class SendEmailModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SendEmailService>().As<ISendEmailService>().SingleInstance();
            builder.RegisterType<EmailConfigFileReader>().As<IEmailConfigReader>().SingleInstance();
            builder.RegisterType<SentEmailNotifyNewClassAddedEventHandler>().As<IHandler<AddNewClassToDatabaseEvent>>().SingleInstance();

            base.Load(builder);
        }
    }
}
