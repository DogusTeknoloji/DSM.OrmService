using DSM.Core.Interfaces.Management;
using DSM.Core.Models.Management;
using System.Collections.Generic;

namespace DSM.OrmService
{
    public class ServiceRepository : BaseRepository<ServiceRepository>
    {
        public ServiceRepository() : base(DatabaseEngine.ManagementServerConnectionString) { }

        public IEnumerable<Service> All()
        {
            return DataVault
                 .GetList<Service>(DapperMethod.ManagementServices.GetServicesAll);
        }

        public int AddService(IService service)
        {
            return DataVault
                 .Post(DapperMethod.ManagementServices.PostService, service);
        }
    }
}
