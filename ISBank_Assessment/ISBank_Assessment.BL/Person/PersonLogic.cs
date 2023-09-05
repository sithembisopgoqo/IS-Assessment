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
    public class PersonLogic : IPersonLogic
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private readonly GenericRepository<Person> personRepository;

        public PersonLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.personRepository = unitOfWork.GetRepository<Person>();
        }

        public PersonLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.personRepository = unitOfWork.GetRepository<Person>();
            this._mapper = mapper;
        }

        #region Ready 

        /// <summary>
        /// Returns a list of all Person for the specified User
        /// </summary>
        /// <returns>List of Person objects</returns>
        /// <param name="UserId">User Id of the User to retrieve results for</param>
        public List<PersonEntity> GetAllPersons(int UserId, string SearchText = null)
        {

            var filtered = personRepository.Get(x => x.UserId == UserId).ToList();

            var query = (from c in filtered
                         select new PersonEntity()
                         {
                             Code=c.code,
                             UserId=(int)c.UserId,
                             Name = c.name,
                             IDNumber = c.id_number,
                             Surname = c.surname,
                             AccountNumber=""

                         }).ToList();

            if (!string.IsNullOrEmpty(SearchText))
            {

                SearchText = SearchText.Trim().ToLower();
                query = query.Where(
                    group =>
                        (group.IDNumber != null && group.IDNumber.ToLower().Contains(SearchText)) ||
                        (group.Surname != null && group.Surname.ToLower().Contains(SearchText)) ||
                        (group.AccountNumber != null && group.AccountNumber.ToLower().Contains(SearchText))

                ).ToList();
            }

           query = query.ToList();
           
            return query;



        }

        /// <summary>
        /// Returns a list of all Person for the specified User
        /// </summary>
        /// <returns>List of Person objects</returns>
        /// <param name="PersonId"></param>
        public Person GetPersonbyUserId(int Code, int UserId)
        {
            #region Validation

            //throw new NotSupportedException();

            #endregion Validation


            return personRepository.Get(x => x.code == Code && x.UserId == UserId).SingleOrDefault();
        }

        #endregion



        #region Modify 
        /// <summary>
        /// Add a Person object
        /// </summary>
        /// <returns>Single Person object</returns>
        /// <param name="PersonObj">Person object to add</param>
        public Person AddPerson(Person PersonObj)
        {
            #region Validation

            //Check if person exist by ID Number before adding
            if (PersonObj.id_number != null)
            {
                var getAllPerson = personRepository.GetAll().Where(x => x.id_number == PersonObj.id_number).ToList();
                if (getAllPerson.Any())
                {
                    throw new Exception(string.Format("This person already exist", PersonObj.id_number));
                }
            }

                       
            #endregion Validation

            Person person = personRepository.Insert(PersonObj);
            try
            {
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw e;
            }

            return person;
        }

        /// <summary>
        /// Modify a Person object
        /// </summary>
        /// <returns>Single Person object</returns>
        /// <param name="DiscountObj">Person object to modify</param>
        public Person ModifyPerson(Person PersonObj)
        {

            personRepository.Update(PersonObj);
            unitOfWork.Save();

            return PersonObj;
        }

        // <summary>
        /// Remove a Person object
        /// </summary>
        /// <returns></Person>
        /// <param name="Person">Person object to remove</param>
        public void RemovePerson(int Code, int UserId)
        {
            #region Validation        
            var accountCheck= checkPersonAccountExist(Code, UserId);
            
            if (accountCheck || checkPersonAccountStatus(Code,UserId))
            {
                throw new Exception("Only person with no accounts or where all accounts are closed may be deleted.");

            }

            #endregion Validation

            personRepository.Delete(Code);
            unitOfWork.Save();
        }

        #endregion
        //Only persons with no accounts or where all accounts are closed may be deleted
        public bool checkPersonAccountExist(int Code, int UserId)
        {
            var PersonAccount = false;
            Person PersonObj = personRepository.Get(a => a.code == Code & a.UserId == UserId).SingleOrDefault();

            if (PersonObj.Accounts.Any())
            { 
                   PersonAccount = true;
            }
            
            return PersonAccount;

        }
        //Only persons with no accounts or where all accounts are closed may be deleted
        public bool checkPersonAccountStatus(int Code, int UserId)
        {
            var PersonAccount = false;
            Person PersonObj = personRepository.Get(a => a.code == Code & a.UserId == UserId).SingleOrDefault();

            var accountStatusCheck = PersonObj.Accounts.Where(x => x.Status.StatusTypes == Convert.ToString(AccountStatus.Closed));
            if (accountStatusCheck.Any())
            {
                PersonAccount = true;
            }
            return PersonAccount;

        }
        #region Validations
        #endregion

    }
}
