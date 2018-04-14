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
                .Include(d=> d.DigestSources)
                .ThenInclude(ds=>ds.Source)
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
                return StatusCode(503,"Something wrong with the database. Please try again in a moment.");
            }
            db.Subscriptions.Add(new Subscription { DigestId = digest.Id, UserId = digest.CreatorId });
            db.SaveChanges();
            return Ok("Digest " + digest.Name + "is successfully created.");
        }

        // POST: api/digests/5/sources
        [HttpPost("{digestId}/sources")]
        public IActionResult AddSource([FromForm]Source sourceData, int digestId)
        {        
            if (!db.Digests.Any(d => d.Id == digestId))
            {
                return NotFound("No such digest found in the database.");
            }
            Digest digest = db.Digests.FirstOrDefault(d => d.Id == digestId);

            if (false) //unable to check without account system
            {
                return BadRequest("You're not able to add source to " + digest.Name + " because you are not its creator.");
            }

            if (!db.Sources.Any(s => s.Service==sourceData.Service && s.Url==sourceData.Url))
            {
                db.Sources.Add(sourceData);
                db.SaveChanges();   
            }
            int sourceId = db.Sources
                .FirstOrDefault(s => s.Service == sourceData.Service && s.Url == sourceData.Url)
                .Id;

            if (db.DigestSources.Any(ds => ds.DigestId == digestId && ds.SourceId == sourceId))
            {
                return StatusCode(409, "This digest already contains this source.");
            }

            db.DigestSources.Add(new DigestSource { DigestId = digest.Id, SourceId = sourceId });
            db.SaveChanges();
            return Ok("Source " + sourceData.Name + " is successfully added to " + digest.Name + " digest.");
        }

        // DELETE: api/digests/5/sources/4
        [HttpDelete("{digestId}/sources/{sourceId}")]
        public IActionResult RemoveSource(int digestId, int sourceId)
        {
            if (!db.Digests.Any(d => d.Id == digestId))
            {
                return NotFound("No such digest found in the database.");
            }

            if (!db.Sources.Any(s => s.Id == sourceId))
            {
                return NotFound("No such source found in the database.");
            }

            if (false) //unable to check without account system
            {
                return BadRequest("You're not able to edit this digest because you are not its creator.");
            }

            if (!db.DigestSources.Any(ds => ds.DigestId == digestId && ds.SourceId == sourceId))
            {
                return StatusCode(409,"This digest already doesn't contain this source.");
            }

           DigestSource digestSource = db.DigestSources
                    .Include(ds => ds.Digest)
                    .Include(ds => ds.Source)
                    .FirstOrDefault(ds => ds.DigestId == digestId && ds.SourceId == sourceId);

            db.Entry<DigestSource>(digestSource).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            db.SaveChanges();

            if (!db.DigestSources.Any(s => s.SourceId==sourceId))
            {
                db.Entry<Source>(digestSource.Source).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
            }

            return Ok("Succesfully removed " + digestSource.Source.Name + " from " + digestSource.Digest.Name + ".");
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

            db.Subscriptions.RemoveRange
                (db.Subscriptions              
                .Where(s => s.DigestId == digestId)
                );
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
            digest.Name = updatedDigest.Name;
            digest.IsPublic = updatedDigest.IsPublic;
            db.Digests.Update(digest);
            db.SaveChanges();
            return Ok("Digest " + digest.Name + " is succesfully updated.");
        }

    }
}