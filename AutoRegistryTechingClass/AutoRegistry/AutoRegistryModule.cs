using Autofac;
using AutoRegistryTechingClass.AutoRegistry.Service;
using AutoRegistryTechingClass.AutoRegistry.Service.WebContentProcessStrategy;
using AutoRegistryTechingClass.AutoRegistry.WebCaller;

namespace AutoRegistryTechingClass.AutoRegistry
{
    public class AutoRegistryModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var webClientCaller = new WebClientCaller();
            webClientCaller.AddHtmlHandler(new EncodingUtf8HtmlContentHandler());

            builder.Register(c => webClientCaller).As<IWebCaller>().SingleInstance();
            builder.RegisterType<MinhTamCenterHtmlModelBuilder>().As<IWebContentModelBuilderStrategy>().SingleInstance();
            builder.RegisterType<SendEmailForNewClassStrategy>().As<IDataProcessStrategy>().SingleInstance();
            builder.RegisterType<WebContentProcessor>().As<IWebContentProcessor>().SingleInstance();

            base.Load(builder);
        }
    }
}
