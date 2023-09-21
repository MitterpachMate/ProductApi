using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ProductApi.dtos;

namespace ProductApi.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<productdto> products = new()
        {
        new productdto(Guid.NewGuid(), "Termék1", 2500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
        new productdto(Guid.NewGuid(), "Termék2", 500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
        new productdto(Guid.NewGuid(), "Termék3", 3500, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
        new productdto(Guid.NewGuid(), "Termék4", 10000, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow),
        };

        //http vegpont

        //lekeres
        [HttpGet()]
        public IEnumerable<productdto> GetAll() { return products; }

        //URL id 
        [HttpGet("{id}")]
        public ActionResult<productdto> GetById(Guid id)
        {
            var product = products.Where(x => x.Id == id).FirstOrDefault(); //id alapu keresés

            if (product == null) { return NotFound(); }

            return Ok(product);
        }

        //termek hozzaadas
        [HttpPost()]
        public ActionResult<productdto> PostProduct(createproductdto createproduct)
        {
            var product = new productdto(Guid.NewGuid(), createproduct.product_neve, createproduct.ar, DateTimeOffset.UtcNow, DateTimeOffset.UtcNow); //adat beker
            products.Add(product); //listaba hozzadas


            //return Created("", product);
            return CreatedAtAction(nameof(GetById),new { id = product.Id }, product);
        }

        //termek modositas
        [HttpPut]
        public ActionResult<productdto> PullProduct(Guid id, updateproductdto updateproductdto)
        {
            var letezo_product = products.Where(x => x.Id == id).FirstOrDefault(); //id alapu keresés

            var product = letezo_product with //meglevo objektum adatainak frissitese
            {
                product_neve = updateproductdto.product_neve,
                ar = updateproductdto.ar,
                modositas_ido = DateTimeOffset.UtcNow
            };

            if (product == null)
            {
                return NotFound();
            }

            var index = products.FindIndex(x => x.Id == id); //hely kikeres, ahjol cserelni akarunk

            products[index] = product; //csere

            return product;
        }

        //termek torles
        [HttpDelete]
        public ActionResult Delete(Guid id)
        {

            var index = products.FindIndex(x => x.Id == id); //hely kikeres, ahjol torolni akarunk

            if (index == 0)
            {
                return NotFound();
            }


            products.RemoveAt(index);

            return NoContent();
        }

    }
}
