namespace DddVariants.Variant1
{
    public interface IHandleCreateCommand<TCommand>
        where TCommand : Command
    {
        CreationResponse Handle(TCommand command);
    }

    public interface IHandleCommand<TCommand>
        where TCommand : Command, IHaveDomainId
    {
        void Handle(TCommand command);
    }
}