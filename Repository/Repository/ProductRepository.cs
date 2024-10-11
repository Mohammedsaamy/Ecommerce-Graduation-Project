namespace Group_4_Intake_44.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        gis44_SupplyChainContext Context;

        // Inject Context
        public ProductRepository(gis44_SupplyChainContext _context)
        {
            Context = _context;
        }
        public List<Product> GetAll()
        {
            return Context.Products.ToList();
        }
        public Product GetByID(int id)
        {
            return Context.Products.FirstOrDefault(P => P.ID ==id);
        }
        public List<Product> GetByCategoryID(int CategoryId)
        {
            return Context.Products
                 .Where(p => p.CategoryID == CategoryId)
                 .ToList();
        }
        public void Insert(Product obj)
        {
            Context.Add(obj);
        }
        public void Update(Product obj)
        {
            Context.Update(obj);
        }
        public void Delete(int id)
        {
            Product crs = GetByID(id);
            Context.Remove(crs);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
