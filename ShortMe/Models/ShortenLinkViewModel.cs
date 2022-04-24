using System.ComponentModel.DataAnnotations;

namespace ShortMe.Models
{
    public class ShortenLinkViewModel
    {
        [Display(Name = "Original URL")]
        public string OriginalUrl { get; set; }

        [Display(Name = "Short URL")]
        public string ShortUrl { get; set; }
    }
}
