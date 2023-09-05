using AutoMapper;
using ISBank_Assessment.BE;
using ISBank_Assessment.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BL
{
    public class TransactionLogic: ITransactionLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericRepository<Transaction> transactionRepository;

        public TransactionLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.transactionRepository = unitOfWork.GetRepository<Transaction>();
        }

        public TransactionLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.transactionRepository = unitOfWork.GetRepository<Transaction>();
            this._mapper = mapper;
        }

        #region Ready 

        /// <summary>
        /// Returns a list of all Transaction for the specified Account
        /// </summary>
        /// <returns>List of Transaction objects</returns>
        /// <param name="AccountCode"></param>
        public List<Transaction> GetAllTransactions(int AccountCode, string SearchText = null)
        {

            //throw new NotSupportedException();

            var filtered = transactionRepository.Get(x => x.account_code == AccountCode).ToList();         

            if (!string.IsNullOrEmpty(SearchText))
            {

                SearchText = SearchText.Trim().ToLower();
                filtered = filtered.Where(
                    group =>
                        (group.account_code.ToString().Contains(SearchText)) ||
                        (group.transaction_date != null && group.transaction_date.ToString().Contains(SearchText)) ||
                        (group.capture_date != null && group.capture_date.ToString().Contains(SearchText)) ||
                        (group.amount.ToString().Contains(SearchText)) ||
                        (group.description != null && group.description.ToLower().Contains(SearchText))

                ).ToList();
            }
            else
            {
                filtered = filtered.ToList();
            }
            return filtered;

        }

        /// <summary>
        /// Returns a single Transaction for the specified Account
        /// </summary>
        /// <returns>Transaction objects</returns>
        /// <param name="Code"></param>
        public Transaction GetTransactionbyCode(int Code)
        {
            #region Validation

            //throw new NotSupportedException();

            #endregion Validation


            return transactionRepository.Get(x => x.code == Code).SingleOrDefault();
        }

        #endregion



        #region Modify 
        /// <summary>
        /// Add a Transaction object
        /// </summary>
        /// <returns>Single Transaction object</returns>
        /// <param name="TransactionObj">Transaction object to add</param>
        public Transaction AddTransaction(Transaction TransactionObj)
        {
            #region Validation


            #endregion Validation

            Transaction transaction = transactionRepository.Insert(TransactionObj);
            try
            {
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw e;
            }

            return transaction;
        }

        /// <summary>
        /// Modify a Transaction object
        /// </summary>
        /// <returns>Single Transaction object</returns>
        /// <param name="TransactionObj">Transaction object to modify</param>
        public Transaction ModifyTransaction(Transaction TransactionObj)
        {

            transactionRepository.Update(TransactionObj);
            unitOfWork.Save();

            return TransactionObj;
        }

        #endregion
        //	The transaction amount can never be zero (0).
        public bool checkTransactionAmountValue(decimal amount)
        {
            var AmountValue = false;
      
            if (amount==0)
            {
                AmountValue = true;
            }

            return AmountValue;

        }
       
        #region Validations
        #endregion

    }
}
