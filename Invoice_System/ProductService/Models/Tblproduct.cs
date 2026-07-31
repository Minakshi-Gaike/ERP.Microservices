using System;
using System.Collections.Generic;

namespace ProductService.Models;

public partial class Tblproduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public double? Rate { get; set; }

    public int? Gst { get; set; }

    public int? StockQuantity { get; set; }
}
