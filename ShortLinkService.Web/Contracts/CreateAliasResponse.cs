namespace ShortLinkService.Web.Contracts
{
    public class CreateAliasResponse
    {
        public string ShortLink { get; set; }
        public string BitmapCodeAddress { get; set; }

        public CreateAliasResponse()
        { }

        public CreateAliasResponse(string shortLink, string bitmapCodeAddress)
        {
            ShortLink = shortLink;
            BitmapCodeAddress = bitmapCodeAddress;
        }
    }
}
