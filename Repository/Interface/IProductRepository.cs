namespace Group_4_Intake_44.Repository.Interface
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product GetByID(int id);

        List<Product> GetByCategoryID(int CategoryId);

        void Insert(Product obj);

        void Update(Product obj);

        void Delete(int id);

        void Save();
    }
}
