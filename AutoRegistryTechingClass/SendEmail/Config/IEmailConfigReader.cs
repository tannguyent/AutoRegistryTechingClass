using AutoRegistryTechingClass.SendEmail.Model;

namespace AutoRegistryTechingClass.SendEmail.Config
{
    public interface IEmailConfigReader
    {
        EmailConfig GetConfig();
    }
}
