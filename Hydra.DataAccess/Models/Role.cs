using System;
using System.Collections.Generic;

namespace Hydra.DataAccess.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Usernames { get; } = new List<User>();
}
