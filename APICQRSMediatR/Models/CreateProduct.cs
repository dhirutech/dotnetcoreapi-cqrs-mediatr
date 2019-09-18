using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICQRSMediatR.Models
{
    public class CreateProduct : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
    }
}
