using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsfeedClient.DAL;
using NewsfeedClient.Models;
using NewsfeedClient.ViewModels;

namespace NewsfeedClient.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        NewsfeedContext db;

        public UsersController(NewsfeedContext context)
        {
            db = context;
        }

         
        // GET: api/users/5/subscriptions
        [HttpGet("{userId}/subscriptions/")]
        public IActionResult GetSubscriptionsByUser(int userId)
        {
            if (!db.Users.Any(u => u.Id == userId))
            {
                return NotFound("No such user found in the database.");
            }
            List<DigestViewModel> digests = new List<DigestViewModel>();

            List<Subscription> subscriptions = db.Users
                .Include(u => u.Subscriptions)
                .ThenInclude(s => s.Digest)
                .ThenInclude(d=>d.Creator)                   
                .FirstOrDefault(user => user.Id == userId)
                .Subscriptions;

            foreach (Subscription subscription in subscriptions)
            {
               digests.Add(new DigestViewModel(subscription.Digest));
            }

            return Ok(digests);
        }

        // GET: api/users/5/friends
        [HttpGet("{userId}/friends/")]
        public IActionResult GetFriendsByUser(int userId)
        {
            if (!db.Users.Any(u => u.Id == userId))
            {
                return NotFound("No such user found in the database.");
            }

            User user = db.Users.Single(u => u.Id == userId);      
            return Ok(new UserViewModel(user).FriendIds);
        }

        // GET: api/users/5
        [HttpGet("{userId}")]
        public IActionResult GetUserData(int userId)
        {
            if (!db.Users.Any(u => u.Id == userId))
            {
                return NotFound("No such user found in the database.");
            }

            UserViewModel userData = new UserViewModel(
                db.Users
                .FirstOrDefault(u => u.Id == userId));

            return Ok(userData);
        }
    }
}