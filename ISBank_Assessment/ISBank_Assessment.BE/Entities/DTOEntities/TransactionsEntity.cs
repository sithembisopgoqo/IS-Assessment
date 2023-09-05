using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BE
{
    public class TransactionsEntity
    {
        public int code { get; set; }
        public int account_code { get; set; }
        public DateTime transaction_date { get; set; }
        public DateTime capture_date { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }


    }

    public class TransactionsEntityMapper : MapperBase<Transaction, TransactionsEntity>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 

        public override Expression<Func<Transaction, TransactionsEntity>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Transaction, TransactionsEntity>>)(p => new TransactionsEntity()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    code = p.code,
                    account_code = (int)p.account_code,
                    transaction_date = p.transaction_date,
                    capture_date = p.capture_date,
                    amount = p.amount,
                    description=p.description,

                }));
            }
        }

        public override void MapToModel(TransactionsEntity dto, Transaction model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.code = dto.code;
            model.account_code = dto.account_code;
            model.transaction_date = dto.transaction_date;
            model.capture_date = dto.capture_date;
            model.amount = dto.amount;
            model.description = dto.description;

        }
    }
}
