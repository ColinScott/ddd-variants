namespace DddVariants.Variant1
{
    public interface IRepository
    {
        TAggregate Load<TAggregate>(int id)
            where TAggregate : class, IDomainObject;

        int Save<TAggregate>(TAggregate aggregate)
            where TAggregate : IDomainObject;
    }
}