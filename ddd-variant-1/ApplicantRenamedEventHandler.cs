using System;

namespace DddVariants.Variant1
{
    public class ApplicantRenamedEventHandler : IEventHandler<ApplicantRenamed>
    {
        public void Handle(ApplicantRenamed eventToHandle)
        {
            Console.WriteLine($"Renamed applicant with Id {eventToHandle.Id} to {eventToHandle.Name}");
        }
    }
}