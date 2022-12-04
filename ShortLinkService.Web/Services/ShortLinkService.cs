using Microsoft.EntityFrameworkCore;
using ShortLinkService.Dto.Interfaces;
using ShortLinkService.Web.Entities;
using ShortLinkService.Web.Infrastructure;
using System;
using System.Threading.Tasks;

namespace ShortLinkService.Web.Services
{
    public class ShortLinkService : IShortLinkService
    {
        public const int TokenLength = 8;
        private readonly IBitmapCodeGenerator _bitmapCodeGenerator;
        private readonly IFactory<ShortLinkServiceDbContext> _factory;


        public ShortLinkService(
            IBitmapCodeGenerator bitmapGenerator, 
            IFactory<ShortLinkServiceDbContext> factory)
        {
            _bitmapCodeGenerator = bitmapGenerator;
            _factory = factory;
        }

        public async Task AddCutLinkAsync(string original, string token, string bitmap)
        {
            using var context = _factory.Create();
            context.LinkAliases.Add(new LinkAlias(original, token, bitmap));
            await context.SaveChangesAsync();
        }

        public async Task<string> GetOriginalLinkByTokenAsync(string token)
        {
            using var context = _factory.Create();
            var entity = await context.LinkAliases.FirstAsync(x => x.Token == token);
            return entity.FullLink;
        }

        public async Task<bool> IsTokenExistAsync(string token)
        {
            if (token.Length > TokenLength) 
                return false;
            if (string.IsNullOrWhiteSpace(token))
                return false;

            using var context = _factory.Create();
            var row = await context.LinkAliases.FirstOrDefaultAsync(x => x.Token == token);
            return row == null ? false : true;
        }

        public bool ValidateLink(string link)
        {
            try 
            {
                Uri uri = new Uri(link);
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
