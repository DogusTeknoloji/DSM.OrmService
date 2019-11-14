using DSM.Core.Interfaces.AppServices;
using DSM.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSM.OrmService
{
    public class SiteRepository : BaseRepository<SiteRepository>
    {
        public SiteRepository() : base(DatabaseEngine.ConnectionString) { }

        public IEnumerable<Site> All()
        {
            return DataVault
                 .GetList<Site>(DapperMethod.CoreServices.GetSiteAll);
        }

        public Site GetSite(int Id)
        {
            return DataVault
                 .Get<Site>(DapperMethod.CoreServices.GetSiteById,
                             new { @Id = Id });
        }

        public List<Site> GetSites(string MachineName)
        {
            return DataVault
                .GetList<Site>(DapperMethod.CoreServices.GetSitesByServerName,
                                 new { @ServerName = MachineName }).ToList();
        }

        public int PostSite(ISite site)
        {
            return DataVault
                 .Post(DapperMethod.CoreServices.PostSite, site);
        }

        public IEnumerable<Site> PostSite(IEnumerable<Site> sites)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteMultiple, sites);
        }
    }
}