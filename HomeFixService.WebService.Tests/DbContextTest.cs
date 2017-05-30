using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Persistence.Implementations;

namespace HomeFixService.WebService.Tests
{
    [TestClass]
    public class DbContextTest
    {
        [TestMethod]
        public void DbExecutionTest()
        {
            using (var db = new DatabaseContext())
            {
                Users user = new Users
                {
                    UserFirstName = "Gjorche",
                    UserLastName = "Cekovski"
                };
                db.Users.Add(user);
                db.SaveChanges();

                Assert.AreNotEqual(0, user.Id);

                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void RepositoryTest()
        {
            CrudRepository<Users> userRepo = new CrudRepository<Users>();
            Users user1 = new Users { UserFirstName = "Test", UserLastName = "Test" };
            userRepo.Add(user1);

            Assert.AreNotEqual(0, user1.Id);

            int id = user1.Id;
            userRepo.Remove(user1);

            Users user2 = userRepo.FindById(id);

            Assert.AreEqual(null, user2);
        }
    }
}
