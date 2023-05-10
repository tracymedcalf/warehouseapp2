namespace WarehouseService.Models;

using MaxTypes = WarehouseService.Models.MaxType;

public class SkuBuilder
{
    private int Count = 0;

    public string CutCode { get; set; } = Attributes.None;
    public bool Liquid { get; set; } = false;
    public string MaxType { get; set; } = MaxTypes.Volume;
    public string PutawayType { get; set; } = PutawayTypes.Bin;
    public uint Ti { get; set; } = 4;
    public uint Hi { get; set; } = 4;

    public List<Sku> Skus = new();

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
                Name = $"1007{Count.ToString().PadLeft(6,'0')}",
                Description = description,
                CutCode = CutCode,
                MaxType = MaxType,
                Width = width,
                Length = length,
                Height = height,
                Weight = weight,
                Ti = Ti,
                Hi = Hi,
                });

        return this;
    }

}
