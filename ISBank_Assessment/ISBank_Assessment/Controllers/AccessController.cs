using AutoMapper;
using ISBank_Assessment.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using ISBank_Assessment.BE;
using Newtonsoft.Json;
using ISBank_Assessment.DL;

namespace ISBank_Assessment.Controllers
{
    /// <summary>
    /// AccessController class
    /// </summary>
    [RoutePrefix("api/Access")]
    public class AccessController : ApiController
    {
        private IUserLogic _user;
        //UnitOfWork unitOfWork = new UnitOfWork(new DbContextFactory(null));
        private IMapper _mapper;

        public AccessController()
        {
        }
        /// <summary>
        /// AccessController Non-Default Constructor 
        /// </summary> 
        /// <param name="UserLogic">IUserLogic object injected through Unity, providing UserLogic functionality</param>
        /// <param name="Mapper">Mapper object injected through Unity, providing object mapping functionality</param> 
        public AccessController(IUserLogic UserLogic, IMapper Mapper)
        {
            _user = UserLogic;
            _mapper = Mapper;
        }

        /// <summary>
        /// Checks if the user password is correct
        /// </summary>
        /// <param name="Password"></param>
        /// <param name="Email">Email</param>
        /// <remarks>Checks if the user password is correct</remarks>
        /// <returns>Boolean</returns>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[Route("IsValidPassword")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult IsValidPassword(string Password, string Email)
        {
            return Ok(_user.IsValidPassword(Password, Email));
        }

        /// <summary>
        /// Validate User Login
        /// </summary>
        /// <param name="Password"></param>
        /// <param name="Email">Email</param>
        /// <remarks>Validate User Login</remarks>
        /// <returns>Boolean</returns>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(bool))]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //[Route("IsValidPassword")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult ValidateUserLogin(string Email,string Password)
        {
            return Ok(_user.ValidateUserLogin(Email, Password));
        }

        /// <summary>
        /// Get LoggedIn user
        /// </summary>
        /// <param name="UserName">Email</param>
        /// <remarks>Finds the LoggedIn user</remarks>
        /// <returns>UserEntity</returns>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(UserEntity))]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetLoginUser(string UserName)
        {
            User user = _user.GetLoginUser(UserName);

            var userEntity = _mapper.Map<UserEntity>(user);
                
            return Ok(userEntity);
        }

        /// <summary>
        /// Updates the login count of the logged in user by 1
        /// </summary>
        /// <remarks>Updates the login count of the logged in user by 1</remarks>        
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(int))]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        //TODO - [Route("UpdateLoginCount")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult UpdateLoginCount()
        {
            string userName = Request.Headers.Where(a => a.Key == "x-ms-username").FirstOrDefault().Value.FirstOrDefault();

            return Ok(_user.UpdateLoginCount(userName));
        }

        #region Modify
        /// <summary>
        /// Adds a new user
        /// </summary>
        /// <param name="User">User to add</param>        
        /// <remarks>Adds a new User</remarks>
        /// <returns>Created User</returns>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(UserEntity))]
        [SwaggerResponse(HttpStatusCode.Unauthorized)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        [HttpPost]
        //[CustomAuthorize("EditUsers")]
        public IHttpActionResult AddUser([FromBody] UserEntity User)
        { 

            //int userId = _user.GetUserIdByUsername(Request.Headers.Where(a => a.Key == "x-ms-username").FirstOrDefault().Value.FirstOrDefault());
            User addedUser = _user.CreateLoginUser(User, User.UserId);

            UserEntity addedUserEntity = _mapper.Map<UserEntity>(addedUser);

            return Ok(addedUserEntity);
        }
        #endregion
    }
}
