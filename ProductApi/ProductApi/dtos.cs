using Microsoft.VisualBasic;

namespace ProductApi
{
    public class dtos
    {
        public record productdto(Guid Id, string product_neve, int ar, DateTimeOffset keszitett_ido, DateTimeOffset modositas_ido);

        public record createproductdto(string product_neve, int ar);

        public record updateproductdto(string product_neve, int ar);
    }
}
