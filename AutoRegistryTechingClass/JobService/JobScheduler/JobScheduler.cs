using System;

using Quartz;
using Quartz.Spi;

namespace AutoRegistryTechingClass.JobService.JobScheduler
{
    public class JobScheduler : IJobScheduler
    {
        private readonly IScheduler _scheduler;
        private readonly ISchedulerFactory _schedFact;

        public JobScheduler(ISchedulerFactory schedFact, IJobFactory jobFactory)
        {
            this._schedFact = schedFact;
            this._scheduler = this._schedFact.GetScheduler();
            this._scheduler.JobFactory = jobFactory;
        }

        public void ScheduleJob<T>(string groupName, string job,
                                   string triggerName, TimeSpan repeatInterval)
                                    where T : IJob
        {
            ITrigger trigger = TriggerBuilder.Create()
              .WithIdentity(triggerName, groupName)
              .StartNow()
              .WithSimpleSchedule(x => x
                  .WithInterval(repeatInterval)
                  .RepeatForever())
              .Build();

            IJobDetail jobDetail = JobBuilder.Create<T>()
                .WithIdentity(job, groupName)
                .Build();

            this._scheduler.ScheduleJob(jobDetail, trigger);
            this._scheduler.Start();
        }
    }
}
