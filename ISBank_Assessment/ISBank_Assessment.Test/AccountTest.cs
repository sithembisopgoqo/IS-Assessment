using System;
using ISBank_Assessment.BE;
using ISBank_Assessment.BL;
using ISBank_Assessment.DL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ISBank_Assessment.Test
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void CreateAccount()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);
            Account account = new Account();
            account.person_code = 1;
            account.account_number = "68328684";
            account.outstanding_balance = 1000;
            account.StatusId = 1;

            var accountCreated = AccountLogic.AddAccount(account,3);

        }

        [TestMethod]
        public void UpdateAccount()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);
            Account account = new Account();
            account.code = 1;
            account.person_code = 1;
            account.account_number = "68328684";
            //	The user is never allowed to change the account outstanding balance.
            //account.outstanding_balance = 1000;
            account.outstanding_balance = AccountLogic.GetAccountByCode(account.code).outstanding_balance;
            account.StatusId = 2;

            var accountModified = AccountLogic.ModifyAccount(account, account.code);

        }

        [TestMethod]
        public void DeleteAccount()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);
            //Paramaters to pass. Code


        }


        /// <summary>
        ///Get All Person Accounts
        /// </summary>
        [TestMethod]
        public void GetAllPersonAccounts()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);
            
            var list= AccountLogic.GetAllPersonAccounts(3);

        }


        /// <summary>
        ///Change Account Status
        /// </summary>
        [TestMethod]
        public void ChangeAccountStatus()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);
            //Paramaters to pass. Code and StatusId
            AccountLogic.changeAccountStatus(1, 2);

        }

        /// <summary>
        ///Check Account Balance
        /// </summary>
        [TestMethod]
        public void CheckAccountBalance()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);

            var CheckAccountBalance= AccountLogic.CheckAccountBalance("68328684");

        }

        /// <summary>
        ///Check If Account Exist
        /// </summary>
        [TestMethod]
        public void CheckIfAccountExist()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);

            var CheckIfAccountExist = AccountLogic.CheckIfAccountExist("68328684");

        }

        /// <summary>
        ///Check If Account Is Closed
        /// </summary>
        [TestMethod]
        public void CheckIfAccountIsOpenClosed()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);
            //Paramaters to pass. Code
            var CheckIfAccountIsClosed = AccountLogic.CheckIfAccountIsOpenClosed("68328684");

        }


        #region Transactions
        [TestMethod]
        public void CreateTransactions()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            TransactionLogic TransactionLogic = new TransactionLogic(unitOfWork);
            Transaction transaction = new Transaction();
            transaction.account_code = 1;
            transaction.transaction_date = DateTime.Now;
            transaction.capture_date = DateTime.Now;
            transaction.amount = 900;

            var transactionCreated = TransactionLogic.AddTransaction(transaction);

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);
            //Pass param Account object and Code
            var account = AccountLogic.GetAccountByCode(1);
            //Calculate outstanding balance after transaction
            if (account.outstanding_balance > transaction.amount)
            {
                account.outstanding_balance = account.outstanding_balance - transaction.amount;
                var updateAccount = AccountLogic.ModifyAccount(account, 1);
            }

            
        }

        [TestMethod]
        public void UpdateTransactions()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            TransactionLogic TransactionLogic = new TransactionLogic(unitOfWork);
            Transaction transaction = new Transaction();
            transaction.account_code = 1;
            transaction.transaction_date = DateTime.Now;
            //The user is never allowed to change the capture date.
            //transaction.capture_date = DateTime.Now;
            transaction.amount = 900;

            var transactionUpdated = TransactionLogic.ModifyTransaction(transaction);

            AccountLogic AccountLogic = new AccountLogic(unitOfWork);
            //Pass param Account object and Code
            var account=AccountLogic.GetAccountByCode(1);
            //Calculate outstanding balance after transaction
            if (account.outstanding_balance > transaction.amount)
            {
                account.outstanding_balance = account.outstanding_balance - transaction.amount;
                var updateAccount = AccountLogic.ModifyAccount(account, 1);
            }
           
           

        }
        #endregion
    }
}
