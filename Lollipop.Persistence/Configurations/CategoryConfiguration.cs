using Lollipop.Core.Models;
using Lollipop.Persistence.RelationClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lollipop.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasMany(x => x.Advertisements)
                .WithMany(x => x.Categories)
                .UsingEntity<AdvertisementCategory>
                    (x => x.HasOne(x => x.Advertisement).WithMany().HasForeignKey(x => x.AdvertisementId),
                    x => x.HasOne(x => x.Category).WithMany().HasForeignKey(x => x.CategoryId));
                    
        }
    }
}
