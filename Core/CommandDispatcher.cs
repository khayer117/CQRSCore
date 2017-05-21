using Autofac;
using System;

namespace CQRS.Core
{
    public class CommandDispatcher : ICommandDispatcher
    {
        public IComponentContext _container;

        public CommandDispatcher(IComponentContext container)
        {
            this._container = container;

        }
        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if(command == null)
            {
                throw new ArgumentNullException("command");
            }

            var handler = this._container.Resolve<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                var msg = $"Command is null for type {typeof(TCommand).AssemblyQualifiedName}";
                throw new CommandHandlerNotFoundException(msg);
            }

            handler.Execute(command);
        }
    }
}
