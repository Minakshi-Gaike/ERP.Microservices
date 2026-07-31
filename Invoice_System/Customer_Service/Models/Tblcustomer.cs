using System;
using System.Collections.Generic;

namespace Customer_Service.Models;

public partial class Tblcustomer
{
    public int CustomerId { get; set; }

    public string? CustomerName { get; set; }

    public string? MobileNo { get; set; }

    public string? City { get; set; }
}
