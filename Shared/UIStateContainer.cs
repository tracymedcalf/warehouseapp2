using WarehouseApp2.Models;

public class UIStateContainer
{
    public List<PickLocation> MyPickLocations = new List<PickLocation>();
    public event Action OnStateChange = null!;

    public UIStateContainer() {
        Console.WriteLine("UIStateContainer being instantiated...");

        var builder = new LocationBuilder();
        
        builder.CreateRange(1, 1, 1, 10, 4, 20);

        builder.Zone = Attributes.CF1;
        builder.PutawayType = Attributes.CartonFlow;

        builder.CreateRange(1, 1, 1, 10, 4, 20);

        MyPickLocations = builder.MyPickLocations;
    }

    public void SetValue(PickLocation p)
    {
        var i = MyPickLocations.FindIndex(l => l.Id == p.Id);
        MyPickLocations[i] = p; 
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnStateChange?.Invoke();
}
