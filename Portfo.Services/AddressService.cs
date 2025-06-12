using Portfo.Services.Contracts;
using S = Portfo.Services.Model;
using System;
using System.Threading.Tasks;
using Portfo.Repo.SqlDatabase.Contracts;
using DTO = Portfo.Repo.SqlDatabase.DTO;

namespace Portfo.Services
{
    public class AddressService(IAddressRepository repo) : IAddressService
    {
        private readonly IAddressRepository _repo = repo;

        public async Task<S.Address> CreateAsync(S.Address address)
        {
            var addressNew = await _repo.CreateAsync(new DTO.Address()
            {
                Country = address.AddressCountry,
                Street = address.AddressStreet,
                ZipCode = address.AddressZipCode,
                CreationDate = DateTime.UtcNow,
                ID = address.AddressID,
                LastUpdateDate = DateTime.UtcNow,
                City = address.AddressCity
            });

            return new S.Address()
            {
                AddressCity = addressNew.City,
                AddressCountry = addressNew.Country,
                AddressZipCode = addressNew.ZipCode,
                AddressID = addressNew.ID,
                AddressStreet = addressNew.Street,
                CreationDate = addressNew.CreationDate,
                LastUpdateDate = addressNew.LastUpdateDate
            };
        }

        public async Task<bool> UpdateAsync(S.Address address)
        {
            var addressNew = await _repo.UpdateAsync(new DTO.Address()
            {
                Country = address.AddressCountry,
                Street = address.AddressStreet,
                ZipCode = address.AddressZipCode,
                ID = address.AddressID,
                LastUpdateDate = address.LastUpdateDate,
                CreationDate = address.CreationDate,
                City = address.AddressCity
            });

            return addressNew != default(DTO.Address) && addressNew.CreationDate == address.CreationDate &&
                addressNew.ID == address.AddressID && addressNew.LastUpdateDate == address.LastUpdateDate &&
                addressNew.City == address.AddressCity && addressNew.Country == address.AddressCountry &&
                addressNew.Street == address.AddressStreet && addressNew.ZipCode == address.AddressZipCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repo.DeleteAsync(id) > 0;
        }

        public S.Address GetAsync(Guid id)
        {
            var addressNew = _repo.GetAsync(id.ToString());
            
            if (addressNew != default(DTO.Address))
            {
                return new S.Address()
                {
                    CreationDate = addressNew.CreationDate,
                    AddressID = addressNew.ID,
                    LastUpdateDate = addressNew.LastUpdateDate,
                    AddressCity = addressNew.City,
                    AddressCountry = addressNew.Country,
                    AddressZipCode = addressNew.ZipCode,
                    AddressStreet = addressNew.Street
                };
            }
            else
            {
                return default;
            }
        }
    }
}
