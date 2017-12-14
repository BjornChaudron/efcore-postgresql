
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using efcore_postgresql_web_api.Entities;

namespace efcore_postgresql_web_api.Design
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(b => b.BlogId);
            builder.Property(b => b.BlogId)
                .ValueGeneratedOnAdd();
            builder.Property(b => b.Url);
        }
    }
}
