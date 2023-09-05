using ISBank_Assessment.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BL
{
    public interface ITransactionLogic
    {
        #region Read
        List<Transaction> GetAllTransactions(int AccountCode, string SearchText = null);
        Transaction GetTransactionbyCode(int Code);

        #endregion

        #region Modify
        Transaction AddTransaction(Transaction TransactionObj);
        Transaction ModifyTransaction(Transaction TransactionObj);
        bool checkTransactionAmountValue(decimal amount);
        #endregion
    }
}
