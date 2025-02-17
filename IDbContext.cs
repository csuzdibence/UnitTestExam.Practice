namespace Practice
{
    public interface IDbContext
    {
        bool Insert(User user);

        void SaveChanges();
    }
}
