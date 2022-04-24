using Xunit;

namespace Shortme.Domain.Test
{
    public class ShortingServiceTest
    {
        [Fact]
        public void ShouldGenerateShortUrl()
        {
            var service = new ShortingService();
            var longUrl = "www.bbc.com";
            var shortUrl = service.GenerateShortUrl(longUrl);

            Assert.Equal(longUrl, shortUrl);
        }
    }
}