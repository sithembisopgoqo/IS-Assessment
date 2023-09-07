using ISBank_Assessment.UI.Common;
using ISBank_Assessment.UI.Enums;
using ISBank_Assessment.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI;
using WebAPI.Models;

namespace ISBank_Assessment.UI.Controllers
{
    public partial class AccountController : Controller
    {
        // GET: Account
        #region Account 
        [HttpGet]
        [OutputCache(Duration = 0, NoStore = false)]
        public virtual async Task<ActionResult> GetAccounts(int? PersonCode,string SearchText = null)
        {
            Account accountClient = new Account(ServiceFactory.GetClient());
            GetAccountViewModel model = new GetAccountViewModel();

            model.AccountList = await accountClient.GetAllAccountsAsync(PersonCode.Value, SearchText);

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult AccountDetails(int? Code, int? PersonCode)
        {
            var UserId = SessionHelper.Get<int>("UserId");
            Account accountClient = new Account(ServiceFactory.GetClient());
            EditAccountModel model = new EditAccountModel();
            model.TransactionsList = new List<TransactionsEntity>();
            #region dropdown lists
            Person personClient = new Person(ServiceFactory.GetClient());
            model.PersonList = new List<SelectListItem>();
            model.PersonList = (from u in personClient.GetAllPersons(UserId)
                                select new SelectListItem
                              {
                                  //Display Name for person
                                  Text = u.Name,
                                  Value = u.Code.ToString()
                              }).ToList();

            model.StatusListItems = Enum.GetValues(typeof(AccountStatus)).Cast<AccountStatus>().Select(x => new SelectListItem { Text = EnumHelper.GetDescription(x), Value = ((int)x).ToString() }).ToList();
            #endregion

            if (Code == null)
            {
                Code = 0;
            }

            model.Code = (int)Code;

            if (Code.HasValue && Code.Value > 0)
            {
                AccountEntity accountEntity = new AccountEntity();
                if (PersonCode==null)
                {
                    accountEntity = accountClient.GetAccounts(Code.Value);
                }
                else
                {
                    accountEntity = accountClient.GetAccountByPersonCode(Code.Value, PersonCode.Value);
                }
              
                model.Code = (int)accountEntity.Code;
                model.PersonCode = accountEntity.PersonCode;
                model.AccountNumber = accountEntity.AccountNumber;
                //The user is never allowed to change the account outstanding balance.
                //model.OutstandingBalance = accountEntity.OutstandingBalance;
                model.StatusId = accountEntity.StatusId;
                model.TransactionsList = accountClient.GetAllTransactions(model.Code); 

            }
            //TODO- Partial views for Person,Account and Transactions Details
            //return PartialView(MVC.Account.Views.Partial.PersonDetails, model);
            return View(MVC.Account.Views.Partial.AccountDetails, model);

        }

        [HttpPost]
        public virtual async Task<ActionResult> SaveAccount(EditAccountModel model)
        {
            var UserId = SessionHelper.Get<int>("UserId");
            Account accountClient = new Account(ServiceFactory.GetClient());
            AccountEntity accountEntity = new AccountEntity();

            accountEntity.Code = model.Code;
            accountEntity.PersonCode = model.PersonCode;
            accountEntity.AccountNumber = model.AccountNumber;
            accountEntity.StatusId = model.StatusId;

            if (model.Code > 0)
            {
                accountEntity.Code = model.Code;
                
                await accountClient.ModifyAccountAsync(accountEntity, model.Code);
            }
            else
            {
                accountEntity.OutstandingBalance = model.OutstandingBalance;
                await accountClient.AddAccountAsync(accountEntity, UserId);
            }

            return RedirectToAction(MVC.Account.GetAccounts(accountEntity.PersonCode));
        }

        //[HttpPost]
        [OutputCache(Duration = 0, NoStore = false)]
        public virtual async Task<ActionResult> DeleteAccount(int? AccountCode)
        {
            Account accountClient = new Account(ServiceFactory.GetClient());
          
             await accountClient.RemoveAccountAsync(AccountCode.Value);

            return RedirectToAction(MVC.Account.GetAccounts());
        }

        #endregion Account

        #region Transactions
        #region Read
        [HttpGet]
        [OutputCache(Duration = 0, NoStore = false)]
        public virtual async Task<ActionResult> GetTransactions(int? AccountCode, string SearchText = null)
        {
            Account accountClient = new Account(ServiceFactory.GetClient());
            GetTransactionsViewModel model = new GetTransactionsViewModel();

            model.TransactionsList = await accountClient.GetAllTransactionsAsync(AccountCode.Value, SearchText);

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult TransactionDetails(int? Code,int? PersonCode)
        {
            Account accountClient = new Account(ServiceFactory.GetClient());
            EditTransactionsModel model = new EditTransactionsModel();

            Person personClient = new Person(ServiceFactory.GetClient());
            if (PersonCode != null)
            {
                var AcccountCode = accountClient.GetAllAccounts(PersonCode.Value).ToList().FirstOrDefault().Code;
                model.AccountCode = AcccountCode;
            }

            if (Code == null)
            {
                Code = 0;
            }

            model.Code = (int)Code;
            
            if (Code.HasValue && Code.Value > 0)
            {

                TransactionsEntity transactionsEntity = accountClient.GetTransactionbyCode(Code.Value);
                model.Code = (int)transactionsEntity.Code;
                model.AccountCode = transactionsEntity.AccountCode;
                //model.TransactionDate = transactionsEntity.TransactionDate.ToString();
                model.Amount = transactionsEntity.Amount;
                model.Description = transactionsEntity.Description;
                //The user is never allowed to change the capture date.
                //model.CaptureDate = transactionsEntity.CaptureDate;

            }
            //TODO- Partial views for Person,Account and Transactions Details
            return View(MVC.Account.Views.Partial.TransactionDetails, model);

        }

        [HttpPost]
        public virtual async Task<ActionResult> SaveTransactions(EditTransactionsModel model)
        {
            var UserId = SessionHelper.Get<int>("UserId");
            Account accountClient = new Account(ServiceFactory.GetClient());
            TransactionsEntity transactionEntity = new TransactionsEntity();

            transactionEntity.AccountCode = model.AccountCode;
            transactionEntity.TransactionDate = Convert.ToDateTime(model.TransactionDate);
            transactionEntity.CaptureDate= Convert.ToDateTime(model.CaptureDate);
            transactionEntity.Amount = model.Amount;
            transactionEntity.Description = model.Description;

            if (model.Code > 0)
            {
                transactionEntity.Code = model.Code;
                await accountClient.ModifyTransactionAsync(transactionEntity);
            }
            else
            {
                await accountClient.AddTransactionAsync(transactionEntity);

            }
            //The outstanding balance for the account must be updated whenever a new transaction is added or when the amount for an existing transaction is modified.
            AccountEntity accountEntity = new AccountEntity();

            var account = accountClient.GetAccounts((int)transactionEntity.AccountCode);
            if (account.OutstandingBalance> transactionEntity.Amount)
            {
                account.OutstandingBalance = account.OutstandingBalance - transactionEntity.Amount;
                var updateAccount = accountClient.ModifyAccountAsync(account, account.Code.Value);
            }
           
            return RedirectToAction(MVC.Account.GetTransactions());
        }


        #endregion
        #endregion


        #region Validations
        //The transaction amount can never be zero (0).
        [AllowAnonymous]
        public virtual JsonResult CheckTransactionAmount(double? Amount)
        {

            if (Amount ==0)
            {
                return Json("The transaction amount can never be zero (0).", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //change Account Status
        [AllowAnonymous]
        public virtual async Task<ActionResult> changeAccountStatus(int personCode,int code, int statusId)
        {
            Account accountClient = new Account(ServiceFactory.GetClient());
            if (statusId == 1)
            {
                statusId = (int)AccountStatus.Closed;
            }
            else
            {
                statusId = (int)AccountStatus.Open;
            }
            var ChangeAccount = accountClient.ChangeAccountStatusAsync(code,statusId);

            //TODO - Not sure where to redirect
            return RedirectToAction(MVC.Account.GetAccounts(personCode));
            //return Json(true, JsonRequestBehavior.AllowGet);
            ////return RedirectToAction(MVC.Account.GetAccounts(null));
        }

        // Checks if Account is Closed
        //No transactions may be posted to closed accounts
        [AllowAnonymous]
        public virtual JsonResult CheckIfAccountIsClosed(string AccountNumber)
        {
            Account accountClient = new Account(ServiceFactory.GetClient());
            var AccountIsClosed = accountClient.CheckIfAccountIsOpenClosed(AccountNumber);

            if (AccountIsClosed == true)
            {
                return Json("Account is Closed", JsonRequestBehavior.AllowGet);
            }


            return Json(true, JsonRequestBehavior.AllowGet);
        }

        //You cannot close an account when the balance is not zero.
        [AllowAnonymous]
        public virtual JsonResult CheckAccountBalance(string AccountNumber)
        {
            Account accountClient = new Account(ServiceFactory.GetClient());
            var AccountBalance = accountClient.CheckAccountBalance(AccountNumber);

            if (AccountBalance == true)
            {
                return Json("You cannot close an account when the balance is not zero.", JsonRequestBehavior.AllowGet);
            }


            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}