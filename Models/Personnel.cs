using System;
using System.Collections.Generic;

namespace HighSchoolDB.Models;

public partial class Personnel
{
    public int PersonnelId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int FkRoleId { get; set; }

    public virtual Role FkRole { get; set; } = null!;

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public Personnel(string firstName, string lastName, int fkRoleId)
    {
        FirstName = firstName;
        LastName = lastName;
        FkRoleId = fkRoleId;
    }
}
