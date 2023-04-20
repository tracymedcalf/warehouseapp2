using System.Reflection;

public static class PutawayTypes
{
    public static string Bin = "Bin";
    public static string BinEndcap = "Bin Endcap";
    public static string BinOblong = "Bin Oblong";
    public static string BinShelf = "Bin Shelf";
    public static string Bulk = "Bulk";
    public static string CartonFlow = "Carton Flow";
    public static string DoorsAndPanells = "Doors and Panels";
    public static string SelectRackEpjPick = "Select Rack EPJ Pick";
    public static string SelectRackPalletPick = "Select Rack Pallet Pick";
    public static string SelectRackOblong = "Select Rack Oblong";
    public static string Special = "Special";

    public static List<string> PutawayTypesList = new();

    static PutawayTypes() {
        Type t = typeof(PutawayTypes);
        FieldInfo[] fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);

        foreach (FieldInfo fi in fields)
        {
            if (fi.GetValue(null) is string s) {
                PutawayTypesList.Add(s);
            }
        }
    }
}
