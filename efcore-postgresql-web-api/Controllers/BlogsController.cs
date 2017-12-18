using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using efcore_postgresql_web_api.Entities;
using efcore_postgresql_web_api.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace efcore_postgresql_web_api.Controllers
{

    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private IRepository<Blog> Repository { get; }

        public BlogsController(IRepository<Blog> repository)
        {
            Repository = repository;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Blog blog)
        {
            Repository.Add(blog);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Repository.GetAll());
        }

    }
}
