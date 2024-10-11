namespace Group_4_Intake_44.Repository.Interface
{
    public interface IStoreRepositry
    {
        List<Store> GetAll();

        Store GetByID(int id);

        void Insert(Store obj);

        void Update(Store obj);

        void Delete(int id);

        void Save();
    }
}
