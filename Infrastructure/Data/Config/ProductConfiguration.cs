using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100); //Zorunlu alan + max 100 karakter uzunluğunda girilebilir. 
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany() //Brand birden fazla ürünle ilişkilendirilebilir. Bu yüzden böyle yazdık.
                .HasForeignKey(p => p.ProductBrandId);  //Brand'in ayracı ise BrandId olduğu için burada da onu tanımladık. 
            builder.HasOne(t => t.ProductType).WithMany()  //Ürün Türü birçok ürünle ilişkilendirilebilir. 
                .HasForeignKey(p => p.ProductTypeId);    //Ayracı ise ProductTypeId'dir. 
        }
    }
}