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
        // GET: api/posts
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return new Post[] { new Post{ Id = 1, TimePosted = DateTime.Now, Source = Source.VK.ToString(), Author = "John Smith", Content = "Some content 1" },
                                new Post{ Id = 2, TimePosted = DateTime.Now, Source = Source.Twitter.ToString(), Author = "Amy Smith", Content = "Some content 2" },
                                new Post{ Id = 3, TimePosted = DateTime.Now, Source = Source.VK.ToString(), Author = "Brian Smith", Content = "Some content 3" }};
        }

        // GET: api/posts/5
        [HttpGet("{id}", Name = "Get")]
        public Post Get(int id)
        {
            return new Post { Id = id, TimePosted = DateTime.Now, Source = Source.VK.ToString(), Author = "John Smith", Content = "Some content" };
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