namespace Lollipop.Persistence.RelationClasses
{
    using Lollipop.Core.Models;

    public class AdvertisementKeyword
    {
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
    }
}
