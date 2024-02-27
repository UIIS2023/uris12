﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Preparation.API.Data;

#nullable disable

namespace Preparation.API.Migrations
{
    [DbContext(typeof(PreparationDbContext))]
    partial class PreparationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Preparation.API.Entities.Announcement", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnnouncementStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("LicitationGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.ToTable("Announcements");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            AnnouncementStatus = 0,
                            LicitationGuid = new Guid("8de0c01b-b7b0-4df2-1001-3df21b91a0bb")
                        },
                        new
                        {
                            Guid = new Guid("8da0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            AnnouncementStatus = 2,
                            LicitationGuid = new Guid("8de0c01b-b7b0-4df2-2002-3df21b91a0bb")
                        });
                });

            modelBuilder.Entity("Preparation.API.Entities.Document", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AnnouncementGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCertified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentStatus")
                        .HasColumnType("int");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("AnnouncementGuid");

                    b.HasIndex("ReferenceNumber")
                        .IsUnique()
                        .HasFilter("[ReferenceNumber] IS NOT NULL");

                    b.ToTable("Documents");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            AnnouncementGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            DateCertified = new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateSubmitted = new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DocumentStatus = 0,
                            DocumentType = 0,
                            ReferenceNumber = "34432564789541231211",
                            Template = "Sablon dokumenta"
                        },
                        new
                        {
                            Guid = new Guid("8de0c01b-b4b0-4df2-9009-3df21b91a0bb"),
                            AnnouncementGuid = new Guid("8da0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            DateCertified = new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateSubmitted = new DateTime(2021, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DocumentStatus = 0,
                            DocumentType = 0,
                            ReferenceNumber = "34432564789541299211",
                            Template = "Sablon dokumenta"
                        });
                });

            modelBuilder.Entity("Preparation.API.Entities.Document", b =>
                {
                    b.HasOne("Preparation.API.Entities.Announcement", "Announcement")
                        .WithMany("Documents")
                        .HasForeignKey("AnnouncementGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Announcement");
                });

            modelBuilder.Entity("Preparation.API.Entities.Announcement", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}