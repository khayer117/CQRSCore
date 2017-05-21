using CQRS.Core;
using CQRS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Features
{
    public class UserDetailsQuery:IQuery<UserDetails>
    {
        public int Id { get; set; }
    }
}
