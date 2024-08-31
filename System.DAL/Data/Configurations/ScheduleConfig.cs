using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.DAL.Models;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace System.DAL.Data.Configurations
{
    public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id);




            builder.HasIndex(s => new { s.Name, s.GroupNameId }).IsUnique();


            //builder.Property(s => s.GroupNameId)
            // .IsRequired(false); // Make the GroupNameId column nullable


            builder.HasOne(s => s.GroupName)
                   .WithMany(g => g.Schedules)
                   .HasForeignKey(s => s.GroupNameId);
                   



           













        }
    }
}



