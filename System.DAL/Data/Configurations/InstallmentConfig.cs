using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.DAL.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.DAL.Data.Configurations
{
    public class InstallmentConfig : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne(i => i.Student)
                .WithMany(s => s.Installments)
                .HasForeignKey(i => i.StudentId);

        }
    }
}
