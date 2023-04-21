namespace WarehouseApp2.Models;

public class Sku
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public List<Assignment> Assignments = new();
    public string CutCode { get; set; } = CutCodes.None;
    public string Description { get; set; } = null!;
    public double Hits { get; set; } = 0;
    public string MaxType { get; set; } = null!;
    public uint Min { get; set; }
    public uint Max { get; set; }
    public uint Ti { get; set; }
    public uint Hi { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public List<Note> Notes { get; set; } = new();
    public List<Barcode> Barcodes { get; set; } = new();
}
