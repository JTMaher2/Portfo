using Portfo.Repo.SqlDatabase.DTO;

namespace Portfo.Repo.SqlDatabase.Contracts
{
    public interface IUserRepository
    {
        User GetAsync(string id);

        Task<User> CreateAsync(User project);

        Task<User> UpdateAsync(User project);

        Task<User> UpsertAsync(User project);

        Task<int> DeleteAsync(string projectId);
    }
}
