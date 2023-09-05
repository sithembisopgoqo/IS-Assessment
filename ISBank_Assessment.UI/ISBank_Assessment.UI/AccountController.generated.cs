// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace ISBank_Assessment.UI.Controllers
{
    public partial class AccountController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AccountController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetAccounts()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetAccounts);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult AccountDetails()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AccountDetails);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SaveAccount()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SaveAccount);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetTransactions()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetTransactions);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult TransactionDetails()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.TransactionDetails);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SaveTransactions()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SaveTransactions);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult CheckTransactionAmount()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CheckTransactionAmount);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> changeAccountStatus()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.changeAccountStatus);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult CheckIfAccountIsClosed()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CheckIfAccountIsClosed);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.JsonResult CheckAccountBalance()
        {
            return new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CheckAccountBalance);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController Actions { get { return MVC.Account; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Account";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Account";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string GetAccounts = "GetAccounts";
            public readonly string AccountDetails = "AccountDetails";
            public readonly string SaveAccount = "SaveAccount";
            public readonly string GetTransactions = "GetTransactions";
            public readonly string TransactionDetails = "TransactionDetails";
            public readonly string SaveTransactions = "SaveTransactions";
            public readonly string CheckTransactionAmount = "CheckTransactionAmount";
            public readonly string changeAccountStatus = "changeAccountStatus";
            public readonly string CheckIfAccountIsClosed = "CheckIfAccountIsClosed";
            public readonly string CheckAccountBalance = "CheckAccountBalance";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string GetAccounts = "GetAccounts";
            public const string AccountDetails = "AccountDetails";
            public const string SaveAccount = "SaveAccount";
            public const string GetTransactions = "GetTransactions";
            public const string TransactionDetails = "TransactionDetails";
            public const string SaveTransactions = "SaveTransactions";
            public const string CheckTransactionAmount = "CheckTransactionAmount";
            public const string changeAccountStatus = "changeAccountStatus";
            public const string CheckIfAccountIsClosed = "CheckIfAccountIsClosed";
            public const string CheckAccountBalance = "CheckAccountBalance";
        }


        static readonly ActionParamsClass_GetAccounts s_params_GetAccounts = new ActionParamsClass_GetAccounts();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetAccounts GetAccountsParams { get { return s_params_GetAccounts; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetAccounts
        {
            public readonly string PersonCode = "PersonCode";
            public readonly string SearchText = "SearchText";
        }
        static readonly ActionParamsClass_AccountDetails s_params_AccountDetails = new ActionParamsClass_AccountDetails();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AccountDetails AccountDetailsParams { get { return s_params_AccountDetails; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AccountDetails
        {
            public readonly string Code = "Code";
            public readonly string PersonCode = "PersonCode";
        }
        static readonly ActionParamsClass_SaveAccount s_params_SaveAccount = new ActionParamsClass_SaveAccount();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SaveAccount SaveAccountParams { get { return s_params_SaveAccount; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SaveAccount
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_GetTransactions s_params_GetTransactions = new ActionParamsClass_GetTransactions();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetTransactions GetTransactionsParams { get { return s_params_GetTransactions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetTransactions
        {
            public readonly string AccountCode = "AccountCode";
            public readonly string SearchText = "SearchText";
        }
        static readonly ActionParamsClass_TransactionDetails s_params_TransactionDetails = new ActionParamsClass_TransactionDetails();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_TransactionDetails TransactionDetailsParams { get { return s_params_TransactionDetails; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_TransactionDetails
        {
            public readonly string Code = "Code";
            public readonly string PersonCode = "PersonCode";
        }
        static readonly ActionParamsClass_SaveTransactions s_params_SaveTransactions = new ActionParamsClass_SaveTransactions();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SaveTransactions SaveTransactionsParams { get { return s_params_SaveTransactions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SaveTransactions
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_CheckTransactionAmount s_params_CheckTransactionAmount = new ActionParamsClass_CheckTransactionAmount();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CheckTransactionAmount CheckTransactionAmountParams { get { return s_params_CheckTransactionAmount; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CheckTransactionAmount
        {
            public readonly string Amount = "Amount";
        }
        static readonly ActionParamsClass_changeAccountStatus s_params_changeAccountStatus = new ActionParamsClass_changeAccountStatus();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_changeAccountStatus changeAccountStatusParams { get { return s_params_changeAccountStatus; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_changeAccountStatus
        {
            public readonly string personCode = "personCode";
            public readonly string code = "code";
            public readonly string statusId = "statusId";
        }
        static readonly ActionParamsClass_CheckIfAccountIsClosed s_params_CheckIfAccountIsClosed = new ActionParamsClass_CheckIfAccountIsClosed();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CheckIfAccountIsClosed CheckIfAccountIsClosedParams { get { return s_params_CheckIfAccountIsClosed; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CheckIfAccountIsClosed
        {
            public readonly string AccountNumber = "AccountNumber";
        }
        static readonly ActionParamsClass_CheckAccountBalance s_params_CheckAccountBalance = new ActionParamsClass_CheckAccountBalance();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CheckAccountBalance CheckAccountBalanceParams { get { return s_params_CheckAccountBalance; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CheckAccountBalance
        {
            public readonly string AccountNumber = "AccountNumber";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string GetAccounts = "GetAccounts";
                public readonly string GetTransactions = "GetTransactions";
            }
            public readonly string GetAccounts = "~/Views/Account/GetAccounts.cshtml";
            public readonly string GetTransactions = "~/Views/Account/GetTransactions.cshtml";
            static readonly _PartialClass s_Partial = new _PartialClass();
            public _PartialClass Partial { get { return s_Partial; } }
            [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
            public partial class _PartialClass
            {
                static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
                public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
                public class _ViewNamesClass
                {
                    public readonly string AccountDetails = "AccountDetails";
                    public readonly string TransactionDetails = "TransactionDetails";
                }
                public readonly string AccountDetails = "~/Views/Account/Partial/AccountDetails.cshtml";
                public readonly string TransactionDetails = "~/Views/Account/Partial/TransactionDetails.cshtml";
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AccountController : ISBank_Assessment.UI.Controllers.AccountController
    {
        public T4MVC_AccountController() : base(Dummy.Instance) { }

        [NonAction]
        partial void GetAccountsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? PersonCode, string SearchText);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetAccounts(int? PersonCode, string SearchText)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetAccounts);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "PersonCode", PersonCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SearchText", SearchText);
            GetAccountsOverride(callInfo, PersonCode, SearchText);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void AccountDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? Code, int? PersonCode);

        [NonAction]
        public override System.Web.Mvc.ActionResult AccountDetails(int? Code, int? PersonCode)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AccountDetails);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Code", Code);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "PersonCode", PersonCode);
            AccountDetailsOverride(callInfo, Code, PersonCode);
            return callInfo;
        }

        [NonAction]
        partial void SaveAccountOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ISBank_Assessment.UI.Models.EditAccountModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SaveAccount(ISBank_Assessment.UI.Models.EditAccountModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SaveAccount);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            SaveAccountOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void GetTransactionsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? AccountCode, string SearchText);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetTransactions(int? AccountCode, string SearchText)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetTransactions);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "AccountCode", AccountCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "SearchText", SearchText);
            GetTransactionsOverride(callInfo, AccountCode, SearchText);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void TransactionDetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? Code, int PersonCode);

        [NonAction]
        public override System.Web.Mvc.ActionResult TransactionDetails(int? Code, int PersonCode)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.TransactionDetails);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Code", Code);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "PersonCode", PersonCode);
            TransactionDetailsOverride(callInfo, Code, PersonCode);
            return callInfo;
        }

        [NonAction]
        partial void SaveTransactionsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, ISBank_Assessment.UI.Models.EditTransactionsModel model);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SaveTransactions(ISBank_Assessment.UI.Models.EditTransactionsModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SaveTransactions);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            SaveTransactionsOverride(callInfo, model);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void CheckTransactionAmountOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, double? Amount);

        [NonAction]
        public override System.Web.Mvc.JsonResult CheckTransactionAmount(double? Amount)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CheckTransactionAmount);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Amount", Amount);
            CheckTransactionAmountOverride(callInfo, Amount);
            return callInfo;
        }

        [NonAction]
        partial void changeAccountStatusOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int personCode, int code, int statusId);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> changeAccountStatus(int personCode, int code, int statusId)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.changeAccountStatus);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "personCode", personCode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "code", code);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "statusId", statusId);
            changeAccountStatusOverride(callInfo, personCode, code, statusId);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void CheckIfAccountIsClosedOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string AccountNumber);

        [NonAction]
        public override System.Web.Mvc.JsonResult CheckIfAccountIsClosed(string AccountNumber)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CheckIfAccountIsClosed);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "AccountNumber", AccountNumber);
            CheckIfAccountIsClosedOverride(callInfo, AccountNumber);
            return callInfo;
        }

        [NonAction]
        partial void CheckAccountBalanceOverride(T4MVC_System_Web_Mvc_JsonResult callInfo, string AccountNumber);

        [NonAction]
        public override System.Web.Mvc.JsonResult CheckAccountBalance(string AccountNumber)
        {
            var callInfo = new T4MVC_System_Web_Mvc_JsonResult(Area, Name, ActionNames.CheckAccountBalance);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "AccountNumber", AccountNumber);
            CheckAccountBalanceOverride(callInfo, AccountNumber);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
