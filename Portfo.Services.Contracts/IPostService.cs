using Portfo.Services.Model;
using System;
using System.Threading.Tasks;

namespace Portfo.Services.Contracts
{
    public interface IPostService
    {
        Task<Post> CreateAsync(Post user);

        Task<bool> UpdateAsync(Post user);

        Task<bool> DeleteAsync(string id);

        Task<Post> GetAsync(Guid id);
    }
}
