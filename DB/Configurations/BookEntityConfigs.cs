using Exam.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data.Configurations
{
    internal class BookEntityConfigs : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Reviews)
                   .WithOne(x => x.Book);

            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Books);

            builder.HasOne(x => x.Publisher)
                   .WithMany(x => x.Books);

            builder.HasOne(x => x.Genre)
                   .WithMany(x => x.Books);

            builder.HasMany(x => x.Orders)
                   .WithMany(x => x.Books);

            builder.Property(x => x.ISBN).HasMaxLength(14);
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Rating).HasMaxLength(2);

            builder.HasAlternateKey(x => x.ISBN);

            builder.Ignore(x => x.Rating);
        }
    }
}
