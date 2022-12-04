using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShortLinkService.Web.Entities
{
    [Table("LinkAliases")]
    public class LinkAlias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(416)]
        public string FullLink { get; set; }
        [MaxLength(26)]
        public string Token { get; set; }

        public string BitmapCodePath { get; set; }

        public LinkAlias()
        {
        }

        public LinkAlias(string fullLink, string token, string bitmap)
        {
            FullLink = fullLink;
            Token = token;
            BitmapCodePath = bitmap;
        }
    }
}