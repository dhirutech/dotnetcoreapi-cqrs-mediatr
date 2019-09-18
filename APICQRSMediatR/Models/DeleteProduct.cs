using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICQRSMediatR.Models
{
    public class DeleteProduct : IRequest<bool>
    {
        public string Code { get; set; }
    }
}
