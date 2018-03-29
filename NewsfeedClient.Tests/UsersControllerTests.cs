using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NewsfeedClient.Controllers;
using NewsfeedClient.DAL;
using NewsfeedClient.Models;
using NewsfeedClient.Tests.Helpers;
using NewsfeedClient.ViewModels;
using NUnit.Framework;

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
                    new User() { Id = 2 },
                    new User() { Id = 3 },
                    new User() { Id = 1, Friendships =
                        {
                            new Friendship { Friend1Id = 1, Friend2Id = 2 },
                            new Friendship { Friend1Id = 1, Friend2Id = 3 }
                        }}
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

            List<Digest> digests = fakeContext.Digests
               .Where(d => d.CreatorId == userId)
               .ToList();

            Assert.That(model.Count == digests.Count());

            foreach(Digest digest in digests)
            {
                Assert.That(model.Any(d => d.Id == digest.Id));
            }   
        }
        #endregion

        #region GetSubscriptionsByUser
        [Test]
        public void GetSubscriptionsByUser_NonExistingUser_ReturnsNotFound()
        {
            //Arrange
            int userId = -1;

            //Act
            IActionResult actionResult = controller.GetSubscriptionsByUser(userId);

            //Assert
            Assert.NotNull(actionResult);
            Assert.That(actionResult, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public void GetSubscriptionsByUser_ExistingUser_ReturnsList()
        {
            //Arrange
            int userId = 1;

            //Act
            IActionResult actionResult = controller.GetSubscriptionsByUser(userId);

            //Assert
            Assert.NotNull(actionResult);

            OkObjectResult okResult = actionResult as OkObjectResult;
            Assert.NotNull(okResult);

            var model = okResult.Value as List<DigestViewModel>;
            Assert.NotNull(model);

            List<Subscription> subscriptions = fakeContext.Users
                .First(u => u.Id == userId)
                .Subscriptions;

            Assert.That(model.Count == subscriptions.Count());

            foreach (Subscription subscription in subscriptions)
            {
                Assert.That(model.Any(d => d.Id == subscription.DigestId));
            }
        }
        #endregion

        #region GetFriendsByUser
        [Test]
        public void GetFriendsByUser_NonExistingUser_ReturnsNotFound()
        {
            //Arrange
            int userId = -1;

            //Act
            IActionResult actionResult = controller.GetFriendsByUser(userId);

            //Assert
            Assert.NotNull(actionResult);
            Assert.That(actionResult, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public void GetFriendsByUser_ExistingUser_ReturnsList()
        {
            //Arrange
            int userId = 1;

            //Act
            IActionResult actionResult = controller.GetFriendsByUser(userId);

            //Assert
            Assert.NotNull(actionResult);

            OkObjectResult okResult = actionResult as OkObjectResult;
            Assert.NotNull(okResult);

            var model = okResult.Value as List<int>;
            Assert.NotNull(model);

            List<Friendship> friendships = fakeContext.Users
                .First(u => u.Id == userId)
                .Friendships;

            Assert.That(model.Count == friendships.Count());

            foreach (Friendship friendship in friendships)
            {
                Assert.That(model.Any(id => id == friendship.Friend1Id || id == friendship.Friend2Id));
            }
        }
        #endregion

        #region GetUserData
        [Test]
        public void GetUserData_NonExistingUser_ReturnsNotFound()
        {
            //Arrange
            int userId = -1;

            //Act
            IActionResult actionResult = controller.GetUserData(userId);

            //Assert
            Assert.NotNull(actionResult);
            Assert.That(actionResult, Is.InstanceOf<NotFoundObjectResult>());
        }

        [Test]
        public void GetUserData_ExistingUser_ReturnsObject()
        {
            //Arrange
            int userId = 1;

            //Act
            IActionResult actionResult = controller.GetUserData(userId);

            //Assert
            Assert.NotNull(actionResult);

            OkObjectResult okResult = actionResult as OkObjectResult;
            Assert.NotNull(okResult);

            var model = okResult.Value as UserViewModel;
            Assert.NotNull(model);

            Assert.That(model.Id == fakeContext.Users.First(u => u.Id == userId).Id);   
        }
        #endregion
    }
}
