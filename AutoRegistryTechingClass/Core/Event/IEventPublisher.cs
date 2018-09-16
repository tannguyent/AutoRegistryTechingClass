using AutoRegistryTechingClass.Core.Event.Internal;

namespace AutoRegistryTechingClass.Core.Event
{
    public interface IEventPublisher
    {
        void Queue(IEvent @event);

        void Broadcast();

        void Discard();
    }
}
