using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TipOfTheDay.Models;

namespace TipOfTheDay.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Tip tip1 = new Tip() { TipID = 1, TipText = "The first tip" };
            Tip tip2 = new Tip() { TipID = 2, TipText = "Another tip" };
            Tip tip3 = new Tip() { TipID = 3, TipText = "Yet another tip" };
            builder.Entity<Tip>().HasData(tip1, tip2, tip3);

            Tag tag1 = new Tag() { TagID = 1, Category = "Cat-A"};
            Tag tag2 = new Tag() { TagID = 2, Category = "Cat-B" }; 
            Tag tag3 = new Tag() { TagID = 3, Category = "Cat-C" }; 
            builder.Entity<Tag>().HasData(tag1, tag2, tag3);    
        }
        public DbSet<Tip> Tip { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
