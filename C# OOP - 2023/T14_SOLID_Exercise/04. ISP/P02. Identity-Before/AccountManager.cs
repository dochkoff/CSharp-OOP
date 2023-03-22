namespace P02._Identity_Before
{
    using Contracts;
    using System;
    using System.Collections.Generic;

    public class AccountManager : IAccountManager
    {
        public bool RequireUniqueEmail { get; set; }

        public int MinRequiredPasswordLength { get; set; }

        public int MaxRequiredPasswordLength { get; set; }

        public void Register(string username, string password)
        {
            // register
        }

        public void Login(string username, string password)
        {
            // login
        }

        public void ChangePassword(string oldPass, string newPass)
        {
            // change password
        }
    }
}
