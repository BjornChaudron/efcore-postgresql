
using efcore_postgresql_web_api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcore_postgresql_web_api.Repositories
{
    public class BlogRepository : IRepository<Blog>
    {
        private BlogContext Context { get; }

        public BlogRepository(BlogContext context)
        {
            Context = context;
        }

        public void Add(Blog entity)
        {

            Context.Blogs.Add(entity);
            Context.SaveChanges();
           
        }

        public List<Blog> GetAll()
        {
            var test = Context.Blogs;
            var result = Context.Blogs.ToList();
            return result;

        }
    }
}
