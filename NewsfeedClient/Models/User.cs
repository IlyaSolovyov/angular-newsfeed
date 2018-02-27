using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarFilename { get; set; } 

        public List<Digest> Digests { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public List<Friendship> Friendships { get; set; }

        public User()
        {
            AvatarFilename = "avatarPlaceholder.png";
            Digests = new List<Digest>();
            Subscriptions = new List<Subscription>();
            Friendships = new List<Friendship>();
        }
    }
}
