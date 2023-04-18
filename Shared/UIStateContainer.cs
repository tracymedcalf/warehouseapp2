using WarehouseApp2.Models;

public class UIStateContainer
{
    public List<PickLocation> MyPickLocations = new List<PickLocation>();
    public event Action OnStateChange = null!;

    public UIStateContainer() {
        Console.WriteLine("UIStateContainer being instantiated...");

        var builder = new LocationBuilder();

        MyPickLocations.AddRange(builder.NewList(500));
        
        builder.Zone = Attributes.CF1;
        builder.PutawayType = Attributes.CartonFlow;

        MyPickLocations.AddRange(builder.NewList(500));
    }

    public void SetValue(PickLocation p)
    {
        var i = MyPickLocations.FindIndex(l => l.Id == p.Id);
        MyPickLocations[i] = p; 
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnStateChange?.Invoke();
}
