using AutoRegistryTechingClass.AutoRegistry.WebCaller;
using AutoRegistryTechingClass.AutoRegistry.Service.WebContentProcessStrategy;
using AutoRegistryTechingClass.AutoRegistry.Data;
using System.Linq;
using System.Collections.Generic;

namespace AutoRegistryTechingClass.AutoRegistry.Service
{
    public class WebContentProcessor : IWebContentProcessor
    {
        private readonly IWebCaller _webcaller;
        private readonly IWebContentModelBuilderStrategy _htmlModelBuilderStrategy;
        private readonly IDataProcessStrategy _dataProcessStrategy;

        public WebContentProcessor(IWebCaller webcaller,
            IWebContentModelBuilderStrategy htmlModelBuilderStrategy,
            IDataProcessStrategy dataProcessStrategy)
        {
            _webcaller = webcaller;
            _htmlModelBuilderStrategy = htmlModelBuilderStrategy;
            _dataProcessStrategy = dataProcessStrategy;
        }

        public void Process(IEnumerable<string> urls)
        {
            using (var context = new RegisteredClassManagerContext())
            {
                var isFirstTimeRun = context.Settings.FirstOrDefault(c => c.SettingKey == Settings.SettingKeyConstants.IsFirstTimeRunKey);
                if (isFirstTimeRun == null)
                {
                    context.Settings.Add(new Data.Settings
                    {
                        SettingKey = Settings.SettingKeyConstants.IsFirstTimeRunKey,
                        SettingValue = "True"
                    });
                    context.SaveChanges();
                }
                else
                {
                    isFirstTimeRun.SettingValue = "False";
                    context.Settings.Update(isFirstTimeRun);
                    context.SaveChanges();
                }
            }

            var classInformations = new List<Model.ClassInformationModel>();
            foreach (var url in urls)
            {
                var htmlContent = _webcaller.GetStringContent(url);
                var classAvaiables = _htmlModelBuilderStrategy.BuildModel(htmlContent);
                classInformations.AddRange(classAvaiables);
            }
            
            _dataProcessStrategy.Process(classInformations);
        }
    }
}
