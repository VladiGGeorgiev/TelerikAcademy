using System;
using System.Collections.Generic;
using System.Linq;


namespace Giftable.Library.Model
{
    public class GiftModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public string SuggestedBy { get; set; }

        public string SuggestedFor { get; set; }

        public bool Bought { get; set; }

        public bool Checked { get; set; }

        public bool Seen { get; set; }
    }

    public class NewGiftModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }
    }

    public class NewSuggestedGift
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string Image { get; set; }

        public string Url { get; set; }

        public string SuggestedBy { get; set; }

        public string SuggestedFor { get; set; }
    }
}
