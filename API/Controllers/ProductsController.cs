using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
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
        private readonly StoreContext _context;
        public ProductsController(StoreContext context) //StoreContext'i burada kullanmak için using data.api kullandık. context'e tıklayıp field parameter yaptık. 
        {
            _context = context;
        }

        [HttpGet] //direk link verince bunu gösterir.
        public async Task<ActionResult<List<Product>>> GetProducts()
        //list<T> Listeleri aramak, sıralamak ve işlemek için yöntemler sağlar. 
        //public string GetProducts() //string döndürmek yerine actionResult kullanabiliriz. 
        {
            var products = await _context.Products.ToListAsync();   
            return Ok(products); //Lokal değişiklikle beraber Product entitysine bağlı satırlar Postmande görülür. 
            
            //Alttaki yazım kullanılabilir fakat senkron bir yapıdadır. Bu da karmaşık sorguların olduğu yerde return'un çok uzun zaman almasına neden olabilir. 
            //Bu yüzden aynı yapının asenkron formatını kullanmak daha akıllıca olacaktır. Request'i bir delegate ile aktarırız.
            //Asenkron metodları kullanmak daha ölçeklenebilir bir uygulamaya olanak sağlar. 
            //var products = _context.Products.ToList(); 
            
        }

        [HttpGet("{id}")] //linke id parametresini verince sadece o ürünü gösterir. 
        public async Task<ActionResult<List<Product>>> GetProduct(int id)
        {
            var products = await _context.Products.FindAsync(id);
            return Ok(products); //lokal değişken yerine doğrudan return üstüne yazmaya çalışanca hata aldığı için üsttekinin aynısını yazdım. 
        }
    }
}