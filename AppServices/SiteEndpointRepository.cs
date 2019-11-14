using DSM.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace DSM.OrmService
{
    public class SiteEndpointRepository : BaseRepository<SiteEndpointRepository>
    {
        public SiteEndpointRepository() : base(DatabaseEngine.ConnectionString) { }

        public IEnumerable<SiteEndpoint> All()
        {
            return DataVault
                .GetList<SiteEndpoint>(DapperMethod.TrackingServices.GetSiteEndpointsAll);
        }

        public IEnumerable<SiteEndpoint> GetEndpointList(int SiteId)
        {
            return DataVault
                   .GetList<SiteEndpoint>(DapperMethod.TrackingServices.GetSiteEndpointsBySiteId,
                                                   new { @SiteId = SiteId });
        }

        public SiteEndpoint GetSiteEndpoint(int Id)
        {
            return DataVault
                .Get<SiteEndpoint>(DapperMethod.TrackingServices.GetSiteEndpointById,
                                   new { @Id = Id });
        }

        public int PostSiteEndpoint(SiteEndpoint siteEndpoint)
        {
            return DataVault
                 .Post(DapperMethod.TrackingServices.PostSiteEndpoint, siteEndpoint);
        }

        public IEnumerable<SiteEndpoint> PostSiteEndpoint(IEnumerable<SiteEndpoint> siteEndpoint)
        {
            siteEndpoint = siteEndpoint
                .GroupBy(x => new { x.SiteId, x.EndpointUrl, x.EndpointName })
                .Select(x => x.FirstOrDefault());

            return DataVault
                .Post(DapperMethod.TrackingServices.PostSiteEndpointMultiple, siteEndpoint);
        }
    }
}
