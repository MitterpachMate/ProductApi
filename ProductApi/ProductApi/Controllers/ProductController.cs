﻿using Microsoft.AspNetCore.Http;
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

        //
        [HttpGet("{id}")]
        public productdto GetById(Guid id)
        {
            var product = products.Where(x => x.Id == id).FirstOrDefault();

            return product;
        }



    }
}
