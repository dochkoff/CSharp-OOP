using System;
using P02._Identity_Before.Contracts;
using System.Collections.Generic;

namespace P02._Identity_Before
{
    public class UserManager : IUserManager
    {
        public IEnumerable<IUser> GetAllUsersOnline()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public IUser GetUserByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

