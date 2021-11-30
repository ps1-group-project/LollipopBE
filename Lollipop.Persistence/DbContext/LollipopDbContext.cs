namespace Lollipop.Persistence.DbContext
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Lollipop.Core.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    //using Microsoft.AspNetCore.
    public class LollipopDbContext : IdentityDbContext<AppUser, IdentityRole,string>
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
//dotnet ef migrations add --startup-project .\Lollipop.API\Lollipop.API.csproj --project .\Lollipop.Persistence\Lollipop.Persistence.csproj <nazwa migracji>
//dotnet ef migrations update --startup-project .\Lollipop.API\Lollipop.API.csproj --project .\Lollipop.Persistence\Lollipop.Persistence.csproj
//dotnet ef database update --startup-project .\Lollipop.API\Lollipop.API.csproj --project .\Lollipop.Persistence\Lollipop.Persistence.csproj
//Update-Database