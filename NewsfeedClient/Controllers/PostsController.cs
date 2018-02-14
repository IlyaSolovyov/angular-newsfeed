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
    public class PostsController : Controller
    {
        private List<User> TestUsers { get; set; }
        private List<Digest> TestDigests { get; set; }
        private List<Source> TestSources { get; set; }
        private List<Post> TestPosts { get; set; }

        public PostsController()
        {
            PopulateWithDummyData();
        }

        private void PopulateWithDummyData()
        {
            TestPosts = new List<Post>
            {
                new Post { Id = 1, Content = "Post number 1 via VK", TimePosted = DateTime.Now },
                new Post { Id = 2, Content = "Post number 2 via VK", TimePosted = DateTime.Now.AddHours(-2) },
                new Post { Id = 3, Content = "Post number 3 via Twitter", TimePosted = DateTime.Now.AddHours(3) },
                new Post { Id = 4, Content = "Post number 4 via Twitter", TimePosted = DateTime.Now.AddMinutes(-22) },
                new Post { Id = 5, Content = "Post number 5 via VK", TimePosted = DateTime.Now.AddMinutes(55) }
            };

            TestSources = new List<Source>
            {
                new Source {Id = 1, Name = "VK Public Page #1", Service = "VK", Posts = TestPosts.GetRange(0, 2) },
                new Source {Id = 2, Name = "Twitter Page #1", Service = "Twitter", Posts = TestPosts.GetRange(2, 2) },
                new Source {Id = 3, Name = "VK Public Page #2",    Service = "VK", Posts = TestPosts.GetRange(4, 1) }
            };

            TestDigests = new List<Digest>
            {
                new Digest {Id = 1, Name = "Football", Public = true, Sources = TestSources.GetRange(0,1) },
                new Digest {Id = 2, Name = "Angular", Public = true, Sources = TestSources.GetRange(1,2) },
            };

            TestUsers = new List<User>
            {
                 new User { Id = 1, Digests = TestDigests }
            };
        }
                

        // GET: api/posts/digests/5
        [HttpGet("posts/digests/{digestId}")]
        public IEnumerable<Post> GetPostsByDigest(int digestId)
        {
            List<Post> posts = new List<Post>();

            List<Source> sources = TestDigests
                .FirstOrDefault(digest => digest.Id == digestId)
                .Sources
                .ToList();

            foreach(Source source in sources)
            {
                posts.AddRange(source.Posts);
            }

            return posts
                .OrderByDescending(post => post.TimePosted);
        }

        // GET: api/posts/users/5
        [HttpGet("posts/users/{userId}")]
        public IEnumerable<Post> GetPostsByUser(int userId)
        {
            List<Post> posts = new List<Post>();

            List<Digest> digests = TestUsers
                .FirstOrDefault(user => user.Id == userId)
                .Digests
                .ToList();

            foreach (Digest digest in digests)
            {
                foreach (Source source in digest.Sources)
                {
                    posts.AddRange(source.Posts);
                }
            }

            return posts
                .OrderByDescending(post => post.TimePosted);
        }

        // POST: api/posts
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return Ok("POST method working");
        }

        // PUT: api/posts/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok("PUT method working");
        }

        // DELETE: api/posts/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok("DELETE method working");
        }
    }
}