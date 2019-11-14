using DSM.Core.Models.PlaftormServices;
using System.Collections.Generic;

namespace DSM.OrmService.PlatformServices
{
    public class ADDomainRepository : BaseRepository<ADDomainRepository>
    {
        public ADDomainRepository() : base(DatabaseEngine.PlatformServicesConnectionString) { }

        public IEnumerable<ADDomain> All()
        {
            return DataVault
                .Get<IEnumerable<ADDomain>>(DapperMethod.PlatformServices.GetActiveDirectoryDomainsAll);
        }
    }
}
