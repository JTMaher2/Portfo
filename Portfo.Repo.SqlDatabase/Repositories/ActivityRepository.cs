using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Portfo.Repo.SqlDatabase.Context;
using Portfo.Repo.SqlDatabase.Contracts;
using Portfo.Repo.SqlDatabase.DTO;
using Portfo.Tools.Logs;

namespace Portfo.Repo.SqlDatabase.Repositories
{
    public class ActivityRepository(
        PortfoSqlDbContext sourceXSqlDBContext,
        ILogger<ActivityRepository> logger
            ) : IActivityRepository
    {
        readonly PortfoSqlDbContext _sourceXSqlDBContext = sourceXSqlDBContext;
        private readonly ILogger<ActivityRepository> _logger = logger;

        public IQueryable<Activity> Get(Guid postID)
        {
            IQueryable<Activity>? existingItem = _sourceXSqlDBContext.Activities?.Where(a => a.PostID == postID);

            if (existingItem != null)
                _logger.LogDebug("{LogsHelper}:: Found.", LogsHelper.BuildLogPrefix("ActivityRepository", "GetAsync"));
            else
                _logger.LogDebug("{LogsHelper}:: Not found.", LogsHelper.BuildLogPrefix("ActivityRepository", "GetAsync"));

            return existingItem;
        }

        public async Task<Activity> InsertAsync(Activity item)
        {
            //Create
            _sourceXSqlDBContext.Activities?.Add(item);
            _logger.LogDebug("{LogPrefix}::ID: {itemID}:: Not found. Created.", LogsHelper.BuildLogPrefix("ActivityRepository", "CreateAsync"), item.ID);

            int result = await _sourceXSqlDBContext.SaveChangesAsync();

            if (result > 0)
            {
                _logger.LogDebug("{LogsHelper}::ID: {item}:: Saved.", LogsHelper.BuildLogPrefix("ActivityRepository", "UpdateAsync"), item.ID);
                return item;
            }
            else
            {
                _logger.LogDebug("{LogsHelper}::ID: {item}:: Not saved.", LogsHelper.BuildLogPrefix("ActivityRepository", "UpdateAsync"), item.ID);
                return default;
            }
        }
    }
}
