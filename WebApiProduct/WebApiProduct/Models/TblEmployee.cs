using System;
using System.Collections.Generic;

namespace WebApiProduct.Models;

public partial class TblEmployee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeCode { get; set; }

    public string? EmailId { get; set; }

    public string? MobileNo { get; set; }

    public string? Designation { get; set; }

    public double? Salary { get; set; }

    public string? Emppass { get; set; }
}
