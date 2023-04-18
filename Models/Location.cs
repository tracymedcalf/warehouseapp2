namespace WarehouseApp2.Models;

public class Location
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Barcode { get; set; } = null!;
    public bool Damaged { get; set; } = false;
    public uint Width { get; set; }
    public uint Length { get; set; }
    public uint Height { get; set; }
    public uint MaxWeight { get; set; }
    public long Ranking { get; set; }
    public string Zone { get; set; } = null!;
}
