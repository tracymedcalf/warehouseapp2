namespace WarehouseService.Models;

public static class Attributes {

    public static string None = "None";
    public static string Sku = "Sku";
    public static string PickLocation = "Pick Location";

    public static string BN1 = "BN1";
    public static string CF1 = "CF1";

    public static string Bin = "Bin";
    public static string CartonFlow = "Carton Flow";
    public static string Special = "Special";

    public static List<string> Zones = new List<string> {
        "BK1",
        "BK2",
        "BK3",
            BN1,
            CF1,
            "PF1",
            "SR1",
            "SR2",
            "SR3",
    };
}
