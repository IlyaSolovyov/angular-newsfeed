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
        private User TestUserModel { get; set; } 
        private AccountViewModel TestUser { get; set; } 

        public AccountController()
        {
            PopulateWithDummyData();           
        }

        private void PopulateWithDummyData()
        {
            TestUserModel = new User { Id = 1, Username = "Test Account", Email = "test-email@gmail.com", Password = "secret_password" };
            TestUser = new AccountViewModel(TestUserModel);
        }

        // POST: api/account/login
        [HttpPost("login")]
        public IActionResult Login([FromForm]AccountViewModel loginData)
        {
            if (loginData.Email != TestUser.Email)
            {
                return NotFound("Email " + loginData.Email + " was not found in the database.");
            }
            if (loginData.Password != TestUser.Password)
            {
                return NotFound("Incorrect password");
            }
            return Ok(TestUser.Username);
        }

        // POST: api/account/register
        [HttpPost("register")]
        public IActionResult Register([FromForm]AccountViewModel registerData)
        {

            return Ok("Account " + registerData.Username + " would have been registered if this was a real database interaction.");
        }
    }
}