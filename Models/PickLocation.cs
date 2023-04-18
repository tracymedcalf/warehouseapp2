namespace WarehouseApp2.Models;

public class PickLocation : Location
{
    public uint HeightAboveGround { get; set; } = 0;
    public string PutawayType { get; set; } = null!;

    public Assignment? Assignment { get; set; }

    public List<string> Notes { get; set; } = new List<string>();
}
