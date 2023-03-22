using System;
using P02._Identity_Before.Contracts;

namespace P02._Identity_Before
{
    public class User : IUser
    {
        public string Name => throw new NotImplementedException();

        public string Email => throw new NotImplementedException();

        public string PasswordHash => throw new NotImplementedException();
    }
}

