namespace AutoRegistryTechingClass.SendEmail.Model
{
    public class EmailConfig
    {
        public EmailCredential Credentials { get; set; }

        public bool EnableSsl { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string SendFromEmail { get; set; }

        public string SendToEmails { get; set; }
    }
}
