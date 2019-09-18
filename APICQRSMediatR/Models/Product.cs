using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICQRSMediatR.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
    }
}
