namespace WarehouseApp2.Models;

public static class Assign
{

    private static List<Assignment> AssignSkus(List<Sku> skus, List<PickLocation> locations) 
    {

        // Find empty locations
        // Find locations that match the PutawayType for each sku
        // Assign those skus to those locations
        // Return the assignments

        var empties =
            from l in locations
            where l.Assignment == null
            select l;
        
        var locationGroups = empties
            .GroupBy(e => e.PutawayType);

        var skuGroups = 
            from s in skus
            group s by s.PutawayType;

        var joins =
            from sg in skuGroups
            join lg in locationGroups on
            sg.Key equals lg.Key
            select new
            {
                SkuGroup = sg,
                LocationGroup = lg
            };
      
        List<Assignment> ret = new List<Assignment>();

        foreach (var j in joins) 
        {
            //j.LocationGroup.Zip(
            //        j.SkuGroup,
            //        (l, s) => {
            //            var a = new Assignment {
            //                PickLocation = l,
            //                Sku = s
            //            };
            //            l.Assignment = a;
            //            s.Assignments.Add(a);
            //            ret.Add(a);
            //        });

        }

        return ret;
    }
}
