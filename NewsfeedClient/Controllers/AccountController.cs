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
    public class AccountController : Controller
    {
        NewsfeedContext db;

        public AccountController(NewsfeedContext context)
        {
            db = context;         
        }

        // POST: api/account/login
        [HttpPost("login")]
        public IActionResult Login([FromForm]User loginData)
        {
            if (!db.Users.Any(u => u.Email==loginData.Email))
            {
                return NotFound("Email " + loginData.Email + " was not found in the database.");
            }

            User user = db.Users
                .FirstOrDefault(u => u.Email == loginData.Email);

            if (loginData.Password != user.Password)
            {
                return NotFound("Incorrect password");
            }
            return Ok(user.Id);
        }

        // POST: api/account/register
        [HttpPost("register")]
        public IActionResult Register([FromForm]User registerData)
        {
            if (db.Users.Any(u => u.Email == registerData.Email))
            {
                ModelState.AddModelError("Email", "User with such E-Mail has already been registered.");
            }
            if (db.Users.Any(u => u.Username == registerData.Username))
            {
                ModelState.AddModelError("Username", "Username is already taken.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(registerData);
            if (db.SaveChanges() != 1)
            {
                return BadRequest("Something wrong with the database. Please try again in a moment.");
            }
            
            return Ok("Account " + registerData.Username + "is successfully registered.");
        }

        // POST: api/account/5
        [HttpGet("{userId}")]
        public IActionResult GetUserData(int userId)
        {
            if (!db.Users.Any(u => u.Id ==  userId))
            {
                return NotFound("No such user found in the database.");
            }

            AccountViewModel userData = new AccountViewModel(
                db.Users
                .FirstOrDefault(u => u.Id == userId));

            return Ok(userData);
        }

    }
}