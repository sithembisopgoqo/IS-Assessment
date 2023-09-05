using ISBank_Assessment.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BL
{
    public interface IPersonLogic
    {
        #region Read
        List<PersonEntity> GetAllPersons(int UserId, string SearchText = null);
        Person GetPersonbyUserId(int Code, int UserId);
        #endregion

        #region Modify
        Person AddPerson(Person PersonObj);
        Person ModifyPerson(Person PersonObj);
        void RemovePerson(int Code, int UserId);
        #endregion

        #region Validation 
        bool checkPersonAccountExist(int Code, int UserId);
        bool checkPersonAccountStatus(int Code, int UserId);
        #endregion
    }
}
