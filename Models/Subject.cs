using System;
using System.Collections.Generic;

namespace HighSchoolDB.Models;

public partial class Subject
{
    public int SubjectId { get; set; }

    public string SubjectName { get; set; } = null!;

    public string? Description { get; set; }

    public int? FkPersonnelId { get; set; }

    public virtual Personnel? FkPersonnel { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
