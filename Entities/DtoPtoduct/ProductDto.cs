using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DtoPtoduct
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string Img { get; set; }
    }
}
