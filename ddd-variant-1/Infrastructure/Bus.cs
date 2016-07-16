namespace DddVariants.Variant1.Infrastructure
{
    public class Bus : IBus
    {
        public void Publish(Event eventToPublish)
        {
            new GeneralEventHandler().Handle(eventToPublish);

            var createdEvent = eventToPublish as ApplicantCreated;
            if (createdEvent != null)
            {
                new ApplicantCreatedEventHandler().Handle(createdEvent);
            }

            var renamedEvent = eventToPublish as ApplicantRenamed;
            if (renamedEvent != null)
            {
                new ApplicantRenamedEventHandler().Handle(renamedEvent);
            }
        }
    }
}