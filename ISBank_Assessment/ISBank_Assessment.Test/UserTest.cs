using ISBank_Assessment.BE;
using ISBank_Assessment.BL;
using ISBank_Assessment.DL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace ISBank_Assessment.Test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void CreateLoginUser()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            UserLogic userLogic = new UserLogic(unitOfWork);
            UserEntity user = new UserEntity();
            user.UserName = "sithembisopgoqo@gmail.com";
            var pass = "Sithembiso@55";
            if (!string.IsNullOrEmpty(pass))
            {
                user.Password = SimpleHash.ComputeHash(pass, Algorithm.SHA1, Encoding.UTF8.GetBytes(user.UserName.ToLower()));
            }

            user.FirstName = "Sithembiso";
            user.LastName = "Goqo";
            user.EmailAddress = user.UserName;

            var userCreated = userLogic.CreateLoginUser(user,1);

        }

        [TestMethod]
        public void UpdateLoginUser()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            UserLogic userLogic = new UserLogic(unitOfWork);
            User user = new User();
            user.UserName = "sithembisopgoqo@gmail.com";
            var pass = "Sithembiso@@@77";
            if (!string.IsNullOrEmpty(pass))
            {
                user.Password = SimpleHash.ComputeHash(pass, Algorithm.SHA1, Encoding.UTF8.GetBytes(user.UserName.ToLower()));
            }

            user.FirstName = "Sithembiso";
            user.LastName = "Goqo";
            user.EmailAddress = user.UserName;
            var userModified = userLogic.UpdateLoginUser(user);

        }

        [TestMethod]
        public void GetUserByUserName()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));
         
            UserLogic userLogic = new UserLogic(unitOfWork);

            var user= userLogic.GetLoginUser("sithembisopgoqo@gmail.com");
         
        }
    }
}
