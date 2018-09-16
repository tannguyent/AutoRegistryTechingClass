using System;
using AutoRegistryTechingClass.SendEmail.Model;
using AutoRegistryTechingClass.SendEmail.Config;
using AutoRegistryTechingClass.SendEmail.ModelBuilder;

namespace AutoRegistryTechingClass.SendEmail.Service
{
    public class SendEmailService : ISendEmailService
    {
        private readonly EmailConfig _emailConfigModel;

        public SendEmailService(IEmailConfigReader emailConfig)
        {
            _emailConfigModel = emailConfig.GetConfig();
        }
        
        public void SendEmail(EmailModel email)
        {
            try
            {
                var smtp = new SmtpClientBuilder().SetConfig(_emailConfigModel).Instance();
                var receivedUsers = _emailConfigModel.SendToEmails.Split(',');
                foreach (var receiver in receivedUsers)
                {
                    var message = new MailMessageBuilder()
                        .SetEmailData(email)
                        .SetReceivedEmail(receiver)
                        .SetSenderEmail(_emailConfigModel.SendFromEmail)
                        .Instance();
                    smtp.Send(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
