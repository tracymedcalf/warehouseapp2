using WarehouseService.Models;

namespace TestProject;
[TestClass]
public class ContainerTest
{
	// A test that checks if there are skus with a PutawayType
	// that is not null
	[TestMethod]
	public void Sku_NonNullPutawayTypeExists()
	{
		UIStateContainer container = new UIStateContainer();
		Assert.IsTrue(container.Skus.Find(sku => sku.PutawayType != null) != null);
	}
}
