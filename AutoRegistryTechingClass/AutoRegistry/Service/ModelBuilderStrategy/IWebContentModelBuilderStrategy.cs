using AutoRegistryTechingClass.AutoRegistry.Model;
using System.Collections.Generic;

namespace AutoRegistryTechingClass.AutoRegistry.Service
{
    public interface IWebContentModelBuilderStrategy
    {
        List<ClassInformationModel> BuildModel(string webContent);
    }
}
