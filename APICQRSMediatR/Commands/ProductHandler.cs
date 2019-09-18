using APICQRSMediatR.Models;
using APICQRSMediatR.Repositories.Interface;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using DataModels = APICQRSMediatR.Repositories.Models;

namespace APICQRSMediatR.Commands
{
    public class ProductHandler : IRequestHandler<CreateProduct, bool>, IRequestHandler<UpdateProduct, bool>, IRequestHandler<DeleteProduct, bool>
    {
        private readonly ILogger<ProductHandler> _logger = null;
        private readonly IProductRepository _productRepo;

        public ProductHandler(IProductRepository productRepo, ILogger<ProductHandler> logger)
        {
            _productRepo = productRepo;
            _logger = logger;
        }

        public async Task<bool> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var product = new DataModels.Product()
            {
                Id = request.Id,
                Code = request.Code,
                Name = request.Name,
                Maker = request.Maker,
            };
            return await _productRepo.CreateProduct(product);
        }

        public async Task<bool> Handle(UpdateProduct request, CancellationToken cancellationToken)
        {
            var product = new DataModels.Product()
            {
                Code = request.Code,
                Name = request.Name,
                Maker = request.Maker,
            };
            return await _productRepo.UpdateProduct(product);
        }

        public async Task<bool> Handle(DeleteProduct request, CancellationToken cancellationToken)
        {
            return await _productRepo.DeleteProduct(request.Code);
        }
    }
}
