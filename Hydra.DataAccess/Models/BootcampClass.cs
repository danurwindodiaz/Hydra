using System;
using System.Collections.Generic;

namespace Hydra.DataAccess.Models;

public partial class BootcampClass
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Candidate> Candidates { get; } = new List<Candidate>();

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
