using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ISBank_Assessment.Models
{
    /// <summary>
    /// LoginUserBindingModel
    /// </summary>
    public class LoginUserBindingModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }

    /// <summary>
    /// RegisterBindingModel
    /// </summary>
    public class RegisterBindingModel
    {
        /// <summary>
        /// Email address of the user registering
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Password for the registering user
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Confirmation password for the registering user
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

}