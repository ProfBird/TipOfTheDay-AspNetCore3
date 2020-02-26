﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TipOfTheDay_Core3.Models;

namespace TipOfTheDay_Core3.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TipOfTheDay_Core3.Models.AppUser", b =>
                {
                    b.Property<int>("AppUserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("AppUserID");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("TipOfTheDay_Core3.Models.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText");

                    b.Property<int?>("MemberAppUserID");

                    b.Property<int?>("TipID");

                    b.HasKey("CommentID");

                    b.HasIndex("MemberAppUserID");

                    b.HasIndex("TipID");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("TipOfTheDay_Core3.Models.Language", b =>
                {
                    b.Property<int>("LanguageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("TipID");

                    b.HasKey("LanguageID");

                    b.HasIndex("TipID");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("TipOfTheDay_Core3.Models.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<int?>("TipID");

                    b.HasKey("TagID");

                    b.HasIndex("TipID");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("TipOfTheDay_Core3.Models.Tip", b =>
                {
                    b.Property<int>("TipID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MemberAppUserID");

                    b.Property<string>("TipText");

                    b.HasKey("TipID");

                    b.HasIndex("MemberAppUserID");

                    b.ToTable("Tip");
                });

            modelBuilder.Entity("TipOfTheDay_Core3.Models.Comment", b =>
                {
                    b.HasOne("TipOfTheDay_Core3.Models.AppUser", "Member")
                        .WithMany()
                        .HasForeignKey("MemberAppUserID");

                    b.HasOne("TipOfTheDay_Core3.Models.Tip")
                        .WithMany("Comments")
                        .HasForeignKey("TipID");
                });

            modelBuilder.Entity("TipOfTheDay_Core3.Models.Language", b =>
                {
                    b.HasOne("TipOfTheDay_Core3.Models.Tip")
                        .WithMany("Languages")
                        .HasForeignKey("TipID");
                });

            modelBuilder.Entity("TipOfTheDay_Core3.Models.Tag", b =>
                {
                    b.HasOne("TipOfTheDay_Core3.Models.Tip")
                        .WithMany("Tags")
                        .HasForeignKey("TipID");
                });

            modelBuilder.Entity("TipOfTheDay_Core3.Models.Tip", b =>
                {
                    b.HasOne("TipOfTheDay_Core3.Models.AppUser", "Member")
                        .WithMany()
                        .HasForeignKey("MemberAppUserID");
                });
#pragma warning restore 612, 618
        }
    }
}