using System;
using System.Collections.Generic;

namespace DemoASPNETCoreMVC.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int UnitsInStock { get; set; }
}
