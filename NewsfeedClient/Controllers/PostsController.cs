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
    public class PostsController : Controller
    {
        private List<User> Users { get; set; }
        private List<Digest> Digests { get; set; }
        private List<Source> Sources { get; set; }
        private List<Post> Posts { get; set; }

        public PostsController()
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
                

        // GET: api/posts/digests/5
        [HttpGet("digests/{digestId}")]
        public IEnumerable<PostViewModel> GetPostsByDigest(int digestId)
        {
            List<PostViewModel> posts = new List<PostViewModel>();
            List<Post> postModels = new List<Post>();

            List<Source> sources = Digests
                .FirstOrDefault(digest => digest.Id == digestId)
                .Sources
                .ToList();

            foreach(Source source in sources)
            {
                postModels = source.Posts.ToList();
                foreach(Post postModel in postModels)
                {
                    posts.Add(new PostViewModel(postModel, source));
                }
            }

            return posts
                .OrderByDescending(post => post.TimePosted);
        }

        // GET: api/posts/users/5
        [HttpGet("users/{userId}")]
        public IEnumerable<PostViewModel> GetPostsByUser(int userId)
        {
            List<PostViewModel> posts = new List<PostViewModel>();

            List<Digest> digests = Users
                .FirstOrDefault(user => user.Id == userId)
                .Digests
                .ToList();

            foreach (Digest digest in digests)
            {
                foreach (Source source in digest.Sources)
                {
                    foreach(Post postModel in source.Posts)
                    {
                        posts.Add(new PostViewModel(postModel, source));
                    }
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