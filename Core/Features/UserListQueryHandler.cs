using CQRS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Features
{
    public class UserListQueryHandler : IQueryHandler<UserListQuery, IEnumerable<UserDetails>>
    {
        public IUserAccountService _userAccountService;

        public UserListQueryHandler(IUserAccountService userAccountService)
        {
            this._userAccountService = userAccountService;
        }
        public IEnumerable<UserDetails> Execute(UserListQuery query)
        {
            return this._userAccountService.GetAll(query.IsActive);
        }
    }
}
