using System;
using System.Collections.Generic;

namespace Repository.Models;

public partial class Student
{
    public Guid StudentId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Gender { get; set; }

    public string Major { get; set; }

    public decimal? Gpa { get; set; }

    public DateTime DateOfBirth { get; set; }
}
