using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public partial class User
{
    public int UserId { get; set; } = 0;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Password { get; set; }
    [EmailAddress]
    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
