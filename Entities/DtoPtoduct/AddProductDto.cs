﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DtoPtoduct
{
    public class AddProductDto
    {
        public string? ProductName { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }
        public int ProductId { get; set; }

    }
}
