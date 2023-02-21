using System;
using System.Collections.Generic;

namespace Hydra.DataAccess.Models;

public partial class User
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Trainer> Trainers { get; } = new List<Trainer>();

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}
