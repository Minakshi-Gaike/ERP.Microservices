using System;
using System.Collections.Generic;

namespace WebApiProduct.Models;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public double? Rate { get; set; }

    public int? Gst { get; set; }

    public int? StockQuantity { get; set; }
}
