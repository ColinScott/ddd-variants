using System;
using System.ComponentModel;

namespace DddVariants.Variant1.Infrastructure
{
    public class Dispatcher : IDispatcher
    {
        private readonly IBus _bus;
        private readonly Repository _repository = new Repository();

        public Dispatcher(IBus bus)
        {
            _bus = bus;
        }

        public CreationResponse DispatchCreation<TCommand>(TCommand command)
            where TCommand : Command
        {
            var creationResult = BuildCreateHandler<TCommand>(command.GetType()).Handle(command);

            foreach (var eventToPublish in Events.CurrentEvents)
            {
                eventToPublish.Id = _repository.LastObject.Id;
                _bus.Publish(eventToPublish);
            }

            Events.Clear();

            return creationResult;
        }

        public void Dispatch<TCommand>(TCommand command)
            where TCommand : Command, IHaveDomainId
        {
            BuildHandler<TCommand>(command.GetType()).Handle(command);

            foreach (var eventToPublish in Events.CurrentEvents)
            {
                eventToPublish.Id = _repository.LastObject.Id;
                _bus.Publish(eventToPublish);
            }

            Events.Clear();
        }

        private IHandleCreateCommand<TCommand> BuildCreateHandler<TCommand>(Type commandType)
            where TCommand : Command
        {
            // Pretend there's appropriate magic here
            return (IHandleCreateCommand<TCommand>) new HandleCreateApplicant(_repository);
        }

        private IHandleCommand<TCommand> BuildHandler<TCommand>(Type commandType)
            where TCommand : Command, IHaveDomainId
        {
            // Pretend there's appropriate magic here
            return (IHandleCommand<TCommand>) new HandleRenameApplicant(_repository);
        }
    }
}