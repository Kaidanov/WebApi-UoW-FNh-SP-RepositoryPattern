using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnitOfWork.Domain.Entities;
using UnitOfWork.Domain.Services;

namespace UnitOfWork.WebApi.Controllers
{
    public class TestController : ApiController
    {

        private IProductService _productService;

        public TestController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: api/Test
        public IEnumerable<Product> Get()
        {
            return _productService.SqlQueryList();
        }

        // GET: api/Test/5
        public Product Get(int id)
        {
            return _productService.SqlQuery(id);
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }
}
