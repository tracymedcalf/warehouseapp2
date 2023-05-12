namespace WarehouseService.Models;

public class Assignment
{
    public PickLocation PickLocation { get; set; } = null!;
    public Sku Sku { get; set; } = null!;
    public bool? Confirmed { get; set; } = false;
    public long Id { get; set; }
    public uint? OverrideMax { get; set; }
    public uint? OverrideMin { get; set; }

    private uint SrOblong() {
        return 1000;
    }

    public uint Max() {
        if (OverrideMax is uint max) {
            return max;
        }

        // If the PickLocation is Pallet Flow, then assign
        // max according to TI/HI
        // If the Sku is in carton flow, the MaxType will be used
        // If the Sku is in a bin, the MaxType will be used
        uint maxPallets = 2;
        switch (PickLocation.PutawayType) {
            case "Pallet Flow":
                if (Sku.Ti is uint ti && Sku.Hi is uint hi) {
                    return maxPallets * ti * hi;
                } else {
                    return 0;
                }
                // SR = Select Rack
            case "SR Oblong":
                return SrOblong();
        }

        return Sku.MaxType switch {
            "Box" => 1,
                "Liquid" => 2,
                "Volume" => 3,
                "Special" => 0,
                _ => 0,
        };
    }

    public uint Min() {
        if (OverrideMin is uint min) {
            return min;
        }

        int ceil = (int)Math.Ceiling(Sku.UnitsPerDay);
        uint units = ceil >= 0 ? (uint)ceil : 0;
        return units * 2;
    }
}
