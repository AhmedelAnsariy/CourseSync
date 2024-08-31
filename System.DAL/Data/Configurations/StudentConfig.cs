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
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);




            builder.HasIndex(s => s.Phone).IsUnique();




            builder.HasOne(s => s.Schedule)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.ScheduleId);
               

               
          




        }
    }
}
