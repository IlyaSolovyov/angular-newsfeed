using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsfeedClient.Models;

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
                new Digest {Id = 1, Name = "Football", Public = true},
                new Digest {Id = 2, Name = "Angular", Public = true },
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
        public IEnumerable<User> GetFriendsByUser(int userId)
        {
            return TestUsers
                .FirstOrDefault(user => user.Id == userId)
                .Friends;
        }
    }
}