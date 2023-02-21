using System;
using System.Collections.Generic;

namespace Hydra.DataAccess.Models;

public partial class TrainerSkillDetail
{
    public int TrainerId { get; set; }

    public string SkillId { get; set; } = null!;

    public DateTime AssignetDate { get; set; }

    public DateTime? AchievedDate { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual Skill Skill { get; set; } = null!;

    public virtual Trainer Trainer { get; set; } = null!;
}
