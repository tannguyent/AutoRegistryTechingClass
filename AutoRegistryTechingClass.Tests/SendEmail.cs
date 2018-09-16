using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoRegistryTechingClass.SendEmail.Service;
using AutoRegistryTechingClass.SendEmail.Config;

namespace AutoRegistryTechingClass.Tests
{
    [TestClass]
    public class SendEmail
    {
        private ISendEmailService sendEmailService;

        [TestInitialize]
        public void Initialize()
        {
            sendEmailService = new SendEmailService(new EmailConfigMemoryReader());
        }

        [TestMethod]
        public void Send_Email_Success()
        {
            sendEmailService.SendEmail(new AutoRegistryTechingClass.SendEmail.Model.EmailModel() {
                SendFrom="tinhanh140489@gmail.com",
                SendTo="tinhanh89@gmail.com",
                Subject="Test",
                Content="Test"
            });
        }
    }
}
