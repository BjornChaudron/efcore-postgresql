using System.Linq;
using efcore_postgresql_web_api.Entities;
using efcore_postgresql_web_api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace efcore_postgreswl_web_api.test
{
    [TestClass]
    public class BlogRepositoryTest
    {
        private Scenario scenario;
        
        private class Scenario
        {
            public BlogRepository BlogRepository { get; }
            public BlogContext Context { get; }
            private DbContextOptions Options { get; } =
                new DbContextOptionsBuilder()
                    .UseInMemoryDatabase("Blogdb")
                    .Options;

            public Scenario()
            {
                Context = new BlogContext(Options);
                BlogRepository = new BlogRepository(Context);
                EmptyDatabase();
            }

            public void EmptyDatabase()
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
        public void Add_BlogUrlTest_BlogUrlTest()
        {
            var url = "test";
            var blog = new Blog() {Url = url};
            

            scenario.BlogRepository.Add(blog);
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

            var testResult = scenario.BlogRepository.GetAll();

            Assert.AreEqual(2, testResult.Count);
        }
    }
}
