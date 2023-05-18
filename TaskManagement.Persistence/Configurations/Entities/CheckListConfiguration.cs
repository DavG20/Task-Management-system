

using TaskManagement.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Persistence.Configurations.Entities
{
    public class CheckListConfiguration : IEntityTypeConfiguration<CheckList>
    {
        public void Configure(EntityTypeBuilder<CheckList> builder)
        {
            // builder.HasData(
            //     new CheckList
            //     {
            //         Id = 1,
            //         Content = "Sample Content",
            //         UserId = 1,
            //         BlogId = 1,
            //     },

            //      new CheckList
            //      {
            //          Id = 2,
            //          Content = "Sample Content",
            //          UserId = 2,
            //          BlogId = 2,
            //      }
            //     ); ;
        }


    }
}