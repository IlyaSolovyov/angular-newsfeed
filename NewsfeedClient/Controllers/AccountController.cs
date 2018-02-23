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
    public class AccountController : Controller
    {
        private List<User> Users { get; set; } 

        public AccountController()
        {
            PopulateWithDummyData();           
        }

        private void PopulateWithDummyData()
        {
            Users = new List<User>
            {
                 new User { Id = 1, Username = "Test Account", Email = "test-email@gmail.com", Password = "secret_password" }
        };       
        }

        // POST: api/account/login
        [HttpPost("login")]
        public IActionResult Login([FromForm]User loginData)
        {
            if (!Users.Any(u => u.Email==loginData.Email))
            {
                return NotFound("Email " + loginData.Email + " was not found in the database.");
            }
            User user = Users.Find(u => u.Email == loginData.Email);
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
            return Ok("Account " + registerData.Username + " would have been registered if this was a real database interaction.");
        }

        // POST: api/account/5
        [HttpGet("{userId}")]
        public AccountViewModel GetUserData(int userId)
        {
            AccountViewModel userData = new AccountViewModel(Users
                .Find(u => u.Id == userId));
            return userData;
        }

    }
}