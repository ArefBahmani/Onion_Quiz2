using App.Domain.Core.CardToCard.Card.Entity;
using App.Domain.Core.CardToCard.Transaction.Entity;
using App.Domain.Core.CardToCard.User.Entity;
using App.Infra.Data.Db.SqlServer.Ef.Config;
using Microsoft.EntityFrameworkCore;
using static App.Infra.Data.Db.SqlServer.Ef.Config.TransactionConfig;
using static App.Infra.Data.Db.SqlServer.Ef.Config.UserConfig;

namespace App.Infra.Data.Db.SqlServer.Ef.Db
{
    public class AppDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-J6I42F2\SQLEXPRESS;Initial Catalog=cw_18;User ID=SA;Password=123456;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardConfig());
            modelBuilder.ApplyConfiguration(new transactionConfig());
            modelBuilder.ApplyConfiguration(new UserConfigs());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Transactionn> Transactionns { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
