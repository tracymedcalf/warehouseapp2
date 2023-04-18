namespace WarehouseApp2.Models; 

public class LocationBuilder
{
    private uint Counter = 0;
    public string Zone { get; set; } = Attributes.BN1;
    public string PutawayType { get; set; } = Attributes.Bin;

    private PickLocation New() {

        var sCount = Counter.ToString();

        var x = 20;

        var bay = (Counter / (x * 4) + 1).ToString().PadLeft(3, '0');
        
        var position = (Counter / x * 100 + Counter % x + 1).ToString().PadLeft(3, '0');

        var r = new PickLocation {
            Name = $"{Zone}-A01-{bay}-{position}",
                 PutawayType = PutawayType,
                 Barcode = sCount.PadLeft(6, '0'),
                 Width = 12,
                 Length = 24,
                 Height = 14,
                 MaxWeight = 500,
                 Ranking = 50,
                 Zone = Attributes.BN1,
        };

        Counter++;

        return r;

    }

    public List<PickLocation> NewList(int limit) 
    {
        Counter = 0;

        List<PickLocation> acc = new();

        foreach (var _ in Enumerable.Range(0, limit)) {
            acc.Add(New());
        }

        return acc;
    }
}
