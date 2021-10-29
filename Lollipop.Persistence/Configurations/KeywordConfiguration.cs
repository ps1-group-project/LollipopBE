namespace Lollipop.Persistence.Configurations
{
    using Lollipop.Core.Models;
    using Lollipop.Persistence.RelationClasses;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class KeywordConfiguration : IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder
                .HasMany(x => x.Advertisements)
                .WithMany(x => x.Keywords)
                .UsingEntity<AdvertisementKeyword>
                    (x => x.HasOne(x => x.Advertisement).WithMany().HasForeignKey(x => x.AdvertisementId),
                    x => x.HasOne(x => x.Keyword).WithMany().HasForeignKey(x => x.KeywordId));
                    
        }
    }
}
