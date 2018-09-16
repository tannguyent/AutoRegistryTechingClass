using Quartz;
using System;

namespace AutoRegistryTechingClass.JobService.JobScheduler
{
    public interface IJobScheduler
    {
        void ScheduleJob<T>(string groupName, string jobDetails,
                        string triggerName, TimeSpan repeatInterval)
                        where T : IJob;

    }
}
