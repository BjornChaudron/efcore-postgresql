using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using efcore_postgresql_web_api.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Threading;
using efcore_postgresql_web_api.Entities;

namespace efcore_postgresql_web_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("BLOG_DB_CONNECTION_STRING")
                ?? "Server = 127.0.0.1;Port=5432;Database=BlogDb;User Id=root;Password=root";
            services.AddEntityFrameworkNpgsql().AddDbContext<BlogContext>(options =>
            {
                options.UseNpgsql(connectionString);
            }, ServiceLifetime.Transient, ServiceLifetime.Singleton);
            services.AddTransient<IRepository<Blog>, BlogRepository>();
            services.AddTransient<IRepository<Post>, PostRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BlogContext context )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            void CreateDatabase(int numberOfTries)
            {

                try
                {
                    context.Database.Migrate();
                }
                catch (SqlException sqle)
                {
                    if (numberOfTries == 0)
                    {
                        throw new Exception("Not able to connect to database", sqle);
                    }
                    Console.WriteLine($"Retrying to connect to database, {0 + numberOfTries} tries left ");
                    Thread.Sleep(1000);
                    CreateDatabase(numberOfTries - 1);

                }
            }

            CreateDatabase(100);

            app.UseMvc();
        }
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
   
}
