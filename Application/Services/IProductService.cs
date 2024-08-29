using Application.Models;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProductService 
    {
        void Create(Product entity);
        void Update(Product entity);
        bool Delete(Product entity);
        IEnumerable<Product> FindAll();
        //IEnumerable<ProductViewModel> GetAllProduct();
        Product? GetProducBytId(string Id);
    }
}
