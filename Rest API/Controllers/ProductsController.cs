using AutoMapper;
using SampleAPI.Models;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace SampleAPI.Controllers
{
    public class ProductsController : ApiController
    {
        private IGenericRepository<Product> repository = null;

        // constructors
        public ProductsController()
        {
            this.repository = new GenericRepository<Product>();
        }

        public ProductsController(IGenericRepository<Product> repository)
        {
            this.repository = repository;
        }

        // GET api/products
        [SwaggerOperation("GetAll")]
        public IHttpActionResult Get()
        {
            return Ok(Mapper.Map<List<ProductDTO>>((List<Product>)repository.SelectAll()));
        }

        // GET api/products/1
        [SwaggerOperation("GetById")]
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Get(int id)
        {
            var product = Mapper.Map<ProductDTO>(repository.SelectByID(id));
            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}
