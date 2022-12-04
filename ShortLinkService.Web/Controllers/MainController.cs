using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using ShortLinkService.Dto.Interfaces;
using System.Threading.Tasks;

namespace ShortLinkService.Web.Controllers
{
    public class MainController : Controller
    {
        private readonly IStringLocalizer<MainController> _localizer;
        private readonly IShortLinkService _shortLinkService;

        public MainController(
            IStringLocalizer<MainController> localizer,
            IShortLinkService shortLinkService)
        {
            _localizer = localizer;
            _shortLinkService = shortLinkService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("/{token}")]
        public async Task<IActionResult> Token([FromRoute]string token) 
        {
            bool exist = await _shortLinkService.IsTokenExistAsync(token);

            if (exist)
            {
                string url = await _shortLinkService.GetOriginalLinkByTokenAsync(token);
                return Redirect(url);
            }
            else 
            {
                return RedirectToAction("Index");
            }
        }
    }
}
