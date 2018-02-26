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
    public class PostsController : Controller
    {
        NewsfeedContext db;

        public PostsController(NewsfeedContext context)
        {
            db = context;
        }
        
        //TODO: Optimize everything with .Include and .ThenInclude somehow.
        // GET: api/posts/digests/5
        [HttpGet("digests/{digestId}")]
        public IActionResult GetPostsByDigest(int digestId)
        {
            if (!db.Digests.Any(d => d.Id == digestId))
            {
                return NotFound("No such digest found in the database.");
            }

            List<DigestSource> digestSources = db.DigestSources
                .Where(ds => ds.DigestId == digestId)
                .ToList();

            List<Source> sources = new List<Source>();
            foreach (DigestSource ds in digestSources)
            {
                sources.Add(ds.Source);
            }

            List<Post> postModels = new List<Post>();
            List<PostViewModel> posts = new List<PostViewModel>();
            foreach (Source source in sources)
            {
                postModels = db.Posts
                    .Where(post => post.SourceId == source.Id)
                    .ToList();
                foreach (Post postModel in postModels)
                {
                    posts.Add(new PostViewModel(postModel, source));
                }
            }

            return Ok(posts
                .OrderByDescending(post => post.TimePosted));
        }

        //TODO: Optimize everything with .Include and .ThenInclude somehow.
        // GET: api/posts/users/5
        [HttpGet("users/{userId}")]
        public IActionResult GetPostsByUser(int userId)
        {
            if (!db.Users.Any(u => u.Id == userId))
            {
                return NotFound("No such duser found in the database.");
            }

            User user = db.Users.FirstOrDefault(u => u.Id == userId);
            List<Digest> digests = new List<Digest>();
            foreach(Subscription subscription in user.Subscriptions)
            {
                digests.Add(subscription.Digest);
            }

            List<Post> postModels = new List<Post>();
            List<PostViewModel> posts = new List<PostViewModel>();
            foreach (Digest digest in digests)
            {
                List<DigestSource> digestSources = db.DigestSources
                    .Where(ds => ds.DigestId == digest.Id)
                    .ToList();

                List<Source> sources = new List<Source>();
                foreach (DigestSource ds in digestSources)
                {
                    sources.Add(ds.Source);
                }

                foreach (Source source in sources)
                {
                    postModels = db.Posts
                        .Where(post => post.SourceId == source.Id)
                        .ToList();
                    foreach (Post postModel in postModels)
                    {
                        posts.Add(new PostViewModel(postModel, source));
                    }
                }
            }

            return Ok(posts
                .OrderByDescending(post => post.TimePosted));
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