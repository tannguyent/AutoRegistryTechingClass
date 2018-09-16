using AutoRegistryTechingClass.AutoRegistry.Model;
using System.Collections.Generic;

namespace AutoRegistryTechingClass.AutoRegistry.Service.WebContentProcessStrategy
{
    public interface IDataProcessStrategy
    {
        void Process(List<ClassInformationModel> classInformations);
    }
}
