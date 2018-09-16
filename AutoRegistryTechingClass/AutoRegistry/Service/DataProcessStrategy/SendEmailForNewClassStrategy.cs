using AutoRegistryTechingClass.AutoRegistry.Data;
using AutoRegistryTechingClass.Core.Domain.AutoRegistry;
using AutoRegistryTechingClass.Core.Event;
using AutoRegistryTechingClass.SendEmail.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRegistryTechingClass.AutoRegistry.Service.WebContentProcessStrategy
{
    public class SendEmailForNewClassStrategy : IDataProcessStrategy
    {
        private readonly IEventPublisher _eventPublisher;

        public SendEmailForNewClassStrategy(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }

        public void Process(List<Model.ClassInformationModel> classInformations)
        {
            using (var context = new RegisteredClassManagerContext())
            {
                var isFirstTimeRun = context.Settings.FirstOrDefault(c => c.SettingKey == Settings.SettingKeyConstants.IsFirstTimeRunKey);
                var allRegisteredClass = context.RegisteredClass.ToList();


                foreach (var classInformation in classInformations)
                {
                    var classExist = allRegisteredClass.FirstOrDefault(c => c.ClassId == classInformation.ClassId);
                    if (classExist != null)
                        continue;

                    context.RegisteredClass.Add(new RegisteredClass()
                    {
                        ClassId = classInformation.ClassId,
                        ClassName = classInformation.ClassName,
                    });
                    
                    context.SaveChanges();

                    if (isFirstTimeRun != null && !Convert.ToBoolean(isFirstTimeRun.SettingValue))
                    {
                        _eventPublisher.Queue(new AddNewClassToDatabaseEvent()
                        {
                            ClassId = classInformation.ClassId,
                            ContentHtml = classInformation.ContentHtml
                        });
                    }
                }
            }
        }
    }
}
