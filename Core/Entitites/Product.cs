using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entitites
{
    public class Product : BaseEntity //BaseEntity ile kalıtladığımız için ID entitysine gerek kalmıyor. 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; } //DbSet olarak eklememiz lazım. Store Context
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; } //DbSet olarak eklememiz lazım. StoreContext
        public int ProductBrandId { get; set; }
    }
}