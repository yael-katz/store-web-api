using System;
using System.Collections.Generic;

namespace Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategotyName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
