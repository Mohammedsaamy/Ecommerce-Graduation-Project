//namespace Group_4_Intake_44.Data_Seed
//{
//    public class DataContextSeed
//    {
//        public async static Task SeedAsync(gis44_SupplyChainContext _SupplyChainContext)
//        {
//            //1- Add Product Table
//            if (!_SupplyChainContext.Products.Any())
//            {
//                var productData = System.IO.File.ReadAllText("../DataSeed/Products.json");
//                var products = JsonSerializer.Deserialize<List<Product>>(productData);
//                _SupplyChainContext.Products.AddRange(products);
//            }

//            //2- Add Category Table
//            if (!_SupplyChainContext.Categories.Any())
//            {
//                var CategoryData = System.IO.File.ReadAllText("../DataSeed/categories.json");
//                var categories = JsonSerializer.Deserialize<List<Category>>(CategoryData);
//                _SupplyChainContext.Categories.AddRange(categories);
//            }

//            //3- Add Brand Table
//            if (!_SupplyChainContext.Brand.Any())
//            {
//                var BrandData = System.IO.File.ReadAllText("../DataSeed/brands.json");
//                var brands = JsonSerializer.Deserialize<List<Brand>>(BrandData);
//                _SupplyChainContext.Brand.AddRange(brands);
//            }

//            // Change Tracker When Any Change In Date We Save The Change
//            if (_SupplyChainContext.ChangeTracker.HasChanges())
//            {
//                await _SupplyChainContext.SaveChangesAsync();
//            }
//        }
//    }
//}
