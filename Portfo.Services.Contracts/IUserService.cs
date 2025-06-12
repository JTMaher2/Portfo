using Portfo.Services.Model;
using System;
using System.Threading.Tasks;

namespace Portfo.Services.Contracts
{
    public interface IUserService
    {
        Task<User> CreateAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(string id);

        User GetAsync(Guid id);
    }
}
