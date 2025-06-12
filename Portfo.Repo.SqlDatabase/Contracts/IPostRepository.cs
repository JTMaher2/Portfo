using Portfo.Repo.SqlDatabase.DTO;

namespace Portfo.Repo.SqlDatabase.Contracts
{
    public interface IPostRepository
    {
        Post GetAsync(string id);

        Task<Post> CreateAsync(Post post);

        Task<Post> UpdateAsync(Post post);

        Task<Post> UpsertAsync(Post post);

        Task<int> DeleteAsync(string postId);
    }
}
