using PAW.Models;

namespace PAW.Business
{
    public interface ISuppliersManager
    {
        IEnumerable<Supplier> CreateSupplier();
    }

    public class SupplierManager : ISuppliersManager
    {
        public IEnumerable<Supplier> CreateSupplier()
        {
            var suppliers = new List<Supplier>();
            for (var i = 0; i < 1000; i++)
                suppliers.Add(new Supplier
                {
                    SupplierId = i,
                    SupplierName = i % 2 == 0 ? "Exotic Liquids" : "New Orleans Cajun Delights",
                    ContactName = i % 2 == 0 ? "Charlotte Cooper" : "Shelley Burke",
                    ContactTitle = i % 2 == 0 ? "Purchasing Manager" : "Order Administrator",
                    Phone = i % 2 == 0 ? 22220020.ToString() : 25600931.ToString(),
                    Address = i % 2 == 0 ? "49 Gilbert St." : "P.O. Box 78934",
                    City = i % 2 == 0 ? "London" : "New Orleans",
                    Country = i % 2 == 0 ? "UK" : "USA"
                });

            return suppliers;
        }
    }
}
