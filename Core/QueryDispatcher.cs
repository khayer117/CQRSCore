using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core
{
    public class QueryDispatcher : IQueryDispatcher
    {
        public IComponentContext _container;
        public QueryDispatcher(IComponentContext container)
        {
            this._container = container;
        }

        public TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult>
        {
            if (query == null)
            {
                throw new ArgumentNullException();
            }

            var handler = this._container.Resolve<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
            {
                throw new QueryHandlerNotFoundException();
            }

            return handler.Execute(query);
        }
    }
}
