using DSM.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSM.OrmService
{
    public class SiteConnectionStringRepository : BaseRepository<SiteConnectionStringRepository>
    {
        public SiteConnectionStringRepository() : base(DatabaseEngine.ConnectionString) { }

        public IEnumerable<SiteConnectionString> All()
        {
            return DataVault
                .GetList<SiteConnectionString>(DapperMethod.TrackingServices.GetSiteConnectionStringsAll);
        }

        public IEnumerable<SiteConnectionString> GetConnectionStringList(int SiteId)
        {
            return DataVault
                .GetList<SiteConnectionString>(DapperMethod.TrackingServices.GetSiteConnectionStringBySiteId,
                                                        new { @SiteId = SiteId });
        }

        public SiteConnectionString GetSiteConnectionString(int id)
        {
            return DataVault
                .Get<SiteConnectionString>(DapperMethod.TrackingServices.GetSiteConnectionStringById,
                                           new { @Id = id });
        }

        public int PostSiteConnectionString(SiteConnectionString siteConnectionString)
        {
            return DataVault
                .Post(DapperMethod.TrackingServices.PostSiteConnectionString, siteConnectionString);
        }

        public IEnumerable<SiteConnectionString> PostSiteConnectionString(IEnumerable<SiteConnectionString> siteConnectionString)
        {
            siteConnectionString = siteConnectionString
                .GroupBy(x => new { x.SiteId, x.ServerName, x.DatabaseName, x.ConnectionName })
                .Select(x => x.FirstOrDefault());
            //List<SiteConnectionString> strings = siteConnectionString.ToList();
            //var q = from x in strings
            //        group x by new { x.SiteId, x.ServerName, x.DatabaseName, x.ConnectionName } into g
            //        let count = g.Count()
            //        orderby count descending
            //        select new { Value = g.Key, Count = count };
            return DataVault
                .Post(DapperMethod.TrackingServices.PostSiteConnectionStringMultiple, siteConnectionString);
        }
    }
}
