using Shortme.Domain;
using Xunit;

namespace ShortMe.Domain.Tests
{
    public class ShortingServiceTest
    {
        [Fact]
        public void ShouldGenerateShortUrl()
        {
            var service = new ShortingService();
            var longUrl = "www.bbc.com";
            var url = service.GenerateShortUrl(longUrl);

            Assert.Equal(longUrl, url.OriginalUrl);
            Assert.Equal(6, url.ShortUrl.Length);
        }
    }
}