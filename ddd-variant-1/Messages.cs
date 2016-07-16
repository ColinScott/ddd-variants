namespace DddVariants.Variant1
{
    public class CreateApplicant : Command
    {
        public string Name { get; set; }
    }

    public class ApplicantCreated : Event
    {
        public string Name { get; set; }
    }

    public class RenameApplicant : Command, IHaveDomainId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ApplicantRenamed : Event
    {
        public string Name { get; set; }
    }
}