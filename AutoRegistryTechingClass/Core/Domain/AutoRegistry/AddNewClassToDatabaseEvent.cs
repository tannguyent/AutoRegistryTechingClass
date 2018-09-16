using AutoRegistryTechingClass.Core.Event.Internal;

namespace AutoRegistryTechingClass.Core.Domain.AutoRegistry
{
    public class AddNewClassToDatabaseEvent : IEvent
    {
        public string ClassId { get; set; }
        public string ContentHtml { get; set; }
    }
}
