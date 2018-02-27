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
        public List<int> FriendIds { get; set; }

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

            FriendIds = new List<int>();
            foreach (Friendship friendship in user.Friendships)
            {
                if (friendship.Friend1Id == Id)
                {
                    FriendIds.Add(friendship.Friend2Id);
                }
                else
                {
                    FriendIds.Add(friendship.Friend1Id);
                }
              
            }
        }
      
    }
}
