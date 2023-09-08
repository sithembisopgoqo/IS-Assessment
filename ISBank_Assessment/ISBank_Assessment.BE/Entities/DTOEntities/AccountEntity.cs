using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BE
{
    public class AccountEntity
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        public int UserId { get; set; }
        ////ECC/ END CUSTOM CODE SECTION 
        public int code { get; set; }
        public int person_code { get; set; }
        public string account_number { get; set; }
        public decimal outstanding_balance { get; set; }
        public int? StatusId { get; set; }
        public string Name { get; set; }
        public string IDNumber { get; set; }
        public string Surname { get; set; }
    }

    public class AccountEntityMapper : MapperBase<Account, AccountEntity>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 

        public override Expression<Func<Account, AccountEntity>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Account, AccountEntity>>)(p => new AccountEntity()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    code = p.code,
                    person_code = p.person_code,
                    account_number = p.account_number,
                    outstanding_balance = p.outstanding_balance,
                    StatusId = p.StatusId,
                }));
            }
        }

        public override void MapToModel(AccountEntity dto, Account model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 

            model.code = dto.code;
            model.person_code = dto.person_code;
            model.account_number = dto.account_number;
            model.outstanding_balance = dto.outstanding_balance;
            model.StatusId = dto.StatusId;

        }
    }
}
