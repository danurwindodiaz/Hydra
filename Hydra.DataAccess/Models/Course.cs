using System;
using System.Collections.Generic;

namespace Hydra.DataAccess.Models;

public partial class Course
{
    public string Id { get; set; } = null!;

    public int TrainerId { get; set; }

    public string SkillId { get; set; } = null!;

    public int BootcampClassId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? AppraisalDate { get; set; }

    public virtual BootcampClass BootcampClass { get; set; } = null!;

    public virtual ICollection<CandidateEvaluation> CandidateEvaluations { get; } = new List<CandidateEvaluation>();

    public virtual TrainerSkillDetail TrainerSkillDetail { get; set; } = null!;
}
