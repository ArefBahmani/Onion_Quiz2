﻿// <auto-generated />
using System;
using App.Infra.Data.Db.SqlServer.Ef.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infra.Data.Db.SqlServer.Ef.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241227131516_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Core.CardToCard.Card.Entity.Card", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardId"));

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FalsePassword")
                        .HasColumnType("int");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CardId");

                    b.HasIndex("UserId");

                    b.ToTable("Cards", (string)null);

                    b.HasData(
                        new
                        {
                            CardId = 1,
                            Balance = 10000f,
                            CardNumber = "5859831062637730",
                            FalsePassword = 0,
                            HolderName = "Tejarat",
                            IsActive = true,
                            Password = "1111",
                            UserId = 1
                        },
                        new
                        {
                            CardId = 2,
                            Balance = 10000f,
                            CardNumber = "5859831133777580",
                            FalsePassword = 0,
                            HolderName = "Tejarat",
                            IsActive = true,
                            Password = "1111",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("App.Domain.Core.CardToCard.Transaction.Entity.Transactionn", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("AtTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinationCardid")
                        .HasColumnType("int");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<int>("SourceCardid")
                        .HasColumnType("int");

                    b.HasKey("TransactionId");

                    b.HasIndex("DestinationCardid");

                    b.HasIndex("SourceCardid");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("App.Domain.Core.CardToCard.User.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTimeAdd")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateTimeAdd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Rasool",
                            LastName = "Yakta"
                        },
                        new
                        {
                            Id = 2,
                            DateTimeAdd = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Aref",
                            LastName = "Bahmani"
                        });
                });

            modelBuilder.Entity("App.Domain.Core.CardToCard.Card.Entity.Card", b =>
                {
                    b.HasOne("App.Domain.Core.CardToCard.User.Entity.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Core.CardToCard.Transaction.Entity.Transactionn", b =>
                {
                    b.HasOne("App.Domain.Core.CardToCard.Card.Entity.Card", "DestinationCard")
                        .WithMany("TransactionnsAsDestination")
                        .HasForeignKey("DestinationCardid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("App.Domain.Core.CardToCard.Card.Entity.Card", "SourceCard")
                        .WithMany("TransactionnsAsSource")
                        .HasForeignKey("SourceCardid")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DestinationCard");

                    b.Navigation("SourceCard");
                });

            modelBuilder.Entity("App.Domain.Core.CardToCard.Card.Entity.Card", b =>
                {
                    b.Navigation("TransactionnsAsDestination");

                    b.Navigation("TransactionnsAsSource");
                });

            modelBuilder.Entity("App.Domain.Core.CardToCard.User.Entity.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}