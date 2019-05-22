using AutoMapper;
using SampleAPI.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    public class UsersController : ApiController
    {
        private IGenericRepository<User> repository = null;

        // constructors
        public UsersController()
        {
            this.repository = new GenericRepository<User>();
        }

        public UsersController(IGenericRepository<User> repository)
        {
            this.repository = repository;
        }

        // GET api/users
        [SwaggerOperation("GetAll")]
        public IHttpActionResult Get()
        {
            return Ok(Mapper.Map<List<UserDTO>>((List<User>)repository.SelectAll()));
        }

        // GET api/users/1
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(int id)
        {
            var user = Mapper.Map<UserDTO>(repository.SelectByID(id));
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
