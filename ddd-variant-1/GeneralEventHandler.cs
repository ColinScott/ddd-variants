using System;

namespace DddVariants.Variant1
{
    public class GeneralEventHandler : IEventHandler<Event>
    {
        public void Handle(Event eventToHandle)
        {
            Console.WriteLine($"Received an event of type {eventToHandle.GetType()} for {eventToHandle.Id}");
        }
    }
}