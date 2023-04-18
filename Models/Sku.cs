namespace WarehouseApp2.Models;

public class Sku
{
    public string Name { get; set; } = null!;
    public string CutCode { get; set; } = Attributes.None;
    public string Description { get; set; } = null!;
    public string MaxType { get; set; } = null!;
    public uint Min { get; set; }
    public uint Max { get; set; }
    public string PutawayType { get; set; } = null!;
    public uint Ti { get; set; }
    public uint Hi { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public string Notes { get; set; } = null!;
}
