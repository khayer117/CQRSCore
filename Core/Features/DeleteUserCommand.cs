using CQRS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Features
{
    public class DeleteUserCommand:ICommand
    {
        public int UserId { get; set; }
    }

}
