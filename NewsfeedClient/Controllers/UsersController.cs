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
        private List<User> TestUsers { get; set; }
        private List<Digest> TestDigests { get; set; }

        public UsersController()
        {
            PopulateWithDummyData();
        }

        private void PopulateWithDummyData()
        {        
            TestDigests = new List<Digest>
            {
                new Digest {Id = 1, Name = "Football", IsPublic = true},
                new Digest {Id = 2, Name = "Angular", IsPublic = true },
            };

            TestUsers = new List<User>
            {
                 new User { Id = 1, Digests = TestDigests }
            };

        }

        // GET: api/users/5/digests
        [HttpGet("{userId}/digests/")]
        public IEnumerable<Digest> GetDigestsByUser(int userId)
        {
            return TestUsers
                .FirstOrDefault(user => user.Id == userId)
                .Digests;
        }

        // GET: api/users/5/digests
        [HttpGet("{userId}/friends/")]
        public IEnumerable<UserViewModel> GetFriendsByUser(int userId)
        {
            List<UserViewModel> friends = new List<UserViewModel>();

            List<User> friendModels = TestUsers
                .FirstOrDefault(user => user.Id == userId)
                .Friends
                .ToList();

            foreach(User friendModel in friendModels)
            {
                friends.Add(new UserViewModel(friendModel));
            }

            return friends;
        }
    }
}