using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Portfo.Repo.SqlDatabase.Context;
using Portfo.Repo.SqlDatabase.Contracts;
using Portfo.Repo.SqlDatabase.DTO;
using Portfo.Tools.Logs;

namespace Portfo.Repo.SqlDatabase.Repositories
{
    public class UserRepository(
        PortfoSqlDbContext sourceXSqlDBContext,
        ILogger<UserRepository> logger
            ) : IUserRepository
    {
        readonly PortfoSqlDbContext _sourceXSqlDBContext = sourceXSqlDBContext;
        private readonly ILogger<UserRepository> _logger = logger;

        public async Task<int> DeleteAsync(string id)
        {
            int result = 0;

            User? existingProject = _sourceXSqlDBContext.Users?.SingleOrDefault(p => p.ID == new Guid(id));

            if (existingProject != default(User))
            {
                _sourceXSqlDBContext.Users?.Remove(existingProject);
                _logger.LogDebug("{LogsHelper}::ProjectID: {id}:: Found. Deleted.", LogsHelper.BuildLogPrefix("UserRepository", "DeleteAsync"), id);

                result = await _sourceXSqlDBContext.SaveChangesAsync();
            }
            else
                _logger.LogDebug("{LogsHelper}::ProjectID: {id}:: Not found.", LogsHelper.BuildLogPrefix("UserRepository", "DeleteAsync"), id);

            return result;
        }

        public async Task<User> CreateAsync(User item)
        {
            User? existingProject = await _sourceXSqlDBContext.FindAsync<User>(item.ID);

            if (existingProject == default(User))
            {
                //Create
                _sourceXSqlDBContext.Users?.Add(item);
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not found. Created.", LogsHelper.BuildLogPrefix("UserRepository", "CreateAsync"), item.ID);

                int result = await _sourceXSqlDBContext.SaveChangesAsync();

                if (result > 0)
                {
                    _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Saved.", LogsHelper.BuildLogPrefix("UserRepository", "CreateAsync"), item.ID);
                    return item;
                }
                else
                {
                    _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not saved.", LogsHelper.BuildLogPrefix("UserRepository", "CreateAsync"), item.ID);
                    return default;
                }
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Already existing project.", LogsHelper.BuildLogPrefix("UserRepository", "CreateAsync"), item.ID);
                throw new Exception($"User with id {item.ID} already exists.");
            }
        }

        public User GetAsync(string id)
        {
            User? existingItem = _sourceXSqlDBContext.Users?.AsNoTracking().SingleOrDefault(p => p.ID == new Guid(id));

            if (existingItem != default(User))
                _logger.LogDebug("{LogsHelper}::ID: {id}:: Found.", LogsHelper.BuildLogPrefix("UserRepository", "GetAsync"), id);
            else
                _logger.LogDebug("{LogsHelper}::ID: {id}:: Not found.", LogsHelper.BuildLogPrefix("UserRepository", "GetAsync"), id);

            return existingItem;
        }

        public async Task<User> UpdateAsync(User item)
        {
            User? existingItem = await _sourceXSqlDBContext.FindAsync<User>(item.ID);

            if (existingItem == null)
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not found. The item cannot be updated.", LogsHelper.BuildLogPrefix("UserRepository", "UpdateAsync"), item.ID);
            else
            {
                //Update
                _sourceXSqlDBContext.Entry(existingItem).State = EntityState.Detached;

                _sourceXSqlDBContext.Users?.Attach(item);
                _sourceXSqlDBContext.Entry(item).State = EntityState.Modified;

                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Found. Updated.", LogsHelper.BuildLogPrefix("UserRepository", "UpdateAsync"), item.ID);
            }

            int result = await _sourceXSqlDBContext.SaveChangesAsync();

            if (result > 0)
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Saved.", LogsHelper.BuildLogPrefix("UserRepository", "UpdateAsync"), item.ID);
                return item;
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not saved.", LogsHelper.BuildLogPrefix("UserRepository", "UpdateAsync"), item.ID);
                return default;
            }
        }

        public async Task<User> UpsertAsync(User item)
        {
            User? existingItem = await _sourceXSqlDBContext.FindAsync<User>(item.ID);

            if (existingItem == default(User))
            {
                //Create
                _sourceXSqlDBContext.Users?.Add(item);
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not found. Created.", LogsHelper.BuildLogPrefix("UserRepository", "UpsertAsync"), item.ID);
            }
            else
            {
                //Update
                _sourceXSqlDBContext.Entry(existingItem).State = EntityState.Detached;

                _sourceXSqlDBContext.Users?.Attach(item);
                _sourceXSqlDBContext.Entry(item).State = EntityState.Modified;

                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Found. Updated.", LogsHelper.BuildLogPrefix("UserRepository", "UpsertAsync"), item.ID);
            }

            int result = await _sourceXSqlDBContext.SaveChangesAsync();

            if (result > 0)
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Saved.", LogsHelper.BuildLogPrefix("UserRepository", "UpsertAsync"), item.ID);
                return item;
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not saved.", LogsHelper.BuildLogPrefix("UserRepository", "UpsertAsync"), item.ID);
                return default;
            }
        }
    }
}
