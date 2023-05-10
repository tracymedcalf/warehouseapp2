namespace WarehouseService.Models;

public class PickLocation : Location
{
    public uint HeightAboveGround { get; set; } = 0;
    public string PutawayType { get; set; } = null!;

    public Assignment? Assignment { get; set; }

    public List<Note> Notes { get; set; } = new();
}
