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
    public class FindByCodeHandler : IRequestHandler<FindByCodeQuery, Product>
    {
        private readonly IProductRepository _productRepo;
        public FindByCodeHandler(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<Product> Handle(FindByCodeQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepo.FindByCode(request.Code);
            return new Product();
        }
    }
}
