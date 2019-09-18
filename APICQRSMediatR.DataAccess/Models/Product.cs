using System;
using System.Collections.Generic;
using System.Text;

namespace APICQRSMediatR.Repositories.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
    }
}
