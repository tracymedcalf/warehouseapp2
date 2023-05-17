namespace WarehouseService.Models;

public class AutoAssign
{
    public List<Assignment> Assignments { get; set; }
    public List<Sku> Unassigned { get; set; }

    // Constructor for this class
    private AutoAssign(List<Assignment> assignments, List<Sku> unassigned)
    {
        Assignments = assignments;
        Unassigned = unassigned;
    }

    public static AutoAssign AssignSkus(List<Sku> skus, List<PickLocation> locations) 
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
      
        List<Assignment> assignments = new List<Assignment>();
        List<Sku> unassigned = new List<Sku>();

        foreach (var j in joins) 
        {

            Queue<Sku> skuQueue = new(j.SkuGroup);

            foreach (PickLocation l in j.LocationGroup)
            {
                if (skuQueue.Count() == 0) {
                    break;
                }

                Sku s = skuQueue.Dequeue();

                var a = new Assignment {
                    PickLocation = l,
                    Sku = s
                };

                l.Assignment = a;
                s.Assignments.Add(a);

                assignments.Add(a);
            }

            unassigned.AddRange(skuQueue);

        }

        return new AutoAssign(assignments, unassigned);
    }
}
