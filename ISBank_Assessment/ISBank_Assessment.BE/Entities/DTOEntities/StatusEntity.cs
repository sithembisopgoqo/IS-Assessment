using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BE
{
    public class StatusEntity
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int StatusId { get; set; }
        public string StatusTypes { get; set; }

    }

    public class StatusEntityMapper : MapperBase<Status, StatusEntity>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 

        public override Expression<Func<Status, StatusEntity>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<Status, StatusEntity>>)(p => new StatusEntity()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    StatusId = p.StatusId,
                    StatusTypes = p.StatusTypes,
                   
                }));
            }
        }

        public override void MapToModel(StatusEntity dto, Status model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 

            model.StatusId = dto.StatusId;
            model.StatusTypes = dto.StatusTypes;
            

        }
    }
}
