using Portfo.Services.Model;
using System;
using System.Threading.Tasks;

namespace Portfo.Services.Contracts
{
    public interface IAddressService
    {
        Task<Address> CreateAsync(Address user);

        Task<bool> UpdateAsync(Address user);

        Task<bool> DeleteAsync(string id);

        Address GetAsync(Guid id);
    }
}
