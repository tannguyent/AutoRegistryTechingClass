using AutoRegistryTechingClass.SendEmail.Model;

namespace AutoRegistryTechingClass.SendEmail.ModelBuilder
{
    public class GmailConfigBuilder
    {
        private bool _gmailEnableSsl { get; set; }
        private string _gmailHost { get; set; }
        private int _gmailPort { get; set; }
        private string _gmailUserName { get; set; }
        private string _gmailPassword { get; set; }


        private string _defaultSenderEmail { get; set; }
        private string _defaultReceivedEmails { get; set; }

        public GmailConfigBuilder()
        {
            _gmailHost = "smtp.gmail.com";
            _gmailPort = 587;
            _gmailEnableSsl = true;
        }

        public GmailConfigBuilder SetEnableSsl(bool enableSsl)
        {
            this._gmailEnableSsl = enableSsl;
            return this;
        }

        public GmailConfigBuilder SetUserName(string userName)
        {
            this._gmailUserName = userName;
            return this;
        }

        public GmailConfigBuilder SetDefaultSenderEmail(string email)
        {
            this._defaultSenderEmail = email;
            return this;
        }

        public GmailConfigBuilder SetDefaultReceivedEmails(string emails)
        {
            this._defaultReceivedEmails = emails;
            return this;
        }

        public GmailConfigBuilder SetPassWord(string passWord)
        {
            this._gmailPassword = passWord;
            return this;
        }

        public EmailConfig Instance()
        {
            return new EmailConfig()
            {
                Host = _gmailHost,
                Port = _gmailPort,
                EnableSsl = _gmailEnableSsl,
                Credentials = new EmailCredential()
                {
                    UserName = _gmailUserName,
                    Password = _gmailPassword
                },
                SendFromEmail = _defaultSenderEmail,
                SendToEmails = _defaultReceivedEmails
            };
        }
    }
}
