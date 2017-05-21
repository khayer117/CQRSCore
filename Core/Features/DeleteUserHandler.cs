using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Features
{
    public class DeleteUserHandler : ICommandHandler<DeleteUserCommand>
    {

        public void Execute(DeleteUserCommand command)
        {
            Console.WriteLine($"User is deleted. User id:{command.UserId}");
        }
    }

}
