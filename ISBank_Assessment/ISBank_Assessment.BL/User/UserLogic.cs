using ISBank_Assessment.BE;
using ISBank_Assessment.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Security;
using AutoMapper;

namespace ISBank_Assessment.BL
{
    public class UserLogic : IUserLogic
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private GenericRepository<User> userRepository;

        public UserLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            userRepository = unitOfWork.GetRepository<User>();  
        }

        public UserLogic(IUnitOfWork unitOfWork, IMapper Mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = Mapper;
            userRepository = unitOfWork.GetRepository<User>();

        }

        #region Read
        public User GetLoginUser(string UserName)
        {
            #region Validation

            //throw new NotSupportedException();

            #endregion Validation

            UserName = UserName.ToLower();

            return userRepository.GetAll().Where(x => x.UserName.ToLower() == UserName).FirstOrDefault();
        }

        public User GetUserByUserId(int UserId)
        {

            return userRepository.GetByID(UserId);
        }

        public int GetUserIdByUsername(string UserName)
        {
            #region Validation

            if (string.IsNullOrEmpty(UserName))
            {
                //TODO - BE.Resources.ErrorValidation.Validation.InvalidUserName
                throw new ValidationException(string.Format("Invalid User Name", UserName));
            }

            #endregion Validation

            return userRepository.Get(x => x.UserName == UserName).SingleOrDefault().UserId;
        }

        #endregion

        #region Modify
        //Create Login User
        public User CreateLoginUser(UserEntity UserObj, int CreatedBy)
        {
            var userToAdd = _mapper.Map<User>(UserObj);
            #region Validation

            IsValidUser(userToAdd);

            #endregion Validation

            try
            {

                var User = userRepository.Insert(userToAdd);
                unitOfWork.Save();

            }
            catch (Exception e)
            {
                //could not create user
                var error = e.Message;
                throw new ValidationException(string.Format(error));
            }

            return userToAdd;
        }

        //Modifies LoggedIn User
        public User UpdateLoginUser(User UserObj)
        {

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                #region Validation

                if (!CheckUserExists(UserObj.UserName))
                {
                    throw new ValidationException(string.Format("User Does Not Exist", UserObj.UserName));
                }

                #endregion Validation
                var userCheck = GetLoginUser(UserObj.UserName);
                var user = userRepository.Get(x => x.UserId == userCheck.UserId).FirstOrDefault();

                #region User Object

                user.UserName = UserObj.UserName;
                user.FirstName = UserObj.FirstName;
                user.LastName = UserObj.LastName;
                user.EmailAddress = UserObj.EmailAddress;
                if (UserObj.Password != null)
                {
                    user.Password = UserObj.Password;
                }
                #endregion User Object

                userRepository.Update(user);
                unitOfWork.Save();
                ts.Complete();


                return user;

            }


        }

        public int UpdateLoginCount(string Username)
        {
            var user = GetLoginUser(Username);
            user.LoginCount += 1;
            user.LastLogin = DateTime.Now;
            UpdateLoginUser(user);

            return user.LoginCount.Value;
        }


        #endregion Modify

        #region Validation

        public void IsValidUser(User UserObj)
        {
            //Check userName already exist
            var User = userRepository.GetAll().Where(x => x.UserName == UserObj.UserName).SingleOrDefault();

            if (User != null)
            {
                throw new ValidationException(string.Format("UserName already exist", UserObj.UserName));
            }

            //UserName
            if (string.IsNullOrEmpty(UserObj.UserName) || UserObj.UserName.Length > 255)
            {
                throw new ValidationException(string.Format("Invalid UserName", UserObj.UserName));
            }

            //Email
            if (string.IsNullOrEmpty(UserObj.EmailAddress) || UserObj.EmailAddress.Length > 100)
            {
                throw new ValidationException(string.Format("Invalid EmailAddress", UserObj.EmailAddress));
            }

            //FirstName
            if (string.IsNullOrEmpty(UserObj.FirstName) || UserObj.FirstName.Length > 50)
            {
                throw new ValidationException(string.Format("Invalid First Name", UserObj.FirstName));
            }

            //LastName
            if (string.IsNullOrEmpty(UserObj.LastName) || UserObj.LastName.Length > 50)
            {
                throw new ValidationException(string.Format("Invalid Last Name", UserObj.LastName));
            }


        }

        public bool ValidateUser(string username, string password)
        {
            // Validate arguments            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || username.Length > 255)
            {
                return false;
            }

            username = username.ToLower().Trim();

            var user = GetLoginUser(username);

            var pwd = string.Empty;

            if (user != null)
            {
                pwd = user.Password;
            }
            else
            {
                return false;
            }
            // Check if password exists
            if (string.IsNullOrEmpty(pwd))
            {
                return false;
            }

            // Validate password         
            var ComputeHash = password;//SimpleHash.ComputeHash(password, Algorithm.SHA1, Encoding.UTF8.GetBytes(username));

            if (string.Equals(pwd.Trim(), ComputeHash.Trim()))
            {
                return true;
            }
            else
            {
                //Logger.Write(string.Format("Failed to login with ({0})({1})", username, password), "Login"); //TODO 
                return false;
            }

        }

        public bool ValidateUserLogin(string UserName, string password)
        {
            User user;
            try
            {
                user = GetLoginUser(UserName);

            }
            catch (Exception e)
            {
                throw e;
            }

            if (user == null)
            {
                return false;
            }

            if (ValidateUser(UserName, password))
            {
                return true;
            }
            else
            {
                UpdateLoginUser(user);
                return false;
            }
        }

        public bool CheckUserExists(string UserName)
        {
            var user = userRepository.GetAll().Where(x => x.UserName.ToLower() == UserName.ToLower()).FirstOrDefault();

            if (user != null)
            {
                return true;
            }

            return false;
        }

        public bool IsValidConfirmPassword(string Password, string ConfirmPassword)
        {
            if (Password == ConfirmPassword)
            {
                return true;
            }
            else
            {
                throw new ValidationException("Password Does Not Match");
            }
        }

        public bool IsValidPassword(string Password, string Email)
        {
            var user = GetLoginUser(Email);
            if (user != null)
            {
                if (Password == user.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ValidationException("User Does Not Exist");
            }
        }
        #endregion
    }
}
