using CQRS.DTO;
using CQRS.Core.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Features
{

    public class UserListQuery : IQuery<IEnumerable<UserDetails>>
    {
        public bool IsActive { get; set; }
    }

}
