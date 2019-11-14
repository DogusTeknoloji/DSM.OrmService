using DSM.Core.Models.LogServices;
using System.Collections.Generic;

namespace DSM.OrmService
{
    public class SiteLogRepository : BaseRepository<SiteLogRepository>
    {
        public SiteLogRepository() : base(DatabaseEngine.ConnectionString) { }

        public IEnumerable<SiteLog> All()
        {
            return DataVault
                 .GetList<SiteLog>(DapperMethod.CoreServices.GetSiteEventLogsAll);
        }

        public SiteLog GetSiteLog(int id)
        {
            return DataVault
                .Get<SiteLog>(DapperMethod.CoreServices.GetSiteEventLogById,
                              new { @Id = id });
        }

        public IEnumerable<SiteLog> GetSiteLogBySiteId(int SiteId)
        {
            return DataVault
                .Get<IEnumerable<SiteLog>>(DapperMethod.CoreServices.GetSiteEventLogBySiteId,
                                           new { @SiteId = SiteId });
        }
        public int PostSiteLog(SiteLog siteLog)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteEventLog, siteLog);
        }

        public IEnumerable<SiteLog> PostSiteLog(IEnumerable<SiteLog> siteLog)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteEventLogMultiple, siteLog);
        }
    }
}
