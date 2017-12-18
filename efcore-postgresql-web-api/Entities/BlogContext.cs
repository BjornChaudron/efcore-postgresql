using System;
using Microsoft.EntityFrameworkCore;
using efcore_postgresql_web_api.Design;

namespace efcore_postgresql_web_api.Entities
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            //modelBuilder.Entity<Blog>()
            //    .Property(b => b.BlogId)
            //    .ValueGeneratedOnAdd();
            base.OnModelCreating(modelBuilder);
        }
    }
}