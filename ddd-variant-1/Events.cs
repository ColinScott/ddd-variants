using System.Collections.Generic;

namespace DddVariants.Variant1
{
    public static class Events
    {
        // This is horrendous on many levels and should never be done for production code
        // A real implementation would have to manage state for concurrent requests.
        private static readonly List<Event> _events = new List<Event>();

        public static IEnumerable<Event> CurrentEvents => _events.AsReadOnly();

        public static void Publish(params Event[] events)
        {
            _events.AddRange(events);
        }

        public static void Clear()
        {
            _events.Clear();
        }
    }
}