namespace WarehouseApp2.Models;

public class Assignment
{
    public long Id { get; set; }
    public uint OverrideMin { get; set; }
    public uint OverrideMax { get; set; }

    public long SkuId { get; set; }
    public Sku Sku { get; set; } = null!;

    public PickLocation PickLocation { get; set; } = null!;

    private uint SrOblong(PickLocation location, Sku sku) {
        return 1000;
    }

    public uint Max(PickLocation location, Sku sku) {
        if (OverrideMax is uint max) {
            return max;
        }

        // If the location is Pallet Flow, then assign
        // max according to TI/HI
        // If the sku is in carton flow, the MaxType will be used
        // If the sku is in a bin, the MaxType will be used
        uint maxPallets = 2;
        switch (location.PutawayType) {
            case "Pallet Flow":
                if (sku.Ti is uint ti && sku.Hi is uint hi) {
                    return maxPallets * ti * hi;
                } else {
                    return 0;
                }
                // SR = Select Rack
            case "SR Oblong":
                return SrOblong(location, sku);
        }

        return sku.MaxType switch {
            "Box" => 1,
                "Liquid" => 2,
                "Volume" => 3,
                "Special" => 0,
                _ => 0,
        };
    }

    public uint Min(Location location, Sku sku) {
        if (OverrideMin is uint min) {
            return min;
        }
        return 1;
    }
}
