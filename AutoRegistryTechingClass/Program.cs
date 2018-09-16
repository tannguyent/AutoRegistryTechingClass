using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Extras.Quartz;
using AutoRegistryTechingClass.AutoRegistry;
using AutoRegistryTechingClass.Core;
using AutoRegistryTechingClass.JobService;
using AutoRegistryTechingClass.JobService.Job;
using AutoRegistryTechingClass.JobService.Service;
using AutoRegistryTechingClass.SendEmail;
using Microsoft.Practices.ServiceLocation;
using Topshelf;
using Topshelf.Autofac;
using Topshelf.Quartz;

namespace AutoRegistryTechingClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<AutoRegistryModule>();
            builder.RegisterModule<SendEmailModule>();
            builder.RegisterModule<JobServiceModule>();

            builder.RegisterModule<QuartzAutofacFactoryModule>();
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(AutoSendEmailIfHaveNewClassJob).Assembly));

            var container = builder.Build();

            // Set the service locator to an AutofacServiceLocator.
            var csl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => csl);

            HostFactory.Run(x =>
            {
                x.Service<IScheduleService>(s =>
                {
                    s.ConstructUsingAutofacContainer();
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.StartAutomatically();
                x.UseAutofacContainer(container);

                x.SetDescription("Auto Send Email Service hosted by TopShelf");
                x.SetDisplayName("Auto Send Email Service each then have new class had been updated");
                x.SetServiceName("AutoRegistryTechingClass");
            });
        }
    }
}
