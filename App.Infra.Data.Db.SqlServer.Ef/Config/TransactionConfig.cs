using App.Domain.Core.CardToCard.Transaction.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.Data.Db.SqlServer.Ef.Config
{
    public class TransactionConfig
    {
        public class transactionConfig : IEntityTypeConfiguration<Transactionn>
        {
            public void Configure(EntityTypeBuilder<Transactionn> builder)
            {
                builder.HasKey(x => x.TransactionId);
                builder.ToTable("Transactions");

                builder.HasOne(x => x.SourceCard)
                    .WithMany(x => x.TransactionnsAsSource)
                    .HasForeignKey(x => x.SourceCardid)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.DestinationCard)
                    .WithMany(x => x.TransactionnsAsDestination)
                    .HasForeignKey(x => x.DestinationCardid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}
