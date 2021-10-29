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
//by stworzyc nowa migracje
//dotnet ef migrations add --startup-project .\Lollipop.API\Lollipop.API.csproj --project .\Lollipop.Persistence\Lollipop.Persistence.csproj <nazwa migracji>
//by uaktualnic db(jesli istnieje i jest działające połączenie)
//dotnet ef migrations update --startup-project .\Lollipop.API\Lollipop.API.csproj --project .\Lollipop.Persistence\Lollipop.Persistence.csproj