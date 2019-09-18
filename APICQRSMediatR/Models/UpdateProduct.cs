using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICQRSMediatR.Models
{
    public class UpdateProduct : IRequest<bool>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
    }
}
