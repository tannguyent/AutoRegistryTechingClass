using System.Collections.Generic;
using AutoRegistryTechingClass.Core.CommandPattern;
using AutoRegistryTechingClass.Core.Event.Internal;

namespace AutoRegistryTechingClass.Core.Event
{
    public class EventPublisher : IEventPublisher
    {
        private Queue<IEvent> events;
        private ICommandProcessor _process;

        public EventPublisher(ICommandProcessor process)
        {
            events = new Queue<IEvent>();
            _process = process;
        }

        public void Broadcast()
        {
            foreach (var @event in events)
            {
                _process.Process(@event);
            }

            events.Clear();
        }

        public void Discard()
        {
            events.Clear();
        }

        public void Queue(IEvent @event)
        {
            events.Enqueue(@event);
        }
    }
}
