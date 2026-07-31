using System;
using System.Collections.Generic;

namespace JWTTokenAPI.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public double? Rate { get; set; }

    public double? Gst { get; set; }

    public int? Stock { get; set; }
}
