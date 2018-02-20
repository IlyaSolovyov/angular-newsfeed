using NewsfeedClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.ViewModels
{
    public class AccountViewModel
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AccountViewModel(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Email = user.Email;
        }

        public AccountViewModel()
        {
            Id = 0;
            Username = "";
            Email = "";
            Password = "";
        }
    }
}
