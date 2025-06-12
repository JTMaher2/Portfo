using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Portfo.Repo.SqlDatabase.Context;
using Portfo.Repo.SqlDatabase.Contracts;
using Portfo.Repo.SqlDatabase.DTO;
using Portfo.Tools.Logs;

namespace Portfo.Repo.SqlDatabase.Repositories
{
    public class AddressRepository(
        PortfoSqlDbContext sourceXSqlDBContext,
        ILogger<AddressRepository> logger
            ) : IAddressRepository
    {
        readonly PortfoSqlDbContext _sourceXSqlDBContext = sourceXSqlDBContext;
        private readonly ILogger<AddressRepository> _logger = logger;

        public async Task<int> DeleteAsync(string id)
        {
            int result = 0;

            Address? existingProject = _sourceXSqlDBContext.Addresses?.SingleOrDefault(p => p.ID == new Guid(id));

            if (existingProject != default(Address))
            {
                _sourceXSqlDBContext.Addresses?.Remove(existingProject);
                _logger.LogDebug("{LogsHelper}::ProjectID: {id}:: Found. Deleted.", LogsHelper.BuildLogPrefix("AddressRepository", "DeleteAsync"), id);

                result = await _sourceXSqlDBContext.SaveChangesAsync();
            }
            else
                _logger.LogDebug("{LogsHelper}::ProjectID: {id}:: Not found.", LogsHelper.BuildLogPrefix("AddressRepository", "DeleteAsync"), id);

            return result;
        }

        public async Task<Address> CreateAsync(Address item)
        {
            Address? existingProject = await _sourceXSqlDBContext.FindAsync<Address>(item.ID);

            if (existingProject == default(Address))
            {
                //Create
                _sourceXSqlDBContext.Addresses?.Add(item);
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not found. Created.", LogsHelper.BuildLogPrefix("AddressRepository", "CreateAsync"), item.ID);

                int result = await _sourceXSqlDBContext.SaveChangesAsync();

                if (result > 0)
                {
                    _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Saved.", LogsHelper.BuildLogPrefix("AddressRepository", "CreateAsync"), item.ID);
                    return item;
                }
                else
                {
                    _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not saved.", LogsHelper.BuildLogPrefix("AddressRepository", "CreateAsync"), item.ID);
                    return default;
                }
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Already existing project.", LogsHelper.BuildLogPrefix("AddressRepository", "CreateAsync"), item.ID);
                throw new Exception($"Address with id {item.ID} already exists.");
            }
        }

        public Address GetAsync(string id)
        {
            Address? existingItem = _sourceXSqlDBContext.Addresses?.AsNoTracking().SingleOrDefault(p => p.ID == new Guid(id));

            if (existingItem != default(Address))
                _logger.LogDebug("{LogsHelper}::ID: {id}:: Found.", LogsHelper.BuildLogPrefix("AddressRepository", "GetAsync"), id);
            else
                _logger.LogDebug("{LogsHelper}::ID: {id}:: Not found.", LogsHelper.BuildLogPrefix("AddressRepository", "GetAsync"), id);

            return existingItem;
        }

        public async Task<Address> UpdateAsync(Address item)
        {
            Address? existingItem = await _sourceXSqlDBContext.FindAsync<Address>(item.ID);

            if (existingItem == null)
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not found. The item cannot be updated.", LogsHelper.BuildLogPrefix("AddressRepository", "UpdateAsync"), item.ID);
            else
            {
                //Update
                _sourceXSqlDBContext.Entry(existingItem).State = EntityState.Detached;

                _sourceXSqlDBContext.Addresses?.Attach(item);
                _sourceXSqlDBContext.Entry(item).State = EntityState.Modified;

                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Found. Updated.", LogsHelper.BuildLogPrefix("AddressRepository", "UpdateAsync"), item.ID);
            }

            int result = await _sourceXSqlDBContext.SaveChangesAsync();

            if (result > 0)
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Saved.", LogsHelper.BuildLogPrefix("AddressRepository", "UpdateAsync"), item.ID);
                return item;
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not saved.", LogsHelper.BuildLogPrefix("AddressRepository", "UpdateAsync"), item.ID);
                return default;
            }
        }

        public async Task<Address> UpsertAsync(Address item)
        {
            Address? existingItem = await _sourceXSqlDBContext.FindAsync<Address>(item.ID);

            if (existingItem == default(Address))
            {
                //Create
                _sourceXSqlDBContext.Addresses?.Add(item);
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not found. Created.", LogsHelper.BuildLogPrefix("AddressRepository", "UpsertAsync"), item.ID);
            }
            else
            {
                //Update
                _sourceXSqlDBContext.Entry(existingItem).State = EntityState.Detached;

                _sourceXSqlDBContext.Addresses?.Attach(item);
                _sourceXSqlDBContext.Entry(item).State = EntityState.Modified;

                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Found. Updated.", LogsHelper.BuildLogPrefix("AddressRepository", "UpsertAsync"), item.ID);
            }

            int result = await _sourceXSqlDBContext.SaveChangesAsync();

            if (result > 0)
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Saved.", LogsHelper.BuildLogPrefix("AddressRepository", "UpsertAsync"), item.ID);
                return item;
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not saved.", LogsHelper.BuildLogPrefix("AddressRepository", "UpsertAsync"), item.ID);
                return default;
            }
        }
    }
}
