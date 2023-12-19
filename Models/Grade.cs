using System;
using System.Collections.Generic;

namespace HighSchoolDB.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public byte Grade1 { get; set; }

    public DateTime DateOfIssue { get; set; }

    public int FkStudentId { get; set; }

    public int FkPersonnelId { get; set; }

    public int FkSubjectId { get; set; }

    public virtual Personnel FkPersonnel { get; set; } = null!;

    public virtual Student FkStudent { get; set; } = null!;

    public virtual Subject FkSubject { get; set; } = null!;
}
