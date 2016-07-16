namespace DddVariants.Variant1
{
    public interface IEventHandler<TEvent>
        where TEvent : Event
    {
        void Handle(TEvent eventToHandle);
    }
}