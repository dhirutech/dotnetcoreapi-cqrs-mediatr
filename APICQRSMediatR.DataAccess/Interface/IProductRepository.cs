using APICQRSMediatR.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APICQRSMediatR.Repositories.Interface
{
    public interface IProductRepository
    {
        Task<bool> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string productCode);
        Task<List<Product>> GetAll();
        Task<Product> FindByCode(string productCode);
    }
}
