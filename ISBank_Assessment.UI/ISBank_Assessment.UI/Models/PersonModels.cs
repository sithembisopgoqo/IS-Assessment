using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace ISBank_Assessment.UI.Models
{
    #region Person 
    public class GetPersonViewModel
    {
        public IEnumerable<PersonEntity> PersonList { get; set; }
        /// </summary>
        [DisplayName("User")]
        public int? UserId { get; set; }

        /// <summary>
        /// </summary>
   
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("ID Number")]
        public string IDNumber { get; set; }
        public string SearchText { get; set; }
    }

    public class EditPersonModel
    {
        
        public int Code { get; set; }
        public int? UserId { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Surname { get; set; }

        [Display(Name = "ID Number")]
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string IDNumber { get; set; }

        public IList<AccountEntity> AccountList { get; set; }

        //Creating DataTable will remove this properties from this model
        [Display(Name = "Person Code")]
        public int? PersonCode { get; set; }

        [Display(Name = "Account Number")]
        [Remote("CheckIfAccountIsClosed","Person")]
        public string AccountNumber { get; set; }

        [Display(Name = "Outstanding Balance")]
        public double? OutstandingBalance { get; set; }

        [Display(Name = "Status")]
        public int? StatusId { get; set; }

    }
    #endregion Person 
}