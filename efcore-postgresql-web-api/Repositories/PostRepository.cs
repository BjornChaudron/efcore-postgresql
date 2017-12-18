
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
        private BlogContext Context { get; }

        public PostRepository(BlogContext context)
        {
            Context = context;
        }

        public void Add(Post entity)
        {
                Context.Posts.Add(entity);
                Context.SaveChanges();
        }

        public List<Post> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
