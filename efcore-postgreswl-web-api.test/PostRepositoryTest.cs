using System.Linq;
using efcore_postgresql_web_api.Entities;
using efcore_postgresql_web_api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace efcore_postgreswl_web_api.test
{
    [TestClass]
    public class PostRepositoryTest
    {
        private Scenario scenario;
        
        private class Scenario
        {
            public PostRepository PostRepository { get; }
            public BlogContext Context { get; }
            private DbContextOptions Options { get; } =
                new DbContextOptionsBuilder()
                    .UseInMemoryDatabase("Blogdb")
                    .Options;

            public Scenario()
            {
                Context = new BlogContext(Options);
                PostRepository = new PostRepository(Context);
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
        public void Add_PostTitlePost1_PostTitlePost1()
        {
            var url = "Bestaande blog";
            var blog = new Blog() {Url = url};
            

            var blogEntityEntry = scenario.Context.Blogs.Add(blog);
            var post = new Post() { BlogId = blogEntityEntry.Entity.BlogId,Content = "test post", Title = "Post1"};

            scenario.PostRepository.Add(post);

            var testResult = scenario.Context.Posts.FirstOrDefault();
            
            Assert.AreEqual(post.Title, testResult.Title);
        }

        [TestMethod]
        public void Add_PostTitlePost1AddToBestaandeBlog_PostTitlePost1WithBestaandeBlog()
        {
            var url = "Bestaande blog";
            var blog = new Blog() { Url = url };


            var blogEntityEntry = scenario.Context.Blogs.Add(blog);
            var post = new Post() { BlogId = blogEntityEntry.Entity.BlogId, Content = "test post", Title = "Post1" };

            scenario.PostRepository.Add(post);

            var testResult = scenario.Context.Posts.FirstOrDefault();

            Assert.AreEqual(blog.Url, testResult.Blog.Url);
        }


    }
}
