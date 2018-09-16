using AutoRegistryTechingClass.JobService.Job;
using AutoRegistryTechingClass.JobService.JobScheduler;
using System;
using AutoRegistryTechingClass.AutoRegistry.Data;

namespace AutoRegistryTechingClass.JobService.Service
{
    public class AutoCheckNewClassScheduleService: IScheduleService
    {
        private readonly IJobScheduler _scheduler;

        public AutoCheckNewClassScheduleService(IJobScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void Start()
        {
            Console.WriteLine("Starting Service ...");

            Console.WriteLine("     Setup DataBase ...");
            using (var context = new RegisteredClassManagerContext())
            {
                context.Database.EnsureCreated();
            }

            Console.WriteLine("     Setup Job Schedule ...");
            _scheduler.ScheduleJob<AutoSendEmailIfHaveNewClassJob>("SendEmailIfHaveNewClass",
                                            "SendEmailIfHaveNewClass",
                                            "SendEmailIfHaveNewTrigger",
                                            TimeSpan.FromMinutes(5));
        }

        public void Stop()
        {
            Console.WriteLine("Stopping Service ...");
        }
    }
}
