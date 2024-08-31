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
    public class AttendenceConfig : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .ValueGeneratedOnAdd();


            builder.HasOne(a => a.Student)
              .WithMany(s => s.Attendances)
              .HasForeignKey(a => a.StudentId);
        }
    }
}
