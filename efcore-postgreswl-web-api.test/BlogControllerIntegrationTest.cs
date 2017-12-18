using System.Collections.Generic;
using System.Linq;
using efcore_postgresql_web_api.Controllers;
using efcore_postgresql_web_api.Entities;
using efcore_postgresql_web_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace efcore_postgreswl_web_api.test
{
    [TestClass]
    public class BlogControllerIntegrationTest
    {
        private Scenario scenario;
        
    private class Scenario
        {
        private BlogRepository BlogRepository { get; }
            public BlogContext Context { get; }
            public BlogsController Sut { get;}
            private DbContextOptions Options { get; } =
                new DbContextOptionsBuilder()
                    .UseNpgsql("Server = 127.0.0.1;Port=5432;Database=BlogDb;User Id=root;Password=root")
                    .Options;

            public Scenario()
            {
                Context = new BlogContext(Options);
                BlogRepository = new BlogRepository(Context);
                Sut = new BlogsController(BlogRepository);
                EmptyDatabase();
            }

            private void EmptyDatabase()
            {
                Context.Database.EnsureDeleted();
                Context.Database.EnsureCreated();
            }

    }


        [TestInitialize]
        public void Initialize()
        {
            scenario = new Scenario();
        }

        [TestMethod]
        public void Post_BlogUrlTest_BlogUrlTest()
        {
            var url = "test";
            var blog = new Blog() {Url = url};
            scenario.Sut.Post(blog);
            
            var testResult = scenario.Context.Blogs.FirstOrDefault();
            
            Assert.AreEqual(url, testResult.Url);
        }

        [TestMethod]
        public void GetAll_ExistTwoBlogs_ExpectTwoBlogs()
        {
            var url = "test1";
            var blog1 = new Blog() { Url = url };
            scenario.Context.Blogs.Add(blog1);
            var url2 = "test2";
            var blog2 = new Blog() { Url = url2 };
            scenario.Context.Blogs.Add(blog2);
            scenario.Context.SaveChanges();

            var actionResult = scenario.Sut.GetAll();
            var okObject = actionResult as OkObjectResult;
            var result = (List<Blog>)okObject.Value;

            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetAll_ExistBlogWith2Posts_ExpectBlogWith2Posts()
        {
            var url = "Bestaande blog";
            var blog = new Blog() { Url = url };
            var blogEntityEntry = scenario.Context.Blogs.Add(blog);
            var post1 = new Post() { BlogId = blogEntityEntry.Entity.BlogId, Content = "test post", Title = "Post1" };
            var post2 = new Post() { BlogId = blogEntityEntry.Entity.BlogId, Content = "bla bla", Title = "Post2" };
            scenario.Context.Posts.Add(post1);
            scenario.Context.Posts.Add(post2);
            scenario.Context.SaveChanges();

            var actionResult = scenario.Sut.GetAll();
            var okObject = actionResult as OkObjectResult;
            var result = (List<Blog>)okObject.Value;

            Assert.AreEqual(2, result[0].Posts.Count);
        }
    }
}
