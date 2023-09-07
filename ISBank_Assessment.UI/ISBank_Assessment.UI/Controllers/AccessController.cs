using ISBank_Assessment.UI.Common;
using ISBank_Assessment.UI.Models;
using ISBank_Assessment.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI;
using WebAPI.Models;

namespace ISBank_Assessment.UI.Controllers
{
    // GET: Access
    [Authorize]
    public partial class AccessController : Controller
    {
        // GET: /AccessRegister
        [AllowAnonymous]
        [HttpGet]
        public virtual ActionResult Register()
        {
            RegisterBindingModel model = new RegisterBindingModel();

            return View(MVC.Access.Views.Register, model);
        }

        //
        // POST: /Access/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(RegisterBindingModel model)
        {
            if (ModelState.IsValid)
            {
                UserEntity user = new UserEntity();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.Email;
                user.EmailAddress = model.Email;

                if (!string.IsNullOrEmpty(model.Password))
                {
                    user.Password = SimpleHash.ComputeHash(model.Password, Algorithm.SHA1, Encoding.UTF8.GetBytes(model.Email.ToLower()));
                }
                user.DateCreated = DateTime.Now;

                Access accountClient = new Access(ServiceFactory.GetClient("Login"));
                await accountClient.AddUserAsync(user);
                return RedirectToAction(MVC.Access.Views.Login);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public virtual async Task<ActionResult> Login()
        {
            LoginViewModel model = new LoginViewModel();
            model.Error = "";

            return View(MVC.Access.Views.Login, model);
        }
      
        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<ActionResult> Login(LoginViewModel model)
        {
            Access accessClient = new Access(ServiceFactory.GetClient("Login"));
            
            if (!ModelState.IsValid)
                return View(model);

            bool authorized = false;

            try
            {
                model.Password = SimpleHash.ComputeHash(model.Password, Algorithm.SHA1, Encoding.UTF8.GetBytes(model.Email.ToLower()));

                //Validating the user, whether the user is valid or not.
                authorized = (bool)accessClient.ValidateUserLogin(model.Email, model.Password);
            }
            catch (Exception e)
            {
                model.Error = e.Message;
                throw (e);
            }

            if (authorized)
            {
                SessionHelper.Set("UserName", model.Email);

                var response = accessClient.GetLoginUser(model.Email);

                SessionHelper.Set("LoggedIn", true);
                SessionHelper.Set("UserId", response.UserId);
                SessionHelper.Set("FirstName", response.FirstName);

                return RedirectToAction(MVC.Person.GetPersons());

            }
            else
            {
                //If the username and password combination is not present in DB then error message is 
                model.Error = "Invalid Login Details";
                return View(model);
            }
        }

        // POST: /User/LogOff
        //LogOff method for the user to end the session
        [AllowAnonymous]
        public virtual ActionResult LogOff()
        {

            SessionHelper.Set("LoggedIn", false);
            Session.Clear();
            return RedirectToAction("Login");
        }


        [AllowAnonymous]
        public virtual JsonResult DoesConfirmPasswordMatch(string ConfirmPassword, string Password)
        {
            if (string.IsNullOrEmpty(ConfirmPassword) && string.IsNullOrEmpty(Password))
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (ConfirmPassword != Password)
                {
                    return Json(Resources.Labels.PasswordDoesNotMatch, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }



        //[HttpGet]
        //[AllowAnonymous]
        //public virtual JsonResult CheckCurrentPassword(string Password, string Email)
        //{
        //    string password = SimpleHash.ComputeHash(Password, Algorithm.SHA1, Encoding.UTF8.GetBytes(Email.ToLower()));
        //    Access accessClient = new Access(ServiceFactory.GetClient());
        //    var checkValidPassword = accessClient.IsValidPasswordAsync(password, Email);
        //    if (checkValidPassword)
        //    {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }

        //    return Json(false, JsonRequestBehavior.AllowGet);
        //}

        ////TODO - Backend Method For Modifying User

        //[HttpPost]
        //[AllowAnonymous]
        //public virtual async Task<ActionResult> SavePassword(string Email, string Password)
        //{
        //    Access accessClient = new Access(ServiceFactory.GetClient());

        //    UserEntity user = await accessClient.GetLoginUserAsync(Email);
        //    user.Password = SimpleHash.ComputeHash(Password, Algorithm.SHA1, Encoding.UTF8.GetBytes(Email.ToLower()));

        //    await accessClient.ModifyUserAsync(user);

        //    var redirectUrl = new UrlHelper(Request.RequestContext).Action("AccessSettings", "Access");
        //    return Json(redirectUrl);
        //}

        [HttpGet]
        [AllowAnonymous]
        public virtual JsonResult ValidatePasswordComplexity(string Password)
        {
            //At least 1 uppercase, 1 lower case, 1 special character, minimum length of 10 characters and maximum lenght of 20 characters
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W)[a-zA-Z0-9\S]{10,20}$");
            Match match = regex.Match(Password);

            if (match.Success)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(Resources.Labels.PasswordValidation, JsonRequestBehavior.AllowGet);
            }
        }


    }
}