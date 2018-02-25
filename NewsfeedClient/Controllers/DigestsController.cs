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
    public class DigestsController : Controller
    {

        private List<User> Users { get; set; }
        private List<Digest> Digests { get; set; }
        private List<Source> Sources { get; set; }
        private List<Post> Posts { get; set; }

        public DigestsController()
        {
            PopulateWithDummyData();
        }

        private void PopulateWithDummyData()
        {
            Posts = new List<Post>
            {
                new Post { Id = 1, Content = "Post number 1 via VK", TimePosted = DateTime.Now },
                new Post { Id = 2, Content = "Post number 2 via VK", TimePosted = DateTime.Now.AddHours(-2) },
                new Post { Id = 3, Content = "Post number 3 via Twitter", TimePosted = DateTime.Now.AddHours(3) },
                new Post { Id = 4, Content = "Post number 4 via Twitter", TimePosted = DateTime.Now.AddMinutes(-22) },
                new Post { Id = 5, Content = "Post number 5 via VK", TimePosted = DateTime.Now.AddMinutes(55) }
            };

            Sources = new List<Source>
            {
                new Source {Id = 1, Name = "VK Public Page #1", Service = "VK", Posts = Posts.GetRange(0, 2), Url="team" },
                new Source {Id = 2, Name = "Twitter Page #1", Service = "Twitter", Posts = Posts.GetRange(2, 2), Url="twitter" },
                new Source {Id = 3, Name = "VK Public Page #2",    Service = "VK", Posts = Posts.GetRange(4, 1), Url="adsnews" }
            };

            Digests = new List<Digest>
            {
                new Digest {Id = 1, Name = "Football", IsPublic = true, Sources = Sources.GetRange(0,1) },
                new Digest {Id = 2, Name = "Angular", IsPublic = true, Sources = Sources.GetRange(1,2) },
            };

            Users = new List<User>
            {
                 new User { Id = 1, Digests = Digests }
            };
        }

        // GET: api/digests/5
        [HttpGet("{digestId}")]
        public DigestViewModel GetDigestData(int digestId)
        {
            Digest digest = new Digest();
            if (Digests.Any(d => d.Id == digestId))
            {
                digest = Digests
                .FirstOrDefault(d => d.Id == digestId);
            }

            return new DigestViewModel(digest);
        }

        // POST: api/digests/
        [HttpPost]
        public IActionResult CreateNewDigest([FromForm]Digest digest)
        {
            return Ok("Digest " + digest.Name + " would have been created if this was a real database interaction.");
        }

        // DELETE: api/digests/5
        [HttpDelete("{digestId}")]
        public IActionResult RemoveDigest(int digestId)
        {
            if (!Digests.Any(d => d.Id == digestId))
            {
                return NotFound("Digest #" + digestId + " was not found in the database.");
            }
            Digest digest = Digests.FirstOrDefault(d => d.Id == digestId);
            if (false) //unable to check without account system
            {
                return NotFound("You're not able to delete digest " + digest.Name + "because you are not its creator.");
            }
            return Ok("Digest " + digest.Name + " would have been deleted if this was a real database interaction.");
        }

        // PUT: api/digests/5
        [HttpPut("{digestId}")]
        public IActionResult UpdateDigest([FromForm]Digest updatedDigest, int digestId)
        {
            if (!Digests.Any(d => d.Id == digestId))
            {
                return NotFound("Digest #" + digestId + " was not found in the database.");
            }
            Digest digest = Digests.FirstOrDefault(d => d.Id == digestId);
            digest = updatedDigest;
            return Ok("Digest " + digest.Name + " would have been updated if this was a real database interaction.");
        }

    }
}