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
        public List<DigestViewModel> Digests { get; set; }
        public List<UserViewModel> Friends { get; set; }

        public UserViewModel(User user)
        {
            Id = user.Id;
            Username = user.Username;
            AvatarFilename = user.AvatarFilename;

            Digests = new List<DigestViewModel>();
            foreach (Digest digest in user.Digests)
            {
                Digests.Add(new DigestViewModel(digest));
            }

            Friends = new List<UserViewModel>();
            foreach (User friend in user.Friends)
            {
                Friends.Add(new UserViewModel(friend));
            }
        }
      
    }
}
