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
            throw new NotImplementedException();
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