namespace Group_4_Intake_44.Repository.Repository
{
    public class StoreRepository : IStoreRepositry
    {
        gis44_SupplyChainContext Context;

        // Inject Context
        public StoreRepository(gis44_SupplyChainContext _context)
        {
            Context = _context;
        }
        public List<Store> GetAll()
        {
            return Context.Stores.ToList();
        }
        public Store GetByID(int id)
        {
            return Context.Stores.FirstOrDefault(P => P.ID == id);
        }
        public void Insert(Store obj)
        {
            Context.Add(obj);
        }
        public void Update(Store obj)
        {
            Context.Update(obj);
        }
        public void Delete(int id)
        {
            Store crs = GetByID(id);
            Context.Remove(crs);
        }
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}
