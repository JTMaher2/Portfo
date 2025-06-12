using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Portfo.Repo.SqlDatabase.Context;
using Portfo.Repo.SqlDatabase.Contracts;
using Portfo.Repo.SqlDatabase.DTO;
using Portfo.Tools.Logs;

namespace Portfo.Repo.SqlDatabase.Repositories
{
    public class LikeRepository(
        PortfoSqlDbContext sourceXSqlDBContext,
        ILogger<LikeRepository> logger
            ) : ILikeRepository
    {
        readonly PortfoSqlDbContext _sourceXSqlDBContext = sourceXSqlDBContext;
        private readonly ILogger<LikeRepository> _logger = logger;

        public async Task<int> DeleteAsync(string id)
        {
            int result = 0;

            Like? existingProject = _sourceXSqlDBContext.Likes?.SingleOrDefault(p => p.ID == new Guid(id));

            if (existingProject != default(Like))
            {
                _sourceXSqlDBContext.Likes?.Remove(existingProject);
                _logger.LogDebug("{LogsHelper}::ProjectID: {id}:: Found. Deleted.", LogsHelper.BuildLogPrefix("LikeRepository", "DeleteAsync"), id);

                result = await _sourceXSqlDBContext.SaveChangesAsync();
            }
            else
                _logger.LogDebug("{LogsHelper}::ProjectID: {id}:: Not found.", LogsHelper.BuildLogPrefix("LikeRepository", "DeleteAsync"), id);

            return result;
        }

        public Like Get(string id)
        {
            Like? existingItem = _sourceXSqlDBContext.Likes?.AsNoTracking().SingleOrDefault(p => p.ID == new Guid(id));

            if (existingItem != default(Like))
                _logger.LogDebug("{LogsHelper}::ID: {id}:: Found.", LogsHelper.BuildLogPrefix("PostRepository", "GetAsync"), id);
            else
                _logger.LogDebug("{LogsHelper}::ID: {id}:: Not found.", LogsHelper.BuildLogPrefix("PostRepository", "GetAsync"), id);

            return existingItem;
        }

        public async Task<Like> CreateAsync(Like item)
        {
            Like? existingProject = await _sourceXSqlDBContext.FindAsync<Like>(item.ID);

            if (existingProject == default(Like))
            {
                //Create
                _sourceXSqlDBContext.Likes?.Add(item);
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not found. Created.", LogsHelper.BuildLogPrefix("LikeRepository", "CreateAsync"), item.ID);

                int result = await _sourceXSqlDBContext.SaveChangesAsync();

                if (result > 0)
                {
                    _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Saved.", LogsHelper.BuildLogPrefix("LikeRepository", "CreateAsync"), item.ID);
                    return item;
                }
                else
                {
                    _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not saved.", LogsHelper.BuildLogPrefix("LikeRepository", "CreateAsync"), item.ID);
                    return default;
                }
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Already existing project.", LogsHelper.BuildLogPrefix("LikeRepository", "CreateAsync"), item.ID);
                throw new Exception($"Like with id {item.ID} already exists.");
            }
        }

        public async Task<Like> UpdateAsync(Like item)
        {
            Like? existingItem = await _sourceXSqlDBContext.FindAsync<Like>(item.ID);

            if (existingItem == null)
                _logger.LogDebug("{LogsHelper}::ID: {item}:: Not found. The item cannot be updated.", LogsHelper.BuildLogPrefix("LikeRepository", "UpdateAsync"), item.ID);
            else
            {
                //Update
                _sourceXSqlDBContext.Entry(existingItem).State = EntityState.Detached;

                _sourceXSqlDBContext.Likes?.Attach(item);
                _sourceXSqlDBContext.Entry(item).State = EntityState.Modified;

                _logger.LogDebug("{LogsHelper}::ID: {item}:: Found. Updated.", LogsHelper.BuildLogPrefix("LikeRepository", "UpdateAsync"), item.ID);
            }

            int result = await _sourceXSqlDBContext.SaveChangesAsync();

            if (result > 0)
            {
                _logger.LogDebug("{LogsHelper}::ID: {item}:: Saved.", LogsHelper.BuildLogPrefix("LikeRepository", "UpdateAsync"), item.ID);
                return item;
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {item}:: Not saved.", LogsHelper.BuildLogPrefix("LikeRepository", "UpdateAsync"), item.ID);
                return default;
            }
        }
    }
}
