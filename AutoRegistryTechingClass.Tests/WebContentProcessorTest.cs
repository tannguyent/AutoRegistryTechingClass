using AutoRegistryTechingClass.AutoRegistry.Service;
using AutoRegistryTechingClass.AutoRegistry.Service.WebContentProcessStrategy;
using AutoRegistryTechingClass.AutoRegistry.WebCaller;
using AutoRegistryTechingClass.Core.CommandPattern;
using AutoRegistryTechingClass.SendEmail.Config;
using AutoRegistryTechingClass.SendEmail.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoRegistryTechingClass.Tests
{
    [TestClass]
    public class WebContentProcessorTest
    {
        private IWebContentProcessor _webContentProcess;

        [TestInitialize]
        public void Initialize()
        {
            var webClientCaller = new WebClientCaller();
            webClientCaller.AddHtmlHandler(new DecodeHtmlContentHandler());
            webClientCaller.AddHtmlHandler(new EncodingUtf8HtmlContentHandler());

            var modelBuilder = new MinhTamCenterHtmlModelBuilder();

            var sendEmailService = new SendEmailService(new EmailConfigMemoryReader());
            var dataProcessor = new SendEmailForNewClassStrategy(new Core.Event.EventPublisher(new CommandProcessor()));

            _webContentProcess = new WebContentProcessor(webClientCaller, modelBuilder, dataProcessor);
        }

        [TestMethod]
        public void Get_WebHtmlContent_Success()
        {
            _webContentProcess.Process(new string[] { "http://giasuminhtam.com/lop-moi/lop-day-kem-cap-3-thpt/" });
        }
    }
}
