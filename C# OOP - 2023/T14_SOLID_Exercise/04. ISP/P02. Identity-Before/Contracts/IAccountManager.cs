namespace P02._Identity_Before.Contracts
{
    using System.Collections.Generic;

    public interface IAccountManager
    {
        bool RequireUniqueEmail { get; }

        int MinRequiredPasswordLength { get; }

        int MaxRequiredPasswordLength { get; }

        void Register(string username, string password);

        void Login(string username, string password);

        void ChangePassword(string oldPass, string newPass);
    }
}
