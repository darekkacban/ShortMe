using System.Text;
using System.Security.Cryptography;

namespace Shortme.Domain
{
    public class ShortingService : IShortingService
    {
        public Url GenerateShortUrl(string longUrl)
        {
            var sha1 = SHA1.Create();
            var shortUrl = Convert.ToHexString(sha1.ComputeHash(Encoding.UTF8.GetBytes(longUrl)));

            var url = new Url()
            {
                OriginalUrl = longUrl,
                ShortUrl = shortUrl.Substring(0, 6)
            };

            return url;
        }
    }
}
