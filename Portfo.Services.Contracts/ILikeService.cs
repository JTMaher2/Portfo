using Portfo.Services.Model;
using System.Threading.Tasks;

namespace Portfo.Services.Contracts
{
    public interface ILikeService
    {
        Task<Like> CreateAsync(Like user);

        Task<bool> DeleteAsync(string id);
    }
}
