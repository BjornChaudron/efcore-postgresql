
using efcore_postgresql_web_api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcore_postgresql_web_api.Repositories
{
    public class PostRepository : IRepository<Post>
    {
        private DbContextOptions Options { get; }

        public PostRepository(DbContextOptions options)
        {
            Options = options;
        }

        public void Add(Post entity)
        {
            using (var db = new BlogContext(Options))
            {
                db.Posts.Add(entity);
                db.SaveChanges();
            }
        }
    }
}
