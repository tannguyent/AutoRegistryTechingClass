using AutoRegistryTechingClass.SendEmail.Model;
using System.Net.Mail;

namespace AutoRegistryTechingClass.SendEmail.ModelBuilder
{
    public class MailMessageBuilder
    {
        public string _defaultSenderEmail { get; set; }
        public string _defaultReceivedEmail { get; set; }
        public string _defaultSubjectEmail { get; set; }
        public string _defaultContentEmail { get; set; }

        public MailMessageBuilder SetEmailData(EmailModel model)
        {
            _defaultSenderEmail = string.IsNullOrEmpty(model.SendFrom) ? _defaultSenderEmail : model.SendFrom;
            _defaultReceivedEmail = string.IsNullOrEmpty(model.SendTo) ? _defaultReceivedEmail : model.SendTo;
            _defaultSubjectEmail = string.IsNullOrEmpty(model.Subject) ? _defaultSubjectEmail : model.Subject;
            _defaultContentEmail = string.IsNullOrEmpty(model.Content) ? _defaultContentEmail : model.Content;
            return this;
        }

        public MailMessageBuilder SetReceivedEmail(string receiver)
        {
            _defaultReceivedEmail = receiver;
            return this;
        }

        public MailMessageBuilder SetSenderEmail(string sender)
        {
            _defaultSenderEmail = sender;
            return this;
        }

        public MailMessageBuilder SetConfig(EmailConfig _emailConfigModel)
        {
            _defaultSenderEmail = _emailConfigModel.SendFromEmail;
            _defaultReceivedEmail = _emailConfigModel.SendToEmails;
            return this;
        }

        public MailMessage Instance()
        {
            var mailMessage = new System.Net.Mail.MailMessage(_defaultSenderEmail, _defaultReceivedEmail)
            {
                Subject = _defaultSubjectEmail,
                Body = _defaultContentEmail,
                IsBodyHtml = true
            };

            return mailMessage;
        }

        
    }
}
