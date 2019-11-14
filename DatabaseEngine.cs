using DSM.Core.Ops;
using DSM.Core.Ops.ConsoleTheming;
using Microsoft.Extensions.Configuration;

namespace DSM.OrmService
{
    internal static class DatabaseEngine
    {
        private static readonly IConfiguration config = AppSettingsManager.GetConfiguration();

        internal static ConsoleColorSetBlue ConsoleColor => ConsoleColorSetBlue.Instance;
#if DEBUG
        internal static string ConnectionString => config["DTServerTest"];
        internal static string AuthServerConnectionString => config["DTIISMNGAuthServerTest"];
        internal static string MailServerConnectionString => config["DTIISMMSQMailServerTest"];
        internal static string ManagementServerConnectionString => config["DTIISMManagementServerTest"];
        internal static string PlatformServicesConnectionString => config["DTIISMPlatformServiceServerTest"];
#else
        internal static string ConnectionString { get => config["DTServer"]; }
        internal static string AuthServerConnectionString { get => config["DTIISMNGAuthServer"]; }
        internal static string MailServerConnectionString { get => config["DTIISMMSQMailServer"]; }
        internal static string ManagementServerConnectionString { get => config["DTIISMManagementServer"]; }
        internal static string PlatformServicesConnectionString { get => config["DTIISMPlatformServiceServer"]; }
#endif
    }
}
