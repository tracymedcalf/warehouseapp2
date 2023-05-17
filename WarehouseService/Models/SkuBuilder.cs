namespace WarehouseService.Models;

using MaxTypes = WarehouseService.Models.MaxType;

public class SkuBuilder
{
    private int Count = 0;

    public List<Sku> Skus = new();
    public bool Liquid { get; set; } = false;
    public string CutCode { get; set; } = Attributes.None;
    public string MaxType { get; set; } = MaxTypes.Volume;
    public string PutawayType { get; set; } = PutawayTypes.Bin;
    public uint Hi { get; set; } = 4;
    public uint Ti { get; set; } = 4;

    public SkuBuilder Create(
            string description,
            double width,
            double length,
            double height,
            double weight
            )
    {
        Count++;

        Skus.Add(new Sku
                {
                CutCode = CutCode,
                Description = description,
                Height = height,
                Hi = Hi,
                Id = Count,
                Length = length,
                MaxType = MaxType,
                Name = $"1007{Count.ToString().PadLeft(6,'0')}",
                PutawayType = PutawayType,
                Ti = Ti,
                Weight = weight,
                Width = width,
                });

        return this;
    }

}
