using App.Domain.Core.CardToCard.Card.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Config
{
    public class CardConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.CardId);




            builder.ToTable("Cards");
            builder.HasData(new List<Card>()
            {
                new Card(){CardId = 1,UserId = 1,CardNumber ="5859831062637730",Password = "1111",HolderName ="Tejarat",Balance =10000},
                new Card(){CardId = 2,UserId = 2,CardNumber ="5859831133777580",Password = "1111",HolderName ="Tejarat",Balance =10000}

            });
        }
    }
}
