using Portfo.Repo.SqlDatabase.DTO;

namespace Portfo.Repo.SqlDatabase.Contracts
{
    public interface ILikeRepository
    {
        Like Get(string id);
        Task<Like> CreateAsync(Like like);

        Task<int> DeleteAsync(string likeId);
        Task<Like> UpdateAsync(Like like);
    }
}
