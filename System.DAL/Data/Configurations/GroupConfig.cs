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
    public class GroupConfig : IEntityTypeConfiguration<GroupName>
    {
        public void Configure(EntityTypeBuilder<GroupName> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasIndex(s => s.DayName).IsUnique();


         


        }
    }
}
