namespace WarehouseApp2.Models;

public static class Attributes {

    public static string None = "None";
    public static string Sku = "Sku";
    public static string PickLocation = "Pick Location";

    public static string BN1 = "BN1";
    public static string CF1 = "CF1";

    public static string Bin = "Bin";
    public static string CartonFlow = "Carton Flow";
    public static string Special = "Special";

    public static List<string> CutCodes = new List<string> {
        "Do Not Cut",
            None,
            "Place in Bin",
            "Remove From Pack",
            "Remove Top",
    };

    public static List<string> MaxTypes = new List<string> {
        MaxType.Box,
            MaxType.Liquid,
            MaxType.Special,
            MaxType.Volume,
    };

    public static List<string> PutawayTypes = new List<string> {
        Bin,
            "Bin Oblong",
            "Bin Shelf",
            CartonFlow,
            "Carton Flow Endstop",
            "Carton Flow Liquid",
            "Carton Flow Heavy",
            "Pallet Flow",
            Special,
            "SR Oblong",
            "SR Pallet",
    };

    public static List<string> Zones = new List<string> {
        BN1,
            CF1,
            "PF1",
            "SR1",
    };
}
