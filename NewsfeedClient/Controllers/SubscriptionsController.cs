using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsfeedClient.DAL;
using NewsfeedClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class SubscriptionsController : Controller
    {  //everything will come from JWT token in request header so logic is a little different
        NewsfeedContext db;

        public SubscriptionsController(NewsfeedContext context)
        {
            db = context;
        }

        // POST: api/subscriptions/5/digests/4
        [HttpPost("{userId}/digests/{digestId}")]
        public IActionResult SubscribeUserToDigest(int userId, int digestId)
        {
            if(false) //no way to check for accounts yet
            {
                return Unauthorized();
            }

            if (!db.Users.Any(u => u.Id == userId))
            {
                return NotFound("No such user found in the database.");
            }

            if (!db.Digests.Any(d => d.Id == digestId))
            {
                return NotFound("No such digest found in the database.");
            }

            Digest digest = db.Digests.FirstOrDefault(d => d.Id == digestId);
            if (!digest.IsPublic)
            {
                return BadRequest("Specified digest is private.");
            }

            if (db.Subscriptions.Any(s => s.DigestId==digestId && s.UserId==userId))
            {
                return BadRequest("You are already subscribed to specified digest.");
            }

            db.Subscriptions.Add(new Subscription { UserId = userId, DigestId = digestId });
            db.SaveChanges();
            return Ok("Successfully subscribed to " + digest.Name + "." );
        }

        // DELETE: api/subscriptions/5/digests/4
        [HttpDelete("{userId}/digests/{digestId}")]
        public IActionResult UnsubscribeUserFromDigest(int userId, int digestId)
        {
            if (false) //no way to check for accounts yet
            {
                return Unauthorized();
            }

            if (!db.Users.Any(u => u.Id == userId))
            {
                return NotFound("No such user found in the database.");
            }

            if (!db.Digests.Any(d => d.Id == digestId))
            {
                return NotFound("No such digest found in the database.");
            }

            if (!db.Subscriptions.Any(s => s.DigestId == digestId && s.UserId == userId))
            {
                return BadRequest("You aren't subscribed to specified digest.");
            }

            Subscription subscription = db.Subscriptions
                .Include(s=>s.Digest)
                .FirstOrDefault(s => s.DigestId == digestId && s.UserId == userId);

            db.Entry<Subscription>(subscription).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();

            return Ok("Succesfully unsubscribed from " + subscription.Digest.Name + ".");
        }

    }
}
