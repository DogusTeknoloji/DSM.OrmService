using DSM.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSM.OrmService
{
    public class SiteWebConfigurationRepository : BaseRepository<SiteWebConfigurationRepository>
    {
        public SiteWebConfigurationRepository() : base(DatabaseEngine.ConnectionString) { }

        public IEnumerable<SiteWebConfiguration> All()
        {
            return DataVault
                .GetList<SiteWebConfiguration>(DapperMethod.CoreServices.GetSiteWebConfigsAll);
        }

        public SiteWebConfiguration GetSiteWebConfiguration(int id)
        {
            return DataVault
                .Get<SiteWebConfiguration>(DapperMethod.CoreServices.GetSiteWebConfigBySiteId,
                                           new { @Id = id });
        }

        public int PostSiteWebConfiguration(SiteWebConfiguration siteWebConfiguration)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteWebConfig, siteWebConfiguration);
        }

        public IEnumerable<SiteWebConfiguration> PostSiteWebConfiguration(IEnumerable<SiteWebConfiguration> siteWebConfigurations)
        {
            siteWebConfigurations = siteWebConfigurations.GroupBy(x => x.Id).Select(x => x.FirstOrDefault());

            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteWebConfigMultiple, siteWebConfigurations);
        }
    }
}
