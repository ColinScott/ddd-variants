namespace DddVariants.Variant1
{
    public class HandleCreateApplicant : IHandleCreateCommand<CreateApplicant>
    {
        private readonly IRepository _repository;

        public HandleCreateApplicant(IRepository repository)
        {
            _repository = repository;
        }

        public CreationResponse Handle(CreateApplicant command)
        {
            var applicant = new Applicant();
            applicant.Handle(command);

            var applicantId = _repository.Save(applicant);

            return new CreationOk(applicantId);
        }
    }
}