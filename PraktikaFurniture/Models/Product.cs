using System;

namespace PraktikaFurniture.Models;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductCode { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
