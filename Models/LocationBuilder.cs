namespace WarehouseApp2.Models; 

public class LocationBuilder
{
    private long Counter = 0;
    public string PutawayType { get; set; } = Attributes.Bin;
    public string Zone { get; set; } = Attributes.BN1;

    public List<PickLocation> MyPickLocations { get; set; } = new();

    public void CreateRange(
              int bay1
            , int sublevel1
            , int position1
            , int bay2
            , int sublevel2
            , int position2
            ) 
    {
        foreach (var b in Enumerable.Range(bay1, bay2)) {
            foreach (var s in Enumerable.Range(sublevel1, sublevel2)) {
                foreach (var p in Enumerable.Range(position1, position2)) {

                    var bay = b.ToString().PadLeft(3, '0');
                    var position = p.ToString().PadLeft(2, '0');

                    var notes = new List<Note> {
                        new Note {
                            Content = "Using this location for holiday skus",
                            User = "Meryl",
                        },
                        new Note {
                            Content = "Needs a new bin",
                            User = "John",
                        },
                    };

                    MyPickLocations.Add(new PickLocation {
                            Id = Counter,
                            Barcode = Counter.ToString().PadLeft(6, '0'),
                            MaxWeight = 500,
                            Name = $"{Zone}-A01-{bay}-{s}{position}",
                            Notes = notes,
                            PutawayType = PutawayType,
                            Width = 12,
                            Length = 24,
                            Height = 14,
                            Ranking = 50,
                            Zone = Zone
                            });
                    
                    Counter++;
                }
            }
        }
    }
}
