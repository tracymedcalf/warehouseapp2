using WarehouseApp2.Models;

namespace TestProject
{
    [TestClass]
    public class ContainerTest
    {
        // A test that checks if there are skus with a PutawayType
        // that is not null
        [TestMethod]
        public void Sku_NonNullPutawayTypeExists()
        {
            UIStateContainer container = new UIStateContainer();
            Assert.IsTrue(contains.Skus.Find(sku => sku.PutawayType != null) != null);
        }
    }
}
