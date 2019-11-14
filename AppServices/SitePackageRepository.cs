using DSM.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSM.OrmService.AppServices
{
    public class SitePackageRepository : BaseRepository<SitePackageRepository>
    {
        public SitePackageRepository() : base(DatabaseEngine.ConnectionString) { }

        public int PostPackageInformation(SitePackage sitePackage)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSitePackVersion, sitePackage);
        }

        public IEnumerable<SitePackage> PostPackageInformation(IEnumerable<SitePackage> sitePackage)
        {
            sitePackage = sitePackage
                .GroupBy(x => new { x.SiteId, x.Name })
                .Select(x => x.FirstOrDefault());
            return DataVault
                .Post(DapperMethod.CoreServices.PostSitePackVersionMultiple, sitePackage);
        }
    }
}
