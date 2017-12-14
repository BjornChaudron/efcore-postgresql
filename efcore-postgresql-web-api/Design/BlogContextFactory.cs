using efcore_postgresql_web_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace efcore_postgresql_web_api.Design
{
    public class BlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            return new BlogContext(new DbContextOptionsBuilder()
                .UseNpgsql(@"Host=localhost;Database=BlogDb;Username=root;Password=root")
                .Options);
        }

    }
}
