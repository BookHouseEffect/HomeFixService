using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;

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
    }
}
