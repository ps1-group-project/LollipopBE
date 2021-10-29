namespace Lollipop.Persistence.RelationClasses
{
    using Lollipop.Core.Models;

    public class AdvertisementCategory
    {
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement{get;set;}
        public int CategoryId { get; set; }
        public Category Category{get;set;}
    }
}
