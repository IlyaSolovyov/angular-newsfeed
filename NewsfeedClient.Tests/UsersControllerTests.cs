using Microsoft.EntityFrameworkCore;
using Moq;
using NewsfeedClient.Controllers;
using NewsfeedClient.DAL;
using NewsfeedClient.Models;
using NewsfeedClient.Tests.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsfeedClient.Tests
{
    [TestFixture]
    public class UsersControllerTests
    {
        UsersController controller;

        [SetUp]
        public void MockControllerSetUp()
        {
            var optionsBuilder = new DbContextOptionsBuilder<NewsfeedContext>();
            optionsBuilder.UseInMemoryDatabase("fakeDb");
            var fakeContext = new NewsfeedContext(optionsBuilder.Options);

            fakeContext.Users=DbContextHelper.GetQueryableMockDbSet
                (
                    new User() { Id = 1 },
                    new User() { Id = 2 },
                    new User() { Id = 3 }
                );

            controller = new UsersController(fakeContext);        
        }
    
    }
}
