using System;
using TrashBoard.Domain.DomainExceptions;
using TrashBoard.Domain;
using TrashBoard.Domain.Utills;

namespace TrashBoard.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        // public Guid Uuid { get; private set; }
        public string Username { get; private set; }
        public string Login { get; private set; }
        private string PasswordHash { get; set; }

        private User()  // для EF
        {
            this.Username = null!;
            this.Login = null!;         // null-forgiving operator -> будет инициализировано EF
            this.PasswordHash = null!;
        }

        public User(string username, string login, string passwordHash)
        {
            //if (uuid == Guid.Empty)
            //    throw new DomainException("UUID is required");
            Validators.ValidateString(username, DomainRules.MinUsernameLength, DomainRules.MaxUsernameLength, "Username");
            Validators.ValidateString(login, DomainRules.MinLoginLength, DomainRules.MaxLoginLength, "Login");
            Validators.ValidateString(passwordHash, "Password");

            //Uuid = uuid;
            this.Username = username;
            this.Login = login;
            this.PasswordHash = passwordHash;
        }
    }
}
