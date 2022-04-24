namespace Shortme.Domain
{
    public interface IShortingService 
    {
        Url GenerateShortUrl(string longUrl);
    }
}
