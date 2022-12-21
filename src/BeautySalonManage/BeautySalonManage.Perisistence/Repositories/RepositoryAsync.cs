using Ardalis.Specification.EntityFrameworkCore;
using BeautySalonManage.Application.Interfaces;
using BeautySalonManage.Perisistence.Contexts;

namespace BeautySalonManage.Perisistence.Repositories
{
    public class RepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
