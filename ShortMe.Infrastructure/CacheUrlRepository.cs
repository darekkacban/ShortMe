using Shortme.Domain;
using System.Collections.Concurrent;

namespace ShortMe.Infrastructure
{
    public class CacheUrlRepository : IUrlRepository
    {
        private static readonly ConcurrentDictionary<string, Url> Urls = new ConcurrentDictionary<string, Url>();

        public void AddUrl(Url url)
        {
            Urls.TryAdd(url.ShortUrl, url);
        }

        public Url GetUrl(string shortUrl)
        {
            Url value;
            Urls.TryGetValue(shortUrl, out value);

            return value;
        }

        IEnumerable<Url> IUrlRepository.GetAllUrls()
        {
            return Urls.Values;
        }
    }
}