using ISBank_Assessment.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BL
{
    public interface IUserLogic
    {

        #region Modify 

        User CreateLoginUser(UserEntity UserObj, int CreatedBy);

        User UpdateLoginUser(User UserObj);

        int UpdateLoginCount(string Username);

        #endregion Modify

        #region Read


        User GetLoginUser(string UserName);

        User GetUserByUserId(int UserId);

        int GetUserIdByUsername(string UserName);
        #endregion Read

        #region Validation

        void IsValidUser(User UserObj);

        bool ValidateUser(string username, string password);

        bool ValidateUserLogin(string UserName, string password);

        bool CheckUserExists(string UserName);

        bool IsValidPassword(string Password, string Email);

        #endregion Validation
    }
}
