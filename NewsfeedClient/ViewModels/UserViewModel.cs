using NewsfeedClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string AvatarFilename { get; set; }
        public ICollection<Digest> Digests { get; set; }
        public ICollection<User> Friends { get; set; }

        public UserViewModel(User user)
        {
            Id = user.Id;
            Username = user.Username;
            AvatarFilename = user.AvatarFilename;
            Digests = user.Digests;
            Friends = user.Friends;
        }
    }
}
