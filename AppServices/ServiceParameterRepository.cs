using DSM.Core.Interfaces.Management;
using DSM.Core.Models.Management;

namespace DSM.OrmService
{
    public class ServiceParameterRepository : BaseRepository<ServiceParameterRepository>
    {
        public ServiceParameterRepository() : base(DatabaseEngine.ManagementServerConnectionString) { }

        public ServiceParameter GetServiceParameter(int ServiceId, int ClientId)
        {
            return DataVault
                 .Get<ServiceParameter>(DapperMethod.ManagementServices.GetServiceParameter,
                                        new { @ServiceId = ServiceId, @ClientId = ClientId });
        }

        public int SetServiceParameter(IServiceParameter svcParameter)
        {
            return DataVault
                 .Post(DapperMethod.ManagementServices.SetServiceParameter, svcParameter);
        }
    }
}
