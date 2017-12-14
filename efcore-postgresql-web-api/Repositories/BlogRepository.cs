
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
        private DbContextOptions Options { get; }

        public BlogRepository(DbContextOptions options)
        {
            Options = options;
        }

        public void Add(Blog entity)
        {
            using (var db = new BlogContext(Options))
            {
                db.Blogs.Add(entity);
                db.SaveChanges();
            }
        }
    }
}
