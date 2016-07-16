using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DddVariants.Variant1.Infrastructure
{
    public class Repository : IRepository
    {
        // If you ever do this in production code may somewhat terrible things befall everyone you love
        private readonly IDictionary<int, IDomainObject> _domainObjects = new Dictionary<int, IDomainObject>();

        public IDomainObject LastObject { get; private set; }

        public TAggregate Load<TAggregate>(int id)
            where TAggregate : class, IDomainObject
        {
            IDomainObject instance;

            var aggregate = _domainObjects.TryGetValue(id, out instance)
                ? instance as TAggregate
                : null;

            LastObject = aggregate;

            return aggregate;
        }

        public int Save<TAggregate>(TAggregate aggregate)
            where TAggregate : IDomainObject
        {
            LastObject = aggregate;

            var nextId = _domainObjects.Count + 1;

            aggregate.Id = nextId;
            _domainObjects.Add(nextId, aggregate);

            return nextId;
        }
    }
}