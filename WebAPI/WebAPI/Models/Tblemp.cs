using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Tblemp
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmailId { get; set; }

    public string? MobileNo { get; set; }

    public int? Salary { get; set; }
}
