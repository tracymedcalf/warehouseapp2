namespace WarehouseService.Models;
public class Note
{
    public string Content { get; set; } = null!;
    // yyyy-mm-dd
    public string Date { get; set; } = DateTime.UtcNow.ToString("MM-dd-yyyy");
    public string User { get; set; } = null!;

}
