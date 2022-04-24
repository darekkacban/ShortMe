using Microsoft.AspNetCore.Mvc;
using Shortme.Domain;
using ShortMe.Infrastructure;
using ShortMe.Models;

namespace ShortMe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShortingService _service;
        private readonly IUrlRepository _urlRepository;

        public HomeController(ILogger<HomeController> logger, IShortingService service, IUrlRepository urlRepository)
        {
            _logger = logger;
            _service = service;
            _urlRepository = urlRepository;
        }

        [HttpGet]
        [Route("short/{hash}")]
        public IActionResult Short(string hash)
        {
            _logger.LogInformation($"Client call to short url with hash: {hash}");

            var url = _urlRepository.GetUrl(hash);
            if (url != null)
            {
                return RedirectPermanent($"{this.Request.Scheme}://{url.OriginalUrl}");
            } else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult Index(string shortUrl)
        {
            if (shortUrl == null)
            {
                return View();
            }

            var url = _urlRepository.GetUrl(shortUrl);

            var urlViewModel = new ShortenLinkViewModel
            {
                OriginalUrl = url.OriginalUrl,
                ShortUrl = GetShortUrl(url.ShortUrl)
            };

            return View(urlViewModel);
        }

        private string GetShortUrl(string hash)
        {
            return $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/short/{hash}";
        }

        [HttpPost]
        public IActionResult Index(ShortenLinkViewModel model)
        {
            var url = _service.GenerateShortUrl(model.OriginalUrl);
            _urlRepository.AddUrl(url);

            return Index(url.ShortUrl);
        }

        [HttpGet]
        public IActionResult All()
        {
            var allUrls = _urlRepository.GetAllUrls();

            var urls = allUrls.Select(url => new ShortenLinkViewModel
            {
                OriginalUrl = url.OriginalUrl,
                ShortUrl = GetShortUrl(url.ShortUrl)
            });

            return View(urls);
        }
    }
}