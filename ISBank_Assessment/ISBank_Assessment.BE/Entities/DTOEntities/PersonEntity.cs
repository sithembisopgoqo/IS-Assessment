using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BE
{
    public class PersonEntity
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        public string AccountNumber { get; set; }
        ////ECC/ END CUSTOM CODE SECTION 
        public int Code { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
  
    }

    public class PersonEntityMapper : MapperBase<Person, PersonEntity>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 

        public override Expression<Func<Person, PersonEntity>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Person, PersonEntity>>)(p => new PersonEntity()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    Code = p.code,
                    UserId = (int)p.UserId,
                    Name = p.name,
                    Surname = p.surname,
                    IDNumber = p.id_number,
                   
                }));
            }
        }

        public override void MapToModel(PersonEntity dto, Person model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.code = dto.Code;
            model.UserId = dto.UserId;
            model.name = dto.Name;
            model.surname = dto.Surname;
            model.id_number = dto.IDNumber;

        }
    }
}
