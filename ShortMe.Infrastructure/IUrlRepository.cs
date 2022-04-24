using Shortme.Domain;

namespace ShortMe.Infrastructure
{
    public interface IUrlRepository
    {
        IEnumerable<Url> GetAllUrls();
        void AddUrl(Url url);
        public Url GetUrl(string shortUrl);
    }
}