using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using efcore_postgresql_web_api.Entities;

namespace efcore_postgresql_web_api.Design
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.PostId);
            builder.Property(p => p.Title);
            builder.Property(p => p.Content);
            builder.Property(p => p.BlogId);
        }
    }
}
