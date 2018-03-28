using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NewsfeedClient.Controllers;
using NewsfeedClient.DAL;
using NewsfeedClient.Models;
using NewsfeedClient.Tests.Helpers;
using NewsfeedClient.ViewModels;
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
        NewsfeedContext fakeContext;
        UsersController controller;

        [SetUp]
        public void MockControllerSetUp()
        {
            var optionsBuilder = new DbContextOptionsBuilder<NewsfeedContext>();
            optionsBuilder.UseInMemoryDatabase("fakeDb");
            fakeContext = new NewsfeedContext(optionsBuilder.Options);

            fakeContext.Users=DbContextHelper.GetQueryableMockDbSet
                (
                    new User() { Id = 1 },
                    new User() { Id = 2 },
                    new User() { Id = 3 }
                );

            fakeContext.Digests = DbContextHelper.GetQueryableMockDbSet
                (
                    new Digest() { Id = 1, CreatorId = 1},
                    new Digest() { Id = 2, CreatorId = 1 },
                    new Digest() { Id = 3, CreatorId = 2 }
                );

            controller = new UsersController(fakeContext);        
        }

        #region GetDigestsByUser
        [Test]
        public void GetDigestsByUser_NonExistingUser_ReturnsNotFound()
        {
            //Arrange
            int userId = -1;

            //Act
            IActionResult actionResult = controller.GetDigestsByUser(userId);

            //Assert
            Assert.NotNull(actionResult);
            Assert.That(actionResult, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public void GetDigestsByUser_ExistingUser_ReturnsList()
        {
            //Arrange
            int userId = 1;

            //Act
            IActionResult actionResult = controller.GetDigestsByUser(userId);

            //Assert
            Assert.NotNull(actionResult);

            OkObjectResult okResult = actionResult as OkObjectResult;
            Assert.NotNull(okResult);

            var model = okResult.Value as List<DigestViewModel>;
            Assert.NotNull(model);

            Assert.That(model.Count == fakeContext.Digests.Where(d => d.CreatorId == userId).Count());

            foreach(DigestViewModel digest in model)
            {
                Assert.That(fakeContext.Users.Any(d => d.Id == digest.Id));
            }   
        }
        #endregion

    }
}
