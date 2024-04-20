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
    internal class OrdersEntityConfigs : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.Ignore(x => x.TotalPrice);
            builder.Property(x => x.OrderDate).HasDefaultValue(DateTime.Now.Date);
        }
    }
}
