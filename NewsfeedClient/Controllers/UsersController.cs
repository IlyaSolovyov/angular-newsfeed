using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsfeedClient.Models;
using NewsfeedClient.ViewModels;

namespace NewsfeedClient.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private List<User> Users { get; set; }
        private List<Digest> Digests { get; set; }

        public UsersController()
        {
            PopulateWithDummyData();
        }

        private void PopulateWithDummyData()
        {        
            Digests = new List<Digest>
            {
                new Digest {Id = 1, Name = "Basketball", IsPublic = true},
                new Digest {Id = 2, Name = "Movies", IsPublic = true },
            };

            Users = new List<User>
            {
                 new User { Id = 1, Digests = Digests, Username = "Test user" }
            };

        }

        // GET: api/users/5/digests
        [HttpGet("{userId}/digests/")]
        public IEnumerable<DigestViewModel> GetDigestsByUser(int userId)
        {
            List<DigestViewModel> digests = new List<DigestViewModel>();

            List<Digest> digestModels = Users
                .FirstOrDefault(user => user.Id == userId)
                .Digests
                .ToList();

            foreach (Digest digestModel in digestModels)
            {
               digests.Add(new DigestViewModel(digestModel));
            }

            return digests;
        }

        // GET: api/users/5/digests
        [HttpGet("{userId}/friends/")]
        public IEnumerable<UserViewModel> GetFriendsByUser(int userId)
        {
            List<UserViewModel> friends = new List<UserViewModel>();

            List<User> friendModels = Users
                .FirstOrDefault(user => user.Id == userId)
                .Friends
                .ToList();

            foreach(User friendModel in friendModels)
            {
                friends.Add(new UserViewModel(friendModel));
            }

            return friends;
        }

        // POST: api/users/5
        [HttpGet("{userId}")]
        public UserViewModel GetUserData(int userId)
        {
            UserViewModel userData = new UserViewModel(Users
                .Find(u => u.Id == userId));
            return userData;
        }
    }
}