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
    internal class UsersEntityConfigs : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasMany(x => x.Orders).WithOne(x => x.User);

            builder.HasMany(x => x.Reviews).WithOne(x => x.User);

            builder.Property(x => x.Username).HasMaxLength(20);
            builder.Property(x => x.Password).HasMaxLength(20);

            builder.HasAlternateKey(x => x.Username);
        }
    }
}
