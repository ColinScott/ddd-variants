using System;

namespace DddVariants.Variant1
{
    public class ApplicantCreatedEventHandler : IEventHandler<ApplicantCreated>
    {
        public void Handle(ApplicantCreated eventToHandle)
        {
            Console.WriteLine($"Created an applicant with name {eventToHandle.Name} and Id {eventToHandle.Id}");
        }
    }
}