using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using Microsoft.Extensions.Logging;

using Portfo.Repo.SqlDatabase.Context;
using Portfo.Repo.SqlDatabase.Contracts;
using Portfo.Repo.SqlDatabase.DTO;
using Portfo.Tools.Logs;

namespace Portfo.Repo.SqlDatabase.Repositories
{
    public class PostRepository(
        PortfoSqlDbContext sourceXSqlDBContext,
        ILogger<PostRepository> logger
            ) : IPostRepository
    {
        readonly PortfoSqlDbContext _sourceXSqlDBContext = sourceXSqlDBContext;
        private readonly ILogger<PostRepository> _logger = logger;

        public async Task<int> DeleteAsync(string id)
        {
            int result = 0;

            Post? existingProject = _sourceXSqlDBContext.Posts?.SingleOrDefault(p => p.ID == new Guid(id));

            if (existingProject != default(Post))
            {
                _sourceXSqlDBContext.Posts?.Remove(existingProject);
                _logger.LogDebug("{LogsHelper}::ProjectID: {id}:: Found. Deleted.", LogsHelper.BuildLogPrefix("PostRepository", "DeleteAsync"), id);

                result = await _sourceXSqlDBContext.SaveChangesAsync();
            }
            else
                _logger.LogDebug("{LogsHelper}::ProjectID: {id}:: Not found.", LogsHelper.BuildLogPrefix("PostRepository", "DeleteAsync"), id);

            return result;
        }

        public async Task<Post> CreateAsync(Post item)
        {
            Post? existingProject = await _sourceXSqlDBContext.FindAsync<Post>(item.ID);

            if (existingProject == default(Post))
            {
                //Create
                _sourceXSqlDBContext.Posts?.Add(item);
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not found. Created.", LogsHelper.BuildLogPrefix("PostRepository", "CreateAsync"), item.ID);

                int result = await _sourceXSqlDBContext.SaveChangesAsync();

                if (result > 0)
                {
                    _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Saved.", LogsHelper.BuildLogPrefix("PostRepository", "CreateAsync"), item.ID);
                    return item;
                }
                else
                {
                    _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Not saved.", LogsHelper.BuildLogPrefix("PostRepository", "CreateAsync"), item.ID);
                    return default;
                }
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {itemID}:: Already existing project.", LogsHelper.BuildLogPrefix("PostRepository", "CreateAsync"), item.ID);
                throw new Exception($"Post with id {item.ID} already exists.");
            }
        }

        public Post GetAsync(string id)
        {
            Post? existingItem = _sourceXSqlDBContext.Posts?.AsNoTracking().SingleOrDefault(p => p.ID == new Guid(id));

            if (existingItem != default(Post))
                _logger.LogDebug("{LogsHelper}::ID: {id}:: Found.", LogsHelper.BuildLogPrefix("PostRepository", "GetAsync"), id);
            else
                _logger.LogDebug("{LogsHelper}::ID: {id}:: Not found.", LogsHelper.BuildLogPrefix("PostRepository", "GetAsync"), id);

            return existingItem;
        }

        public async Task<Post> UpdateAsync(Post item)
        {
            Post? existingItem = await _sourceXSqlDBContext.FindAsync<Post>(item.ID);

            if (existingItem == null)
                _logger.LogDebug("{LogsHelper}::ID: {item.ID}:: Not found. The item cannot be updated.", LogsHelper.BuildLogPrefix("PostRepository", "UpdateAsync"), item.ID);
            else
            {
                //Update
                _sourceXSqlDBContext.Entry(existingItem).State = EntityState.Detached;

                _sourceXSqlDBContext.Posts?.Attach(item);
                _sourceXSqlDBContext.Entry(item).State = EntityState.Modified;

                _logger.LogDebug("{LogsHelper}::ID: {item.ID}:: Found. Updated.", LogsHelper.BuildLogPrefix("PostRepository", "UpdateAsync"), item.ID);
            }

            int result = await _sourceXSqlDBContext.SaveChangesAsync();

            if (result > 0)
            {
                _logger.LogDebug("{LogsHelper}::ID: {item.ID}:: Saved.", LogsHelper.BuildLogPrefix("PostRepository", "UpdateAsync"), item.ID);
                return item;
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {item.ID}:: Not saved.", LogsHelper.BuildLogPrefix("PostRepository", "UpdateAsync"), item.ID);
                return default;
            }
        }

        public async Task<Post> UpsertAsync(Post item)
        {
            Post? existingItem = await _sourceXSqlDBContext.FindAsync<Post>(item.ID);

            if (existingItem == default(Post))
            {
                //Create
                _sourceXSqlDBContext.Posts?.Add(item);
                _logger.LogDebug("{LogsHelper}::ID: {item.ID}:: Not found. Created.", LogsHelper.BuildLogPrefix("PostRepository", "UpsertAsync"), item.ID);
            }
            else
            {
                //Update
                _sourceXSqlDBContext.Entry(existingItem).State = EntityState.Detached;

                _sourceXSqlDBContext.Posts?.Attach(item);
                _sourceXSqlDBContext.Entry(item).State = EntityState.Modified;

                _logger.LogDebug("{LogsHelper}::ID: {item.ID}:: Found. Updated.", LogsHelper.BuildLogPrefix("PostRepository", "UpsertAsync"), item.ID);
            }

            int result = await _sourceXSqlDBContext.SaveChangesAsync();

            if (result > 0)
            {
                _logger.LogDebug("{LogsHelper}::ID: {item.ID}:: Saved.", LogsHelper.BuildLogPrefix("PostRepository", "UpsertAsync"), item.ID);
                return item;
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {item.ID}:: Not saved.", LogsHelper.BuildLogPrefix("PostRepository", "UpsertAsync"), item.ID);
                return default;
            }
        }
    }
}
