using APICQRSMediatR.Models;
using APICQRSMediatR.Repositories.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace APICQRSMediatR.Queries
{
    public class ProductQueryHandler : IRequestHandler<FindAllQuery, IEnumerable<Product>>, IRequestHandler<FindByCodeQuery, Product>
    {
        private readonly IProductRepository _productRepo;
        public ProductQueryHandler(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<Product>> Handle(FindAllQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepo.GetAll();
            return new List<Product>();
        }

        public async Task<Product> Handle(FindByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepo.FindByCode(request.Code);
            return new Product();
        }
    }
}
