using App.Domain.Core.CardToCard.User.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Config
{
    public class UserConfig
    {
        public class UserConfigs : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(x => x.Id);
                builder.ToTable("Users");




                builder.HasData(new List<User>()
            {
                new User(){Id = 1,FirstName = "Rasool", LastName = "Yakta" },
                new User(){Id = 2,FirstName = "Aref",LastName = "Bahmani"},


            });
            }


        }
    }
}
