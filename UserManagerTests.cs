using Moq;

namespace Practice
{
    internal class UserManagerTests
    {
        private UserManager userManager;
        private Mock<IDbContext> mockDbContext;

        [SetUp]
        public void SetUp()
        {
            mockDbContext = new Mock<IDbContext>();
            userManager = new UserManager(mockDbContext.Object);
        }

        // User valid name, invalid name
        // Insert -> true, false

        [Test]
        public void TestThatWithValidNameAndWorkingDatabaseUserRegistered()
        {
            var user = new User() { Name = "John Doe" };
            // Azt szimulálja hogy működik a kamuadatbázis
            mockDbContext.Setup(x => x.Insert(user)).Returns(true);
            userManager.RegisterUser(user);

            // Assert -> ez már egy teszt eredmény
            mockDbContext.Verify(x => x.Insert(user), Times.Once);
            mockDbContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [Test]
        public void TestThatWithInvalidNameAndWorkingDatabaseUserNotRegistered()
        {
            var user = new User() { Name = "Jo" };
            mockDbContext.Setup(x => x.Insert(user)).Returns(true);
            userManager.RegisterUser(user);
            mockDbContext.Verify(x => x.Insert(user), Times.Never);
            mockDbContext.Verify(x => x.SaveChanges(), Times.Never);
        }

        [Test]
        public void TestThatWithValidNameAndNotWorkingDatabaseUserNotRegistered()
        {
            var user = new User() { Name = "John Doe" };
            mockDbContext.Setup(x => x.Insert(user)).Returns(false);
            userManager.RegisterUser(user);
            mockDbContext.Verify(x => x.Insert(user), Times.Once);
            mockDbContext.Verify(x => x.SaveChanges(), Times.Never);
        }

        [Test]
        public void TestThatWithInvalidNameAndNotWorkingDatabaseUserNotRegistered()
        {
            var user = new User() { Name = "Jo" };
            mockDbContext.Setup(x => x.Insert(user)).Returns(false);
            userManager.RegisterUser(user);
            mockDbContext.Verify(x => x.Insert(user), Times.Never);
            mockDbContext.Verify(x => x.SaveChanges(), Times.Never);
        }
    }
}
