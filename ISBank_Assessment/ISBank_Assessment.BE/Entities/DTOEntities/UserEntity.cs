using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BE
{
    public class UserEntity
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public string Password { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<int> LoginCount { get; set; }
        public Nullable<bool> ForceChangePassword { get; set; }
    }

    public class UserEntityMapper : MapperBase<User, UserEntity>
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION 
        ////ECC/ END CUSTOM CODE SECTION 

        public override Expression<Func<User, UserEntity>> SelectorExpression
        {
            get
            {
                return ((Expression<Func<User, UserEntity>>)(p => new UserEntity()
                {
                    ////BCC/ BEGIN CUSTOM CODE SECTION 
                    ////ECC/ END CUSTOM CODE SECTION 
                    UserId = p.UserId,
                    UserName = p.UserName,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    EmailAddress = p.EmailAddress,
                    DateCreated = p.DateCreated,
                    LastLogin = p.LastLogin,
                    Password = p.Password,
                    LastUpdatedBy = p.LastUpdatedBy,
                    LoginCount = p.LoginCount,
                    ForceChangePassword= p.ForceChangePassword,
                }));
            }
        }

        public override void MapToModel(UserEntity dto, User model)
        {
            ////BCC/ BEGIN CUSTOM CODE SECTION 
            ////ECC/ END CUSTOM CODE SECTION 
            model.UserId = dto.UserId;
            model.UserName = dto.UserName;
            model.FirstName = dto.FirstName;
            model.LastName = dto.LastName;
            model.EmailAddress = dto.EmailAddress;
            model.DateCreated = dto.DateCreated;
            model.LastLogin = dto.LastLogin;
            model.Password = dto.Password;
            model.LastUpdatedBy = dto.LastUpdatedBy;
            model.LoginCount = dto.LoginCount;
            model.ForceChangePassword = dto.ForceChangePassword;

        }
    }
}
