using APICQRSMediatR.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICQRSMediatR.Queries
{
    public class FindByCodeQuery : IRequest<Product>
    {
        public string Code { get; set; }
    }
}
