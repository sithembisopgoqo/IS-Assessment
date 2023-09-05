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
    #region Accounts 
    public class GetAccountViewModel
    {
        public IList<AccountEntity> AccountList { get; set; }
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Person Code")]
        public int PersonCode { get; set; }

        /// <summary>
        /// </summary>
      
        [DisplayName("Account Number")]
        [Remote("CheckIfAccountExist", "Account")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// </summary>
        [DisplayName("Outstanding Balance")]
        public decimal OutstandingBalance { get; set; }
        public string SearchText { get; set; }
    }

    public class EditAccountModel
    {
        public int Code { get; set; }

        [Display(Name = "Person Code")]
        [Required]
        public int? PersonCode { get; set; }

        [Display(Name = "Account Number")]
        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Display(Name = "Outstanding Balance")]
        [Required]
        public double? OutstandingBalance { get; set; }

        [Display(Name = "Status")]
        [Required]
        public int? StatusId { get; set; }
        public IList<SelectListItem> PersonList { get; set; }
        //TODO - Make the status a lookup
        public IList<StatusEntity> StatusList { get; set; }
        public List<SelectListItem> StatusListItems { get; set; }
        public IList<TransactionsEntity> TransactionsList { get; set; }

    }
    #endregion Person 

    #region Transactions
    public class GetTransactionsViewModel
    {
        public IList<TransactionsEntity> TransactionsList { get; set; }

        //Need to remove this properties after the resources folder is created
        /// <summary>
        /// </summary>
        [Display(Name = "Code")]
        public int? Code { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Account Code")]
        public int? AccountCode { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Transaction Date")]
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Capture Date")]
        public DateTime? CaptureDate { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Description")]
        public string Description { get; set; }
    }

    public class EditTransactionsModel
    {
        /// <summary>
        /// </summary>
        [Display(Name = "Code")]
        public int? Code { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Account Code")]
        [Required]
        public int? AccountCode { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Transaction Date")]
        [Required]
        public DateTime? TransactionDate { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Capture Date")]
        [Required]
        public DateTime? CaptureDate { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Amount")]
        [Required]
        [Remote("CheckTransactionAmount","Account")]
        public double? Amount { get; set; }

        /// <summary>
        /// </summary>
        [Display(Name = "Description")]
        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public IList<SelectListItem> AccountList { get; set; }

    }
    #endregion
}