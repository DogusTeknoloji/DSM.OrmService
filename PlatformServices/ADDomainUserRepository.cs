using DSM.Core.Models.PlaftormServices;
using System.Collections.Generic;

namespace DSM.OrmService.PlatformServices
{
    public class ADDomainUserRepository : BaseRepository<ADDomainUserRepository>
    {
        public ADDomainUserRepository() : base(DatabaseEngine.PlatformServicesConnectionString) { }

        public IEnumerable<ADDomainUser> All()
        {
            return DataVault
                 .GetList<ADDomainUser>(DapperMethod.PlatformServices.GetActiveDirectoryDomainUsersAll);
        }

        public int SaveDomainUser(ADDomainUser domainUser)
        {
            return DataVault
                .Post(DapperMethod.PlatformServices.PostActiveDirectoryDomainUser, domainUser);
        }

        public IEnumerable<ADDomainUser> SaveDomainUser(IEnumerable<ADDomainUser> domainUser)
        {
            return DataVault
                .Post(DapperMethod.PlatformServices.PostActiveDirectoryDomainUserMultiple, domainUser);
        }
    }
}
