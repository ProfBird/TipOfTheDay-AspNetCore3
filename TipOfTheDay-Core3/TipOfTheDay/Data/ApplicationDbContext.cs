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
        public DbSet<Tip> Tip { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
