using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitites;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        //Görevler async olacak, bu sayede istediğimiz zaman çalışabilecek. 
        Task<Product> GetProductByIdAsync(int id); //Bu şekilde isimlendirdiğimizde bir task yapacağını anlarız. Böylelikle Controllerde bunu çağırdığımızda metodu bekleyebiliriz.  
        Task<IReadOnlyList<Product>> GetProductsAsync();
    
    }
}