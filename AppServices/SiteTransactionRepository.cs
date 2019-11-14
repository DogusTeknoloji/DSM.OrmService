using DSM.Core.Models;
using System;
using System.Collections.Generic;

namespace DSM.OrmService
{
    public class SiteTransactionRepository : BaseRepository<SiteTransactionRepository>
    {
        public SiteTransactionRepository() : base(DatabaseEngine.ConnectionString) { }

        public IEnumerable<SiteTransaction> All()
        {
            return DataVault
                .GetList<SiteTransaction>(DapperMethod.CoreServices.GetSiteLogsAll);
        }

        public IEnumerable<SiteTransaction> GetSiteTransaction(int SiteId)
        {
            return DataVault
                .GetList<SiteTransaction>(DapperMethod.CoreServices.GetSiteLogsBySiteId,
                                                   new { @SiteId = SiteId });
        }

        public IEnumerable<SiteTransaction> GetSiteTransactionsByServer(string ServerName)
        {
            return DataVault
                .GetList<SiteTransaction>(DapperMethod.CoreServices.GetSiteLogsByServerName,
                                                   new { @ServerName = ServerName });
        }

        public IEnumerable<SiteTransactionFilterExcludedItem> GetFilters()
        {
            return DataVault
                .GetList<SiteTransactionFilterExcludedItem>(DapperMethod.CoreServices.GetSiteLogFilterExclItemsAll);
        }

        public DateTime GetLastLogDateBySiteId(int SiteId)
        {
            return DataVault
                .Get<DateTime>(DapperMethod.CoreServices.GetLastLogDateBySiteId,
                               new { @SiteId = SiteId });
        }

        public int PostSiteTransaction(SiteTransaction siteTransaction)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteLog, siteTransaction);
        }

        public IEnumerable<SiteTransaction> PostSiteTransaction(IEnumerable<SiteTransaction> siteTransaction)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteLogMultiple, siteTransaction);
        }
    }
}
