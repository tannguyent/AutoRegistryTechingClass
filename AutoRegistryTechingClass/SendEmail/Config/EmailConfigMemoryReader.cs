using AutoRegistryTechingClass.SendEmail.Model;
using AutoRegistryTechingClass.SendEmail.ModelBuilder;

namespace AutoRegistryTechingClass.SendEmail.Config
{
    public class EmailConfigMemoryReader : IEmailConfigReader
    {
        public EmailConfig GetConfig()
        {
            return new GmailConfigBuilder()
                .SetUserName("tannguyent140489@gmail.com")
                .SetPassWord("@tinhanh89")
                .SetDefaultSenderEmail("tannguyent140489@gmail.com")
                .SetDefaultReceivedEmails("dogs.utnllt@gmail.com")
                .Instance();
        }
    }
}
