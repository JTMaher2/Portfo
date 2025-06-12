using Portfo.Services.Model;
using System;
using System.Collections.Generic;

namespace Portfo.Services.Contracts
{
    public interface IActivityService
    {
        List<List<Activity>> Get(Guid postID, int pagination);
    }
}
