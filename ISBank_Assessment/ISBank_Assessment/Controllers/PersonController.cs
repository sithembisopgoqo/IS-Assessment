using AutoMapper;
using ISBank_Assessment.BE;
using ISBank_Assessment.BL;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ISBank_Assessment.Controllers
{
    /// <summary>
    /// PersonController class
    /// </summary>
    [RoutePrefix("api/Person")]
    public class PersonController : ApiController
    {
        private IPersonLogic _person;
        private IMapper _mapper;

        public PersonController()
        {
        }
        /// <summary>
        /// PersonController Non-Default Constructor 
        /// </summary> 
        /// <param name="PersonLogic">IPersonLogic object injected through Unity, providing PersonLogic functionality</param>
        /// <param name="Mapper">Mapper object injected through Unity, providing object mapping functionality</param> 
        public PersonController(IPersonLogic PersonLogic, IMapper Mapper)
        {
            _person = PersonLogic;
            _mapper = Mapper;
        }

        //TODO -CustomAuthorize
     
        #region Person
        /// <summary>
        /// Returns a list of all available PersonEntity for the specified User
        /// </summary>
        /// <returns>List of PersonEntity</returns>
        /// <param name="UserId">User Id of the User to retrieve results for</param> 
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(List<PersonEntity>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("ViewPerson")]
        public IHttpActionResult GetAllPersons(int UserId, string SearchText = null)
        {
            return Ok(_person.GetAllPersons(UserId, SearchText));
        }
        /// <summary>
        /// Returns a single PersonEntity for the specified User
        /// </summary>
        /// <returns>PersonEntity object</returns>
        /// <param name="Code">Code of the Person to retrieve results for</param> 
        /// <param name="UserId">UserId Id of the User to retrieve results for</param> 
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(PersonEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("ViewPerson")]
        public IHttpActionResult GetPersonbyUserId(int Code,int UserId)
        {
            return Ok(_person.GetPersonbyUserId(Code,UserId));
        }
        /// <summary>
        /// Add a PersonEntity object
        /// </summary>
        /// <returns>Single PersonEntity object</returns>
        /// <param name="ReasonObj">PersonEntity object to add</param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(PersonEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditPerson")]
        public IHttpActionResult AddPerson(PersonEntity PersonObj)
        {

            Person person = _person.AddPerson(_mapper.Map<Person>(PersonObj));
            return Ok(_mapper.Map<PersonEntity>(person));
        }

        /// <summary>
        /// Modify a PersonEntity object
        /// </summary>
        /// <returns>Single PersonEntity object</returns>
        /// <param name="ReasonObj">PersonEntity object to modify</param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(PersonEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditPerson")]
        public IHttpActionResult ModifyPerson(PersonEntity PersonObj)
        {
            Person Person = _person.ModifyPerson(_mapper.Map<Person>(PersonObj));
            return Ok(_mapper.Map<PersonEntity>(Person));
        }

        /// <summary>
        /// Removes PersonEntity
        /// </summary>
        /// <returns></returns>
        /// <param name="Code"></param>
        /// <param name="UserId"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(PersonEntity))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditPerson")]
        public IHttpActionResult RemovePerson(int Code,int UserId)
        {       
            _person.RemovePerson(Code, UserId);
            return Ok();
        }
        #endregion Person

        #region Validations
        /// <summary>
        /// Checks Person Acccount Exist
        /// </summary>
        /// <returns></returns>
        /// <param name="Code"></param>
        /// <param name="UserId"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("EditPerson")]
        public IHttpActionResult CheckPersonAccountExist(int Code, int UserId)
        {
            var PersonAccountExist=_person.checkPersonAccountExist(Code, UserId);
            return Ok(PersonAccountExist);
        }

        /// <summary>
        /// Checks Person Acccount Status
        /// </summary>
        /// <returns></returns>
        /// <param name="Code"></param>
        /// <param name="UserId"></param>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        //[CustomAuthorize("EditPerson")]
        public IHttpActionResult CheckPersonAccounttStatus(int Code, int UserId)
        {
            var PersonAccountExist = _person.checkPersonAccountStatus(Code, UserId);
            return Ok(PersonAccountExist);
        }
        #endregion
    }
}
