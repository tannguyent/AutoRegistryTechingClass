using AutoRegistryTechingClass.SendEmail.Model;
using System.Net.Mail;

namespace AutoRegistryTechingClass.SendEmail.ModelBuilder
{
    public class SmtpClientBuilder
    {
        private SmtpClient _smtpClient { get; set; }

        public SmtpClientBuilder SetConfig(EmailConfig config) {
            this._smtpClient = new SmtpClient
            {
                Host = config.Host,
                Port = config.Port,
                EnableSsl = config.EnableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(config.Credentials.UserName, config.Credentials.Password)
            };
            return this;
        }

        public SmtpClient Instance()
        {
            return this._smtpClient;
        }

    }
}
