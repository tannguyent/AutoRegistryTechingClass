using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRegistryTechingClass.SendEmail.Model;
using AutoRegistryTechingClass.SendEmail.ModelBuilder;

namespace AutoRegistryTechingClass.SendEmail.Config
{
    public class EmailConfigFileReader : IEmailConfigReader
    {
        public EmailConfig GetConfig()
        {
            return new GmailConfigBuilder()
                .SetUserName(AppSetting.Default.SenderUser)
                .SetPassWord(AppSetting.Default.PassSenderEmail)
                .SetDefaultSenderEmail(AppSetting.Default.SenderEmail)
                .SetDefaultReceivedEmails(AppSetting.Default.ReceivedEmails)
                .Instance();
        }
    }
}
