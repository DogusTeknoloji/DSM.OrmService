using Dapper;
using DSM.Core.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DSM.OrmService
{
    public class SiteBindingRepository : BaseRepository<SiteBindingRepository>
    {
        public SiteBindingRepository() : base(DatabaseEngine.ConnectionString) { }

        public IEnumerable<SiteBinding> All()
        {
            return DataVault
                 .GetList<SiteBinding>(DapperMethod.CoreServices.GetSiteBindingsAll);
        }

        public SiteBinding GetSiteBinding(int id)
        {
            using (SqlConnection conn = DataVault.GetOpenConnection())
            {
                return conn.Query("SELECT * FROM IISSiteBinding WHERE Id=@id", new { id }).SingleOrDefault();
            }
        }

        public List<SiteBinding> GetSiteBindingsById(int SiteId)
        {
            return DataVault
                .GetList<SiteBinding>(DapperMethod.CoreServices.GetSiteBindingsBySiteId,
                                         new { @SiteId = SiteId }).ToList();
        }

        public int PostSiteBinding(SiteBinding siteBinding)
        {
            return DataVault
                 .Post(DapperMethod.CoreServices.PostSiteBinding, siteBinding);
        }
        public IEnumerable<SiteBinding> PostSiteBinding(IEnumerable<SiteBinding> siteBindings)
        {
            return DataVault
                .Post(DapperMethod.CoreServices.PostSiteBindingMultiple, siteBindings);
        }

    }
}
