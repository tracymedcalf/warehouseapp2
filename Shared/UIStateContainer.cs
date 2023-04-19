using WarehouseApp2.Models;

public class UIStateContainer
{
    public List<PickLocation> MyPickLocations;
    public List<Sku> Skus;

    public event Action OnStateChange = null!;

    private void BuildLocations() {
        
        var builder = new LocationBuilder();
        
        builder.CreateRange(1, 1, 1, 10, 4, 20);

        builder.Zone = Attributes.CF1;
        builder.PutawayType = Attributes.CartonFlow;

        builder.CreateRange(1, 1, 1, 10, 4, 20);

        MyPickLocations = builder.MyPickLocations;
    }

    private void BuildSkus() {

        var builder = new SkuBuilder();

        builder
            .Create(
                    "Amerock | Cabinet Pull | Matte Black | 3 inch (76 mm) Center to Center | Everyday Heritage",
                    0.28,
                    0.3,
                    0.3,
                    0.8);

        builder.MaxType = MaxType.Box;
        builder
            .Create(
                    "42 Gal. Heavy Duty Clean-Up Bags (32-Count)",
                    0.4,
                    0.5,
                    0.5,
                    6.1)
            .Create(
                    "SCHLAGE FE595 CAM 626 ACC Camelot Keypad Entry with Flex-Lock and Accent Levers, Brushed Chrome",
                    0.25,
                    0.25,
                    0.56,
                    4.2);

        builder.MaxType = MaxType.Liquid;
        builder.Liquid = true;

        builder
            .Create(
                "EcoLogic Flying Insect Killer Aerosol Spray, 14-oz bottle",
                0.19,
                0.19,
                0.75,
                1)
            .Create(
                "Febreze Odor-Fighting Air Freshener, with Gain Scent, Original Scent, Pack of 2, 8.8 fl oz each ",
                0.45,
                0.19,
                0.75,
                1)
            .Create(
                    "Febreze Odor-Fighting Fabric Refresher, Mediterranean Lavender, 27 fl oz",
                    0.4,
                    0.25,
                    0.81,
                    1.71
                   );

        Skus = builder.Skus;
       
    }

    public UIStateContainer() {
        Console.WriteLine("UIStateContainer being instantiated...");

        BuildLocations();
        BuildSkus();
    }

    public void SetValue(PickLocation p)
    {
        var i = MyPickLocations.FindIndex(l => l.Id == p.Id);
        MyPickLocations[i] = p; 
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnStateChange?.Invoke();
}
