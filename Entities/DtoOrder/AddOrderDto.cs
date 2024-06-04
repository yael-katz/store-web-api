using Entities.DtoOrderItem;
using Entities.DtoUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DtoOrder
{
    public class AddOrderDto
    {
        public int? OrderSum { get; set; }
        public virtual ICollection<AddOrderItemDto> OrderItems { get; set; } = new List<AddOrderItemDto>();
        public int? UserId { get; set; }
    }
}
