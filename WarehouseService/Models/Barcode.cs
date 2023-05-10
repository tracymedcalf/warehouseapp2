namespace WarehouseService.Models;

public class Barcode
{
    public long Id { get; set; }
    public string Code { get; set; } = null!;
    public long PackSize { get; set; }
}
