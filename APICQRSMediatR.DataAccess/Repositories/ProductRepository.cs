using APICQRSMediatR.Repositories.Interface;
using APICQRSMediatR.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APICQRSMediatR.Repositories.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<bool> CreateProduct(Product product)
        {
            return true;
        }

        public async Task<bool> DeleteProduct(string productCode)
        {
            return true;
        }

        public async Task<Product> FindByCode(string productCode)
        {
            return null;
        }

        public async Task<List<Product>> GetAll()
        {
            return null;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            return true;
        }
    }
}
