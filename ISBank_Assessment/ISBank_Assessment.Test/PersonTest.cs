using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISBank_Assessment.DL;
using ISBank_Assessment.BL;
using ISBank_Assessment.BE;

namespace ISBank_Assessment.Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void CreatePerson()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            PersonLogic PersonLogic = new PersonLogic(unitOfWork);
            Person person = new Person();
            person.UserId = 1;
            person.name = "Luck";
            person.surname = "Doe";
            person.id_number = "9278636283636";

            var userCreated = PersonLogic.AddPerson(person);

        }

        [TestMethod]
        public void UpdatePerson()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            PersonLogic PersonLogic = new PersonLogic(unitOfWork);
            Person person = new Person();
            person.code = 1;
            person.UserId = 1;
            person.name = "Luck";
            person.surname = "Doe";
            person.id_number = "9278636283636";
            
            var personModified = PersonLogic.ModifyPerson(person);

        }

        [TestMethod]
        public void DeletePerson()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            PersonLogic PersonLogic = new PersonLogic(unitOfWork);
            //Paramaters to pass. Code and UserId(To know which user deleted the person)
            PersonLogic.RemovePerson(1,3);

        }

        /// <summary>
        /// checks if person account exist
        /// </summary>
        [TestMethod]
        public void checkPersonAccountExist()
        {
            var unitOfWork = new UnitOfWork(new DbContextFactory(null));

            PersonLogic PersonLogic = new PersonLogic(unitOfWork);
            //Paramaters to pass. Code and UserId
            var accountExist = PersonLogic.checkPersonAccountExist(1,1);

        }
    }
}
