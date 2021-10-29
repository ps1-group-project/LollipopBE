namespace Lollipop.Persistence.DbContext
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Lollipop.Core.Models;
    public class LollipopDbContext : DbContext
    {
        public DbSet<Advertisement> Advertisements {get;set;}
        public DbSet<AttributeC> Attributes {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<ForbiddenWord> ForbiddenWords{get;set;}
        public DbSet<Keyword> Keywords{get;set;}
        public DbSet<Message> Messages{get;set;}

        public LollipopDbContext(DbContextOptions<LollipopDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LollipopDbContext).Assembly);
        }
    }
}
