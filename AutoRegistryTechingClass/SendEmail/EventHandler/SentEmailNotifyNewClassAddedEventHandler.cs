using AutoRegistryTechingClass.Core.CommandPattern.Internal;
using AutoRegistryTechingClass.Core.Domain.AutoRegistry;
using AutoRegistryTechingClass.Core.Extension;
using AutoRegistryTechingClass.SendEmail.Service;

namespace AutoRegistryTechingClass.SendEmail.EventHandler
{
    class SentEmailNotifyNewClassAddedEventHandler : IHandler<AddNewClassToDatabaseEvent>
    {
        private ISendEmailService _sendEmailService;

        public SentEmailNotifyNewClassAddedEventHandler(ISendEmailService sendEmailService)
        {
            _sendEmailService = sendEmailService;
        }

        public void Handle(AddNewClassToDatabaseEvent command)
        {
            var email = new Model.EmailModel();
            email.Content = command.ContentHtml;
            _sendEmailService.SendEmail(email);
        }
    }
}
