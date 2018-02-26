using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsfeedClient.DAL;
using NewsfeedClient.Models;
using NewsfeedClient.ViewModels;

namespace NewsfeedClient.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DigestsController : Controller
    {
        NewsfeedContext db;   

        public DigestsController(NewsfeedContext context)
        {
            db = context;
        }

        // GET: api/digests/5
        [HttpGet("{digestId}")]
        public IActionResult GetDigestData(int digestId)
        {
            if (!db.Digests.Any(d=> d.Id == digestId))
            {
                return NotFound("No such digest found in the database.");
            }

            Digest digest = db.Digests
                .FirstOrDefault(d => d.Id == digestId);

            return Ok(new DigestViewModel(digest))  ;
        }

        // POST: api/digests/
        [HttpPost]
        public IActionResult CreateNewDigest([FromForm]Digest digest)
        {
            db.Digests.Add(digest);
            if (db.SaveChanges() != 1)
            {
                return BadRequest("Something wrong with the database. Please try again in a moment.");
            }

            return Ok("Digest " + digest.Name + "is successfully created.");
        }

        // DELETE: api/digests/5
        [HttpDelete("{digestId}")]
        public IActionResult RemoveDigest(int digestId)
        {
            if (!db.Digests.Any(d => d.Id == digestId))
            {
                return NotFound("Digest #" + digestId + " was not found in the database.");
            }
            Digest digest = db.Digests.FirstOrDefault(d => d.Id == digestId);
            if (false) //unable to check without account system
            {
                return NotFound("You're not able to delete digest " + digest.Name + "because you are not its creator.");
            }
            db.Entry<Digest>(digest).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();

            return Ok("Digest " + digest.Name + " is successfully deleted.");
        }

        // PUT: api/digests/5
        [HttpPut("{digestId}")]
        public IActionResult UpdateDigest([FromForm]Digest updatedDigest, int digestId)
        {
            if (!db.Digests.Any(d => d.Id == digestId))
            {
                return NotFound("Digest #" + digestId + " was not found in the database.");
            }
            Digest digest = db.Digests.FirstOrDefault(d => d.Id == digestId);
            digest = updatedDigest;
            db.Digests.Update(digest);
            db.SaveChanges();
            return Ok("Digest " + digest.Name + " would have been updated if this was a real database interaction.");
        }

    }
}