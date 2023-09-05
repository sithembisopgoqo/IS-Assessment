using ISBank_Assessment.UI.Common;
using ISBank_Assessment.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI;
using WebAPI.Models;

namespace ISBank_Assessment.UI.Controllers
{
    public partial class PersonController : Controller
    {
        // GET: Person
        #region Person 
        [HttpGet]
        [OutputCache(Duration = 0, NoStore = false)]
        public virtual async Task<ActionResult> GetPersons(string SearchText = null)
        {
            var UserId = SessionHelper.Get<int>("UserId");
            Person personClient = new Person(ServiceFactory.GetClient());
            GetPersonViewModel model = new GetPersonViewModel();


            model.PersonList = await personClient.GetAllPersonsAsync(UserId, SearchText);

            return View(model);
        }

        [HttpGet]
        public virtual ActionResult PersonDetails(int? Code)
        {
            var UserId = SessionHelper.Get<int>("UserId");
            Person personClient = new Person(ServiceFactory.GetClient());
            Account accountClient = new Account(ServiceFactory.GetClient());

            EditPersonModel model = new EditPersonModel();

            if (Code == null)
            {
                Code = 0;
            }

            model.Code = (int)Code;

            if (Code.HasValue && Code.Value > 0)
            {

                PersonEntity personEntity = personClient.GetPersonbyUserId(Code.Value, UserId);
                model.Code = (int)personEntity.Code;
                model.UserId = personEntity.UserId;
                model.Name = personEntity.Name;
                model.Surname = personEntity.Surname;
                model.IDNumber = personEntity.IDNumber;
                model.AccountList = accountClient.GetAllAccounts((int)personEntity.Code);

            }
            else
            {
                model.AccountList = accountClient.GetAllAccounts((int)Code, null);
            }
            //return PartialView(MVC.Person.Views.Partial.PersonDetails, model);
            return View(MVC.Person.Views.Partial.PersonDetails, model);
           
        }

        [HttpPost]
        public virtual async Task<ActionResult> SavePerson(EditPersonModel model)
        {
            var UserId = SessionHelper.Get<int>("UserId");
            Person personClient = new Person(ServiceFactory.GetClient());
            PersonEntity personEntity = new PersonEntity();

            personEntity.UserId = UserId;
            personEntity.Name = model.Name;
            personEntity.Surname = model.Surname;
            personEntity.IDNumber = model.IDNumber;

            if (model.Code > 0)
            {
                personEntity.Code = model.Code;
                await personClient.ModifyPersonAsync(personEntity);
            }
            else
            {
                await personClient.AddPersonAsync(personEntity);
            }

            return RedirectToAction(MVC.Person.GetPersons());
        }

        //[HttpPost]
        public virtual async Task<ActionResult> DeletePerson(int code)
        {

            var UserId = SessionHelper.Get<int>("UserId");
            Person personClient = new Person(ServiceFactory.GetClient());

            await personClient.RemovePersonAsync(code, UserId);

            return RedirectToAction(MVC.Person.GetPersons());
        }

        #endregion Person

        // Checks if Account is Closed
        //No transactions may be posted to closed accounts
        [AllowAnonymous]
        public virtual JsonResult CheckIfAccountIsClosed(string AccountNumber)
        {
            Account accountClient = new Account(ServiceFactory.GetClient());
            var AccountIsClosed = accountClient.CheckIfAccountIsOpenClosed(AccountNumber);

            if (AccountIsClosed == true)
            {
                return Json("Account is Closed", JsonRequestBehavior.AllowGet);
            }


            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}