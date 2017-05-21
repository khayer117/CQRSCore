using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.DTO;

namespace CQRS.Core.Features
{
    public class UserDetailsQueryHandler : IQueryHandler<UserDetailsQuery, UserDetails>
    {
        public IUserAccountService _userAccountService;
        public UserDetailsQueryHandler(IUserAccountService userAccountService)
        {
            this._userAccountService = userAccountService;
        }
        public UserDetails Execute(UserDetailsQuery query)
        {
            return this._userAccountService.GetUserDetails(query.Id);
        }
    }

}
