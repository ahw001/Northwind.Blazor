using System.Text.Json.Serialization;

namespace Northwind.Blazor.Model.DBQueries;

public class DBProduct
{
    [JsonPropertyName("productId")]
    public int ProductId { get; set; }

    [JsonPropertyName("productName")]
    public string ProductName { get; set; } = null!;

    [JsonPropertyName("supplierId")]
    public int? SupplierId { get; set; }

    [JsonPropertyName("categoryId")]
    public int CategoryId { get; set; }

    [JsonPropertyName("quantityPerUnit")]
    public string? QuantityPerUnit { get; set; }

    [JsonPropertyName("unitPrice")]
    public decimal? UnitPrice { get; set; }

    [JsonPropertyName("unitsInStock")]
    public short? UnitsInStock { get; set; }

    [JsonPropertyName("unitsOnOrder")]
    public short? UnitsOnOrder { get; set; }

    [JsonPropertyName("reorderLevel")]
    public short? ReorderLevel { get; set; }

    [JsonPropertyName("discontinued")]
    public bool Discontinued { get; set; }

    [JsonPropertyName("productSku")]
    public string? ProductSku { get; set; }

}

