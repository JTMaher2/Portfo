using Portfo.Services.Contracts;
using S = Portfo.Services.Model;
using Portfo.Repo.SqlDatabase.Contracts;
using DTO = Portfo.Repo.SqlDatabase.DTO;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Portfo.Services
{
    public class ActivityService(IActivityRepository repo) : IActivityService
    {
        private readonly IActivityRepository _repo = repo;
        private readonly List<List<S.Activity>> listToAdd = [];

        public List<List<S.Activity>> Get(Guid postID, int pagination)
        {
            var addressNew = _repo.Get(postID);

            if (addressNew != null)
            {
                for (var i = 0; i < addressNew.Count(); i++)
                {
                    Paginate(pagination, 1, i, addressNew);
                }

                return listToAdd;
            }
            else
            {
                return null;
            }
        }

        #region Paginate
        /// <summary>
        /// Turns the data into multiple pages.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="pagination"></param>
        /// <param name="n"></param>
        /// <param name="i"></param>
        /// <param name="activityList"></param>
        /// <returns>
        /// Returns nothing.
        /// </returns>
        private void Paginate(int pagination, int n, int i, IQueryable<DTO.Activity> activityList)
        {
            if (pagination >= n)
            {
                var listToAddInner = new List<S.Activity>();

                if (pagination == n)
                {
                    for (var iList = 0; iList < n; iList++)
                    {
                        DTO.Activity existingActivity;
                        if (i + iList < activityList.Count())
                        {
                            existingActivity = activityList.Skip(i + iList).First();
                        }
                        else
                        {
                            existingActivity = activityList.Skip(i + iList - activityList.Count()).First();
                        }

                        // check if this activity has already been added
                        var alreadyAdded = false;
                        for (var j = 0; j < listToAdd.Count; j++)
                        {
                            for (var k = 0; k < listToAdd[j].Count; k++)
                            {
                                if (listToAdd[j][k].ActivityID == existingActivity.ID)
                                {
                                    alreadyAdded = true;
                                    break;
                                }
                            }
                        }
                        if (!alreadyAdded &&
                            listToAddInner.Count < activityList.Count() /* handle situation where pagination number is greater than number of activities */)
                        {
                            listToAddInner.Add(new S.Activity
                            {
                                ActivityID = existingActivity.ID,
                                ActivityOccuredAt = existingActivity.OccuredAt,
                                ActivityOperation = existingActivity.Operation,
                                ActivityUser = new S.PostUser()
                                {
                                    AuthorID = existingActivity.AuthorID,
                                    AuthorFirstname = existingActivity.AuthorFirstname,
                                    AuthorLastname = existingActivity.AuthorLastname
                                }
                            });
                        }
                        else
                        {
                            iList++; // go to next activity
                        }
                    }

                    if (listToAddInner.Count > 0)
                    {
                        listToAdd.Add(listToAddInner);
                    }
                }
                else if (pagination >= n + 1)
                {
                    Paginate(pagination, n + 1, i, activityList);
                }
            }
        }
        #endregion
    }
}
