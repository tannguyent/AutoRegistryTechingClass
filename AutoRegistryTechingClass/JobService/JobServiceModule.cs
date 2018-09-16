using Autofac;
using AutoRegistryTechingClass.JobService.JobScheduler;
using AutoRegistryTechingClass.JobService.Service;
using Quartz;
using Quartz.Impl;

namespace AutoRegistryTechingClass.JobService
{
    class JobServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutoCheckNewClassScheduleService>().As<IScheduleService>().SingleInstance();
            builder.RegisterType<JobScheduler.JobScheduler>().As<IJobScheduler>().SingleInstance();
            base.Load(builder);
        }
    }
}
