using Application.Models;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data.Repositories
{
    public interface IProductRepository 
    {
        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Product GetProductById(string Id);
        IEnumerable<ProductModel> GetAllProducts(); // Thêm phương thức này
    }
}
