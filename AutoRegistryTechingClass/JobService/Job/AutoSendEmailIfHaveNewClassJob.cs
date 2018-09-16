using Quartz;
using System;

using AutoRegistryTechingClass.AutoRegistry.Service;
using Microsoft.Practices.ServiceLocation;
using AutoRegistryTechingClass.Core.Event;

namespace AutoRegistryTechingClass.JobService.Job
{
    class AutoSendEmailIfHaveNewClassJob: IJob
    {
        private readonly IEventPublisher _eventPublisher;
        private readonly IWebContentProcessor _webContentProcess;

        public AutoSendEmailIfHaveNewClassJob()
        {
            this._webContentProcess = ServiceLocator.Current.GetInstance<IWebContentProcessor>();
            this._eventPublisher = ServiceLocator.Current.GetInstance<IEventPublisher>();
        }

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Job is executing - {0}.", DateTime.Now);
            this._webContentProcess.Process(new string[] {
                "http://giasuminhtam.com/lop-moi/lop-day-kem-cap-3-thpt/",
                "http://giasuminhtam.com/lop-moi/lop-day-kem-cap-2-thcs/"
            });
            this._eventPublisher.Broadcast();
        }

        
    }
}
