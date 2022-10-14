using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase //asp.net core mvc üzerinden kalıtladık.
    {
        //ProductsController üstünde ctrl . yaptıktan sonra onun constructorını oluşturduk.
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo) 
        {
            _repo = repo;

        }

        [HttpGet] //direk link verince bunu gösterir.
        public async Task<ActionResult<List<Product>>> GetProducts()
        //list<T> Listeleri aramak, sıralamak ve işlemek için yöntemler sağlar. 
        //public string GetProducts() //string döndürmek yerine actionResult kullanabiliriz. 
        {
            var products = await _repo.GetProductsAsync(); 
            return Ok(products); //Lokal değişiklikle beraber Product entitysine bağlı satırlar Postmande görülür.                     
        }

        [HttpGet("{id}")] //linke id parametresini verince sadece o ürünü gösterir. 
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _repo.GetProductByIdAsync(id);
        }
    }
}