using ISBank_Assessment.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BL
{
    public interface IAccountLogic
    {
        #region Read
        List<Account> GetAllAccounts(int? PersonCode, string SearchText = null);
        List<AccountEntity> GetAllPersonAccounts(int UserId, string SearchText = null);
        Account GetAccountByPersonCode(int Code, int PersonCode);
        Account GetAccountByCode(int Code);
        #endregion

        #region Modify
        #endregion
        Account AddAccount(Account AccountObj, int UserId);
        void changeAccountStatus(int Code, int statusId);
        Account ModifyAccount(Account AccountObj, int code);
        void RemoveAccount(int Code);
        #region Validations
        bool CheckIfAccountExist(string AccountNumber);
        bool CheckIfAccountIsOpenClosed(string AccountNumber);
        bool CheckAccountBalance(string AccountNumber);
        #endregion

    }
}
