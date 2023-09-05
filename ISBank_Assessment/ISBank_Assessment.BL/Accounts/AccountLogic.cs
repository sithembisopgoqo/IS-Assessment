using AutoMapper;
using ISBank_Assessment.BE;
using ISBank_Assessment.DL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BL
{
    public class AccountLogic:IAccountLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericRepository<Account> accountRepository;

        public AccountLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.accountRepository = unitOfWork.GetRepository<Account>();
        }

        public AccountLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.accountRepository = unitOfWork.GetRepository<Account>();
            this._mapper = mapper;
        }


        #region Read

        /// <summary>
        /// Returns a list of all Accounts 
        /// </summary>
        /// <returns>List of Accounts objects</returns>
        /// <param name="Code"></param>
        /// Get All Accounts for the person
        public List<Account> GetAllAccounts(int? PersonCode, string SearchText = null)
        {

            var filtered = accountRepository.Get(x => x.person_code == PersonCode).ToList();
            if (!string.IsNullOrEmpty(SearchText))
            {
                SearchText = SearchText.Trim().ToLower();
                filtered = filtered.Where(
                    group =>
                        (group.person_code.ToString().Contains(SearchText)) ||
                        (group.account_number != null && group.account_number.ToLower().Contains(SearchText)) ||
                        (group.outstanding_balance.ToString().Contains(SearchText)) ||
                        (group.Status.StatusTypes != null && group.Status.StatusTypes.Contains(SearchText))

                ).ToList();
            }
           
            
            return filtered;

        }

        /// <summary>
        /// Returns a single Account
        /// </summary>
        /// <returns>Single Account object</returns>
        /// <param name="Code"></param>
        /// <param name="PersonCode"></param>
        public Account GetAccountByCode(int Code)
        {
            #region Validation

            #endregion Validation

            return accountRepository.Get(x => x.code == Code).SingleOrDefault();

            #region History

            #endregion History
        }


        /// <summary>
        /// Returns a single Account
        /// </summary>
        /// <returns>Single Account object</returns>
        /// <param name="Code"></param>
        /// <param name="PersonCode"></param>
        public Account GetAccountByPersonCode(int Code, int PersonCode)
        {
            #region Validation

            #endregion Validation

            return accountRepository.Get(x => x.code == Code && x.person_code == PersonCode).SingleOrDefault();

            #region History

            #endregion History
        }

        #endregion Read

        #region Modify

        /// <summary>
        /// Add a Account object
        /// </summary>
        /// <returns>Single Account object</returns>
        /// <param name="AccountObj"></param>
        public Account AddAccount(Account AccountObj, int UserId)
        {
            if (AccountObj.account_number != null)
            {
                var checkAcc = CheckIfAccountExist(AccountObj.account_number);
                if (checkAcc)
                {
                    throw new Exception(string.Format("This Account already exist", AccountObj.account_number));
                }
            }
            
            

            Account account = accountRepository.Insert(AccountObj);
            unitOfWork.Save();

            return account;
        }

        //change Account Status
        public void changeAccountStatus(int Code, int statusId)
        {
            var account = accountRepository.Get(x => x.code == Code).SingleOrDefault();
            account.StatusId = statusId;
            accountRepository.Update(account);
            unitOfWork.Save();
        }
        /// <summary>
        /// Modify a Account object
        /// </summary>
        /// <returns>Single Account object</returns>
        /// <param name="AccountObj"></param>
        public Account ModifyAccount(Account AccountObj, int code)
        {
            Account account = accountRepository.Get(x => x.code == code).SingleOrDefault();
            account.person_code = AccountObj.person_code;
            account.account_number = AccountObj.account_number;
            account.outstanding_balance = AccountObj.outstanding_balance;
            account.Status.StatusTypes = AccountObj.Status.StatusTypes;

            accountRepository.Update(account);
            unitOfWork.Save();

           
            return account;
        }


        // <summary>
        /// Remove Account object
        /// </summary>
        /// <returns></Account>
        /// <param name="Account">Account object to remove</param>
        public void RemoveAccount(int Code)
        {
          
            accountRepository.Delete(Code);
            unitOfWork.Save();
        }

        #endregion Modify


        #region Validations
        //Avoiding - duplicated account numbers.
        public bool CheckIfAccountExist(string AccountNumber)
        {
            bool accountExist = false;

            var Account = accountRepository.GetAll().Where(x => x.account_number == AccountNumber).ToList();
            try
            {
                if (Account.Any())
                {
                    accountExist = true;
                  
                }
              
            }
            catch(Exception e)
            {
                throw e;
            }

            return accountExist;
        }

        //Checks If Account Is Closed
        public bool CheckIfAccountIsOpenClosed(string AccountNumber)
        {
            //Open Account
            bool accountOpenClosed = false;

            var Account = accountRepository.GetAll().Where(x => x.account_number == AccountNumber).ToList();
            try
            {

                if (Account.FirstOrDefault().Status.StatusTypes == Convert.ToString((int)BE.AccountStatus.Closed))
                {
                    //Closed Account
                    accountOpenClosed = true;
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }

            return accountOpenClosed;
        }

        //Checks Account Balance

        public bool CheckAccountBalance(string AccountNumber)
        {
            bool accountBalance = false;

            var Account = accountRepository.GetAll().Where(x => x.account_number == AccountNumber).ToList();
            try
            {

                if (Account.Any())
                {
                    if(Account.FirstOrDefault().outstanding_balance>0)
                      accountBalance = true;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return accountBalance;
        }
        #endregion
    }
}
