using Microsoft.EntityFrameworkCore;
using Portfo.Repo.SqlDatabase.DTO;

namespace Portfo.Repo.SqlDatabase.Contracts
{
    public interface IActivityRepository
    {
        IQueryable<Activity> Get(Guid postID);
        Task<Activity> InsertAsync(Activity project);
    }
}
