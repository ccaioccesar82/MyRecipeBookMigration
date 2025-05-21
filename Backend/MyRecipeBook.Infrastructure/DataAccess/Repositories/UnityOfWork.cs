using MyRecipeBook.Domain.Interfaces.RepositoryInterfaces;

namespace MyRecipeBook.Infrastructure.DataAccess.Repositories
{
    public class UnityOfWork: IUnityOfWork
    {
        private readonly MyRecipeBookDbContext _dbContext;

        public UnityOfWork(MyRecipeBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
