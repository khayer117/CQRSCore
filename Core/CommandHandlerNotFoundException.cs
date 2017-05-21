using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core
{
    public class CommandHandlerNotFoundException:Exception
    {
        public CommandHandlerNotFoundException():base()
        {
        }

        public CommandHandlerNotFoundException(string message) : base(message)
        {
        }

        public CommandHandlerNotFoundException(string message, Exception innerException):base(message, innerException)
        {

        }
    }
}
