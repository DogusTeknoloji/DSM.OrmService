using DSM.Core.Models;
using DSM.Core.Models.AuthServices;

namespace DSM.OrmService
{
    public class GatewayAutheticationRepository : BaseRepository<GatewayAutheticationRepository>
    {

        public GatewayAutheticationRepository() : base(DatabaseEngine.AuthServerConnectionString) { }

        public dynamic SignWithApiKey(string apiKey)
        {
            if (apiKey == null)
            {
                return null;
            }

            SignedUser user = DataVault
                .Get<SignedUser>(DapperMethod.AuthenticationServices.SignInWithApiKey,
                             new { @AuthKey = apiKey });

            if (user == null)
            {
                return null;
            }

            user.AuthKey = apiKey;

            return user;
        }

        public string ObtainApiKey(string username, string password, bool generateKey = true)
        {
            if (generateKey)
            {
                GenerateApiKey(username, password);
            }

            DTIISMNGUser user = DataVault
                .Get<DTIISMNGUser>(DapperMethod.AuthenticationServices.ObtainApiKey,
                                   new { @Username = username, @Password = password });

            return user?.AuthKey;
        }

        public void RemoveApiKey(string apiKey)
        {
            DataVault
                .Post(DapperMethod.AuthenticationServices.RemoveApiKey,
                      new { @ApiKey = apiKey });
        }

        public void GenerateApiKey(string username, string password)
        {
            DataVault
                .Post(DapperMethod.AuthenticationServices.GenerateApiKey,
                      new { @Username = username, @Password = password });
        }

        public bool SignUpAgent(string username, string password)
        {
            return DataVault
                .Get<int>(DapperMethod.AuthenticationServices.SignUpAgent,
                          new { @Username = username, @Password = password }) != -1;
        }

        public bool IsValidUser(string username, string password)
        {
            return DataVault
                .Get<int>(DapperMethod.AuthenticationServices.IsValidUser,
                          new { @Username = username, @Password = password }) != 0;
        }
    }
}
