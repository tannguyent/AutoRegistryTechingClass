using System.Collections.Generic;

namespace AutoRegistryTechingClass.AutoRegistry.Service
{
    public interface IWebContentProcessor
    {
        void Process(IEnumerable<string> url);
    }
}