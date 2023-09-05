using ISBank_Assessment.UI.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISBank_Assessment.UI.Models
{

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ResetPasswordModel
    {
        [Display(Name = "Email", ResourceType = typeof(Labels))]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(Labels))]
        [Remote("IsUsedPasswordForUser", "Account", AdditionalFields = "Email")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Labels))]
        [Remote("DoesConfirmPasswordMatch", "Account", AdditionalFields = "Password")]
        public string ConfirmPassword { get; set; }

        public bool IsExpired { get; set; }

        public string Message { get; set; }
    }

    public class ForgotPasswordConfirmationModel
    {
        public string Message { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [StringLength(100)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        //[Remote("IsActiveUser", "Access")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        [Display(Name = "Password")]
        [Remote("ValidatePasswordComplexity", "Access")]
        public string Password { get; set; }

        [Display(Name = "Version")]
        public string Version { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }

        public string Error { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Username")]
        [Remote("CheckExistingEmail", "Access")]
        public string Username { get; set; }

        public string Error { get; set; }
    }

    public class AccessSettingsModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        public int PasswordExpiryDays { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public int UserType { get; set; }

        public string PasswordExpiryMessage { get; set; }
    }

}