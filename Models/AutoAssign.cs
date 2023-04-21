namespace WarehouseApp2.Models;

public static class AutoAssign
{
    public static PickLocation Assign(Sku sku, IEnumerable<PickLocation> locations) {
        var empty =
            from l in locations
            where l.Assignment is null
            select l;

        if (empty.FirstOrDefault() is PickLocation e) {
            var a = new Assignment {
                Sku = sku,
                PickLocation = e
            };
            e.Assignment = a;

            sku.Assignments.Add(a);

            return e;
        }

        return null;
    }
    
}
