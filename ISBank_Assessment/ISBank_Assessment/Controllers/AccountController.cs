using AutoMapper;
using ISBank_Assessment.BE;
using ISBank_Assessment.BL;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISBank_Assessment.Controllers
{
    public class AccountController : ApiController
    {
        private IAccountLogic _account;
        private ITransactionLogic _transaction;
        private IStatus _status;
        private IMapper _mapper;

        public AccountController()
        {
        }
        /// <summary>
        /// AccessController Non-Default Constructor 
        /// </summary> 
        /// <param name="AccountLogic">IAccountLogic object injected through Unity, providing AccountLogic functionality</param>
        /// <param name="TransactionLogic"></param>
        /// <param name="StatusLogic"></param>
        /// <param name="Mapper">Mapper object injected through Unity, providing object mapping functionality</param> 
        public AccountController(IAccountLogic AccountLogic, ITransactionLogic TransactionLogic,IStatus StatusLogic, IMapper Mapper)
        {
            _account = AccountLogic;
            _transaction = TransactionLogic;
            _status = StatusLogic;
            _mapper = Mapper;
        }

        #region Account

        /// <summary>
        /// Returns a list of all available AccountEntity for the specified User
        /// </summary>
        /// <returns>List of AccountEntity</returns>
        /// <param name="PersonCode"></param> 
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(List<AccountEntity>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("ViewAccount")]
        public IHttpActionResult GetAllPersonAccounts(int UserId, string SearchText = null)
        {
            return Ok(_account.GetAllPersonAccounts(UserId, SearchText));
        }


        /// <summary>
        /// Returns a list of all available AccountEntity for the specified User
        /// </summary>
        /// <returns>List of AccountEntity</returns>
        /// <param name="PersonCode"></param> 
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(List<AccountEntity>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("ViewAccount")]
        public IHttpActionResult GetAllAccounts(int? PersonCode, string SearchText = null)
        {
            return Ok(_account.GetAllAccounts((int)PersonCode, SearchText));
        }

        /// <summary>
        /// Returns a list of all available AccountEntity for the specified User
        /// </summary>
        /// <returns>List of AccountEntity</returns>
        /// <param name="PersonCode"></param> 
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(AccountEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("ViewAccount")]
        public IHttpActionResult GetAccounts(int Code)
        {
            Account Account = _account.GetAccountByCode((int)Code);

            var accountEntity = _mapper.Map<AccountEntity>(Account);
            return Ok(accountEntity);
        }

        /// <summary>
        /// Returns a single AccountEntity for the specified Person
        /// </summary>
        /// <returns>AccountEntity object</returns>
        /// <param name="Code">Code of the Person to retrieve results for</param>
        /// <param name="PersonCode"></param> 

        [SwaggerResponse(HttpStatusCode.OK, type: typeof(AccountEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("ViewAccount")]
        public IHttpActionResult GetAccountByPersonCode(int Code, int PersonCode)
        {
            Account Account = _account.GetAccountByPersonCode(Code, PersonCode);
            var accountEntity = _mapper.Map<AccountEntity>(Account);
            return Ok(accountEntity);
        }
        /// <summary>
        /// Add a AccountEntity object
        /// </summary>
        /// <returns>Single AccountEntity object</returns>
        /// <param name="AccountObj">AccountEntity object to add</param>
        /// <param name="userId"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(AccountEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditAccount")]
        public IHttpActionResult AddAccount(AccountEntity AccountObj,int userId)
        {

            Account account = _account.AddAccount(_mapper.Map<Account>(AccountObj), userId);
            return Ok(_mapper.Map<AccountEntity>(account));
        }

        /// <summary>
        /// Modify a AccountEntity object
        /// </summary>
        /// <returns>Single AccountEntity object</returns>
        /// <param name="AccountObj">AccountEntity object to modify</param>
        /// <param name="code"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(AccountEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditAccount")]
        public IHttpActionResult ModifyAccount(AccountEntity AccountObj,int code)
        {
            Account account = _account.ModifyAccount(_mapper.Map<Account>(AccountObj),code);
            return Ok(_mapper.Map<AccountEntity>(account));
        }

        /// <summary>
        /// Remove Account object
        /// </summary>
        /// <returns>/returns>
        /// <param name="AccountObj"></param>
        /// <param name="code"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(void))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditAccount")]
        public IHttpActionResult RemoveAccount(int code)
        {
             _account.RemoveAccount(code);
            return Ok();
        }

        /// <summary>
        /// Change Account Status by Code and Status Id
        /// </summary>
        /// <returns></returns>
        /// <param name="Code"></param>
        /// <param name="StatusId"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(void))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditPerson")]
        public IHttpActionResult ChangeAccountStatus(int Code, int StatusId)
        {
            _account.changeAccountStatus(Code, StatusId);
            return Ok();
        }


        #endregion Account

        #region Validations

        /// <summary>
        /// Check Person Account Status
        /// </summary>
        /// <returns></returns>
        /// <param name="AccountNumber"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("EditPerson")]
        public IHttpActionResult CheckPersonAccounttStatus(string AccountNumber)
        {
            var PersonAccountExist = _account.CheckIfAccountExist(AccountNumber);
            return Ok(PersonAccountExist);
        }

        /// <summary>
        /// Check If Account Is Open/Closed
        /// </summary>
        /// <returns></returns>
        /// <param name="AccountNumber"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("EditPerson")]
        public IHttpActionResult CheckIfAccountIsOpenClosed(string AccountNumber)
        {
            var OpenClosed = _account.CheckIfAccountIsOpenClosed(AccountNumber);
            return Ok(OpenClosed);
        }

        /// <summary>
        /// Check if Account Balance is greater then 0
        /// </summary>
        /// <returns></returns>
        /// <param name="AccountNumber"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("EditPerson")]
        public IHttpActionResult CheckAccountBalance(string AccountNumber)
        {
            var CheckAccountBalance = _account.CheckAccountBalance(AccountNumber);
            return Ok(CheckAccountBalance);
        }
        #endregion

        #region Transactions
        #region Read
        /// <summary>
        /// Returns a list of all available TransactionsEntity for the specified Acccount
        /// </summary>
        /// <returns>List of TransactionsEntity</returns>
        /// <param name="AccountCode"></param> 
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(List<TransactionsEntity>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("ViewAccount")]
        public IHttpActionResult GetAllTransactions(int AccountCode, string SearchText = null)
        {
            return Ok(_transaction.GetAllTransactions(AccountCode, SearchText));
        }

        /// <summary>
        /// Returns a single TransactionsEntity for the specified Acccount
        /// </summary>
        /// <returns> TransactionsEntity</returns>
        /// <param name="Code"></param> 
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(TransactionsEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("ViewAccount")]
        public IHttpActionResult GetTransactionbyCode(int Code)
        {
            return Ok(_transaction.GetTransactionbyCode(Code));
        }
        #endregion
        #region Modify
        /// <summary>
        /// Add a TransactionsEntity object
        /// </summary>
        /// <returns>Single TransactionsEntity object</returns>
        /// <param name="TransactionObj">TransactionsEntity object to add</param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(TransactionsEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditAccount")]
        public IHttpActionResult AddTransaction(TransactionsEntity TransactionObj)
        {

            Transaction account = _transaction.AddTransaction(_mapper.Map<Transaction>(TransactionObj));
            return Ok(_mapper.Map<TransactionsEntity>(account));
        }

        /// <summary>
        /// Modify a TransactionsEntity object
        /// </summary>
        /// <returns>Single TransactionsEntity object</returns>
        /// <param name="AccountObj">TransactionsEntity object to modify</param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(TransactionsEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditAccount")]
        public IHttpActionResult ModifyTransaction(TransactionsEntity AccountObj)
        {
            Transaction Transaction = _transaction.ModifyTransaction(_mapper.Map<Transaction>(AccountObj));
            return Ok(_mapper.Map<TransactionsEntity>(Transaction));
        }

        #endregion

        #region Validations
        /// <summary>
        /// Checks if the Transaction Amount Value is 0
        /// </summary>
        /// <returns></returns>
        /// <param name="amount"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("ViewTransaction")]
        public IHttpActionResult CheckTransactionAmountValue(decimal amount)
        {
            var PersonAccountExist = _transaction.checkTransactionAmountValue(amount);
            return Ok(PersonAccountExist);
        }

        #endregion
        #endregion

        #region Status
        /// <summary>
        /// Returns a single StatusEntity
        /// </summary>
        /// <returns>StatusEntity</returns>
        /// <param name="statusId"></param> 
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(List<StatusEntity>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("ViewAccount")]
        public IHttpActionResult GetStatusById(int statusId)
        {
            return Ok(_status.GetStatusById(statusId));
        }
        #endregion
    }
}
