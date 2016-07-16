namespace DddVariants.Variant1
{
    public interface IDispatcher
    {
        CreationResponse DispatchCreation<TCommand>(TCommand command)
            where TCommand : Command;

        void Dispatch<TCommand>(TCommand command)
            where TCommand : Command, IHaveDomainId;
    }
}