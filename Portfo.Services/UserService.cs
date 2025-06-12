using Portfo.Services.Contracts;
using S = Portfo.Services.Model;
using System;
using System.Threading.Tasks;
using Portfo.Repo.SqlDatabase.Contracts;
using DTO = Portfo.Repo.SqlDatabase.DTO;

namespace Portfo.Services
{
    public class UserService(IUserRepository repo) : IUserService
    {
        private readonly IUserRepository _repo = repo;

        public async Task<S.User> CreateAsync(S.User user)
        {
            var userNew = await _repo.CreateAsync(new DTO.User()
            {
                Firstname = user.AuthorFirstname,
                Lastname = user.AuthorLastname,
                CreationDate = DateTime.UtcNow,
                ID = user.AuthorID,
                LastUpdateDate = DateTime.UtcNow,
                AddressID = user.AuthorAddress.AddressID
            });

            return new S.User()
            {
                AuthorAddress = new S.UserAddress()
                {
                    AddressID = userNew.AddressID
                },
                CreationDate = userNew.CreationDate,
                AuthorID = userNew.ID,
                LastUpdateDate = userNew.LastUpdateDate,
                AuthorFirstname = userNew.Firstname,
                AuthorLastname = userNew.Lastname
            };
        }

        public async Task<bool> UpdateAsync(S.User user)
        {
            var userNew = await _repo.UpdateAsync(new DTO.User
            {
                CreationDate = user.CreationDate,
                ID = user.AuthorID,
                LastUpdateDate = user.LastUpdateDate,
                Firstname = user.AuthorFirstname,
                Lastname = user.AuthorLastname,
                AddressID = user.AuthorAddress.AddressID
            });

            return userNew != default(DTO.User) && userNew.CreationDate == user.CreationDate &&
                userNew.ID == user.AuthorID && userNew.LastUpdateDate == user.LastUpdateDate &&
                userNew.Firstname == user.AuthorFirstname && userNew.Lastname == user.AuthorLastname;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repo.DeleteAsync(id) > 0;
        }

        public S.User GetAsync(Guid id)
        {
            var userNew = _repo.GetAsync(id.ToString());
            
            if (userNew != default(DTO.User))
            {
                return new S.User()
                {
                    CreationDate = userNew.CreationDate,
                    AuthorID = userNew.ID,
                    LastUpdateDate = userNew.LastUpdateDate,
                    AuthorAddress = new S.UserAddress()
                    {
                        AddressID = userNew.AddressID
                    },
                    AuthorFirstname = userNew.Firstname,
                    AuthorLastname = userNew.Lastname
                };
            }
            else
            {
                return default;
            }
        }
    }
}
