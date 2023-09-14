using Microsoft.VisualBasic;

namespace ProductApi
{
    public class dtos
    {
        public record productdto(Guid id, string product_neve, int ar, DateTimeOffset keszitett_ido, DateTimeOffset modositas_ido);
    }
}
