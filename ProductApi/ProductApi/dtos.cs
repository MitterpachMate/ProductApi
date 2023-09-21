using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ProductApi
{
    public class dtos
    {
        public record productdto(Guid Id, string product_neve, int ar, DateTimeOffset keszitett_ido, DateTimeOffset modositas_ido);

        public record createproductdto([Required] string product_neve, [Range(0, 10000)] int ar);

        public record updateproductdto([Required] string product_neve, [Range(0, 10000)] int ar);
    }
}
