using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShortLinkService.Dto.Interfaces;
using ShortLinkService.Web.Contracts;
using ShortLinkService.Web.Infrastructure.Exceptions;

namespace ShortLinkService.Web.ApiControllers
{
    [Route("api/v1/")]
    public class LinksController : Controller
    {
        private readonly IShortLinkService _shortLinkService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IBitmapCodeGenerator _bitmapCodeGenerator;
        private readonly string _dirName = "img";
        private readonly string _rootDir;

        public LinksController(
            IShortLinkService shortLinkService,
            IWebHostEnvironment hostingEnvironment,
            IBitmapCodeGenerator bitmapCodeGenerator)
        {
            _shortLinkService = shortLinkService;
            _bitmapCodeGenerator = bitmapCodeGenerator;
            _hostingEnvironment = hostingEnvironment;
            _rootDir = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", _dirName);
        }

        [HttpPost]
        [Route("saveurl")]
        public async Task<CreateAliasResponse> GenerateToken([FromBody] CreateAliasRequest request) 
        {
            bool valid = _shortLinkService.ValidateLink(request.OriginalUrl);
            if (valid)
            {
                string token = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);
                string domain = $"{Request.Scheme}://{Request.Host}/".ToUpper();
                string shortUrl = domain + token;

                Bitmap codeBitmap = _bitmapCodeGenerator.GenerateCode(shortUrl, 100);
                string fileName = $"{token}.png";
                string saveParh = Path.Combine(_rootDir, $"{token}.png");
                codeBitmap.Save(saveParh);
                codeBitmap?.Dispose();

                await _shortLinkService.AddCutLinkAsync(request.OriginalUrl, token, saveParh);
                string localPath = Path.Combine(_dirName, fileName);
                return new CreateAliasResponse(shortUrl, localPath);
            }
            else 
            {
                throw new InvalidUrlException();
            };
        }

        [HttpGet]
        public JsonResult GetUrlByToken(string token)
        {
            return null;
        }
    }
}