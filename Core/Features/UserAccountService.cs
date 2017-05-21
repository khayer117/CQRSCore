using CQRS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Core.Features
{
    public interface IUserAccountService
    {
        void DeleteUser(int userId);
        UserDetails GetUserDetails(int userId);
        IEnumerable<UserDetails> GetAll(bool isActive);
    }

    public class UserAccountService : IUserAccountService
    {
        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
        public UserDetails GetUserDetails(int userId)
        {
            var userDetails = new UserDetails();
            userDetails.Id = 10;
            userDetails.FirstName = "Brain";
            userDetails.LastName = "Lara";
            userDetails.Email = "lara@test.com";

            return userDetails;
        }
        public IEnumerable<UserDetails> GetAll(bool isActive)
        {
            var userList = new List<UserDetails>();
            userList.Add(new UserDetails
            {
                Id = 1,
                FirstName = "Brawn",
                LastName = "Mall"
            });

            userList.Add(new UserDetails
            {
                Id = 2,
                FirstName = "Stev",
                LastName = "Way"
            });

            return userList;
        }
    }
}
