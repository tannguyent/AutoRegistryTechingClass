using AutoRegistryTechingClass.SendEmail.Model;

namespace AutoRegistryTechingClass.SendEmail.Service
{
    public interface ISendEmailService
    {
        void SendEmail(EmailModel email);
    }
}
