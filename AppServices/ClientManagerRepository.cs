using DSM.Core.Interfaces.Management;
using DSM.Core.Models.Management;
using System.Collections.Generic;

namespace DSM.OrmService
{
    public class ClientManagerRepository : BaseRepository<ClientManagerRepository>
    {
        public ClientManagerRepository() : base(DatabaseEngine.ManagementServerConnectionString) { }

        public Client GetClient(string machineName)
        {
            return DataVault
                .Get<Client>(DapperMethod.ManagementServices.GetClientByMachineName,
                             new { @machineName = machineName });
        }

        public IEnumerable<Client> All()
        {
            return DataVault
                .GetList<Client>(DapperMethod.ManagementServices.GetAllClients);
        }

        public int SaveClient(IClient client)
        {
            return DataVault
                .Post(DapperMethod.ManagementServices.PostClient, client);
        }

        public ServiceTimer GetScheduler(int clientId, int serviceId)
        {
            return DataVault
                .Get<ServiceTimer>(DapperMethod.ManagementServices.GetScheduler,
                                   new { @clientId = clientId, @serviceId = serviceId });
        }

        public int SetScheduler(IServiceTimer svcTimer)
        {
            return DataVault
                .Post(DapperMethod.ManagementServices.PostScheduler, svcTimer);
        }

        public int EnableScheduler(int serviceId, int clientId)
        {
            return DataVault
                .Post(DapperMethod.ManagementServices.EnableScheduler,
                      new { @serviceId = serviceId, @clientId = clientId });
        }

        public int DisableScheduler(int serviceId, int clientId)
        {
            return DataVault
                .Post(DapperMethod.ManagementServices.DisableScheduler,
                      new { @serviceId = serviceId, @clientId = clientId });
        }
    }
}
