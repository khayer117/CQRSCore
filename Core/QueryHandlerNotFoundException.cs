using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core
{
    public class QueryHandlerNotFoundException:Exception
    {
        public QueryHandlerNotFoundException():base()
        {
        }

        public QueryHandlerNotFoundException(string message) : base(message)
        {
        }

        public QueryHandlerNotFoundException(string message, Exception innerException):base(message, innerException)
        {

        }
    }
}
