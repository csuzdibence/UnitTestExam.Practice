namespace Practice
{
    internal class UserManager
    {
        private IDbContext dbContext;

        public UserManager(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void RegisterUser(User user)
        {
            if (user.Name.Length >= 3)
            {
                bool result = dbContext.Insert(user);
                if (result)
                {
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
