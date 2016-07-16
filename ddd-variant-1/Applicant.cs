namespace DddVariants.Variant1
{
    public class Applicant : IDomainObject
    {
        private int Id { get; set; }

        int IDomainObject.Id
        {
            get { return this.Id; }
            set { this.Id = value; }
        }

        public string Name { get; private set; }

        public void Handle(CreateApplicant command)
        {
            Name = command.Name;
            Events.Publish(new ApplicantCreated { Name = command.Name });
        }

        public void Handle(RenameApplicant command)
        {
            Name = command.Name;
            Events.Publish(new ApplicantRenamed {Name = command.Name});
        }
    }
}