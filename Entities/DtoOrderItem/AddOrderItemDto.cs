using Entities.DtoPtoduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DtoOrderItem
{
    public class AddOrderItemDto
    {

        public int? Quantity { get; set; }

        public int ProductId { get; set; }


    }
}
