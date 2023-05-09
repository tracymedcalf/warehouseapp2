using WarehouseApp2.Models;

public class UIStateContainer
{
    public event Action OnStateChange = null!;

    public List<PickLocation> PickLocations { get; set; } = new();
    public List<Sku> Skus { get; set; } = new();
    public List<Assignment> Assignments { get; set; } = new();

    public List<Sku> SkusToAssign { get; set; } = new();

    public UIStateContainer() {
        Console.WriteLine("UIStateContainer being instantiated...");
        
        BuildLocations();
        BuildSkus();
    }

    public AutoAssign Assign() {
        return AutoAssign.AssignSkus(Skus, PickLocations);
    }

    public void SetValue(PickLocation p1)
    {
        // Set value in list
        int i = PickLocations.FindIndex(p2 => p2.Id == p1.Id);
        PickLocations[i] = p1;
        NotifyStateChanged();
    }

    private void BuildLocations() {

        var builder = new LocationBuilder();

        builder.CreateRange(1, 1, 1, 10, 4, 20);

        builder.Zone = Attributes.CF1;
        builder.PutawayType = Attributes.CartonFlow;

        builder.CreateRange(1, 1, 1, 10, 4, 20);
        PickLocations = builder.MyPickLocations;
    }

    private void BuildSkus() {

        var builder = new SkuBuilder();

        // Create fake data with width, length, height, and weight

        builder
            .Create(
                    "Amerock | Cabinet Pull | Matte Black | 3 inch (76 mm) Center to Center | Everyday Heritage",
                    0.28,
                    0.3,
                    0.3,
                    0.8)
            .Create(
                    "Amerock | Cabinet Pull | Matte Black | 3-3/4 inch (96 mm) Center to Center | Everyday Heritage",
                    0.28,
                    0.3,
                    0.4,
                    0.9)
            .Create(
                    "Amerock | Cabinet Pull | Matte Black | 4 inch (102 mm) Center to Center | Everyday Heritage",
                    0.28,
                    0.3,
                    0.5,
                    1);

        builder.MaxType = MaxType.Box;
        builder
            .Create(
                    "42 Gal. Heavy Duty Clean-Up Bags (32-Count)",
                    0.4,
                    0.5,
                    0.5,
                    6.1)
            .Create(
                    "SCHLAGE FE595 CAM 716 ACC Camelot Keypad Entry with Flex-Lock and Accent Levers, Aged Bronze",
                    0.25,
                    0.25,
                    0.56,
                    4.2)
            .Create(
                    "SCHLAGE FE595 CAM 626 ACC Camelot Keypad Entry with Flex-Lock and Accent Levers, Brushed Chrome",
                    0.25,
                    0.25,
                    0.56,
                    4.2)
            .Create(
                    "SCHLAGE FE595 CAM 716 ACC Camelot Keypad Entry with Flex-Lock and Accent Levers, Satin Nickel",
                    0.25,
                    0.25,
                    0.56,
                    4.2);

        // Create some tools 
        builder.
            Create(
                    "DEWALT 20-Volt MAX Lithium-Ion Cordless Combo Kit (4-Tool) with Soft Case",
                    0.25,
                    0.25,
                    0.56,
                    4.2)
            .Create(
                    "IRWIN 29-Piece Quick-Grip One-Handed Bar Clamp Set",
                    0.25,
                    0.25,
                    0.56,
                    4.2);

        // Create some books
        builder
            .Create(
                    "The Complete Guide to Home Repair",
                    0.45,
                    0.12,
                    0.66,
                    5.9)
            .Create(
                    "The Homeowner's DIY Guide to Plumbing",
                    0.45,
                    0.12,
                    0.66,
                    5.9);

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
                   )
            .Create(
                    "Febreze Odor-Fighting Fabric Refresher, Gain Original, 27 fl oz",
                    0.4,
                    0.25,
                    0.81,
                    1.71
                   );

        Skus = builder.Skus;

    }

    private void NotifyStateChanged() => OnStateChange?.Invoke();
}
