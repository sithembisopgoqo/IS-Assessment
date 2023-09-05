using AutoMapper;
using ISBank_Assessment.BE;

namespace ISBank_Assessment.BL
{
    public class MappingConfiguration
    {
        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                //Create all maps here
                #region User
                cfg.CreateMap<User, UserEntity>();
                cfg.CreateMap<UserEntity, User>();
                #endregion User

                #region Status
                cfg.CreateMap<Status, StatusEntity>();
                cfg.CreateMap<StatusEntity, Status>();
                #endregion Status

                #region Person
                cfg.CreateMap<Person, PersonEntity>();
                cfg.CreateMap<PersonEntity, Person>();
                #endregion Person

                #region Account
                cfg.CreateMap<Account, AccountEntity>();
                cfg.CreateMap<AccountEntity, Account>();
                #endregion Account

                #region Transaction
                cfg.CreateMap<Transaction, TransactionsEntity>();
                cfg.CreateMap<TransactionsEntity, Transaction>();
                #endregion Transaction

            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }
    }
}
