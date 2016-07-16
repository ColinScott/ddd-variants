namespace DddVariants.Variant1
{
    public class HandleRenameApplicant : IHandleCommand<RenameApplicant>
    {
        private readonly IRepository _repository;

        public HandleRenameApplicant(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(RenameApplicant command)
        {
            var applicant = _repository.Load<Applicant>(command.Id);

            applicant.Handle(command);
        }
    }
}