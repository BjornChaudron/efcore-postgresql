using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using efcore_postgresql_web_api.Entities;
using efcore_postgresql_web_api.Repositories;

namespace efcore_postgresql_web_api.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private IRepository<Post> Repository { get; }

        public PostsController(IRepository<Post> repository)
        {
            Repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Post post)
        {
            Repository.Add(post);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Post post)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


