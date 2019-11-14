using DSM.Core.Interfaces.AppServices;
using System.Collections.Generic;

namespace DSM.OrmService.AppServices
{
    public class SiteTrackerRepository : BaseRepository<SiteTrackerRepository>
    {
        public SiteTrackerRepository() : base(DatabaseEngine.ConnectionString) { }

        public int PostSiteTracker(ISiteTracker siteTracker)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteTracker, siteTracker);
        }

        public IEnumerable<ISiteTracker> PostSiteTracker(IEnumerable<ISiteTracker> siteTracker)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteTrackerMultiple, siteTracker);
        }
    }
}
