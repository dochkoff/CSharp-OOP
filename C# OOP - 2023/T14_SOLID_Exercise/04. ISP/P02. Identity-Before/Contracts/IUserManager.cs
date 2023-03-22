using System;
using System.Collections.Generic;

namespace P02._Identity_Before.Contracts
{
    public interface IUserManager
    {
        public IEnumerable<IUser> GetAllUsersOnline();

        public IEnumerable<IUser> GetAllUsers();

        public IUser GetUserByName(string name);
    }
}

