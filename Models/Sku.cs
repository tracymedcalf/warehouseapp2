namespace WarehouseApp2.Models;

public class Sku
{
    public long Id { get; set; }
    public List<Assignment> Assignments = new();
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string CutCode { get; set; } = CutCodes.None;
    public uint Min { get; set; }
    public uint Max { get; set; }
    public string MaxType { get; set; } = null!;
    public uint Ti { get; set; }
    public uint Hi { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public List<Note> Notes { get; set; } = new();
}
