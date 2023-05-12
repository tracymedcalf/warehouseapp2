namespace WarehouseService.Models;

public class Sku
{
    public List<Assignment> Assignments = new();
    public List<Barcode> Barcodes { get; set; } = new();
    public List<Note> Notes { get; set; } = new();
    public double Height { get; set; }
    public double Hits { get; set; } = 0;
    public double Length { get; set; }
    public double UnitsPerDay { get; set; } = 0;
    public double Weight { get; set; }
    public double Width { get; set; }
    public long Id { get; set; }
    public string CutCode { get; set; } = CutCodes.None;
    public string Description { get; set; } = null!;
    public string MaxType { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string PutawayType { get; set; } = null!;
    public uint Hi { get; set; }
    public uint Max { get; set; }
    public uint Min { get; set; }
    public uint Ti { get; set; }
}
