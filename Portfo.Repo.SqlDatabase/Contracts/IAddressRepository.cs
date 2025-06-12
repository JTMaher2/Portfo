using Portfo.Repo.SqlDatabase.DTO;

namespace Portfo.Repo.SqlDatabase.Contracts
{
    public interface IAddressRepository
    {
        Address GetAsync(string id);

        Task<Address> CreateAsync(Address project);

        Task<Address> UpdateAsync(Address project);

        Task<Address> UpsertAsync(Address project);

        Task<int> DeleteAsync(string projectId);
    }
}
