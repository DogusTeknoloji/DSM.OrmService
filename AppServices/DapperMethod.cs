namespace DSM.OrmService
{
    public struct DapperMethod
    {
        public struct AuthenticationServices
        {
            public const string SignInWithApiKey = "SP_NGateway_SignInWAuthKey";
            public const string ObtainApiKey = "SP_NGateway_ObtainAuthKey";
            public const string RemoveApiKey = "SP_NGateway_RemoveAuthKey";
            public const string GenerateApiKey = "SP_NGateway_GenerateAuthKey";
            public const string SignUpAgent = "SP_NGateway_SignUpAgent";
            public const string IsValidUser = "SP_NGateway_IsValidUser";
        }
        public struct CoreServices
        {
            public const string GetSiteAll = "SP_DTIISMCore_ListAllSites";
            public const string GetSiteById = "SP_DTIISMCore_GetSiteById";
            public const string GetSitesByServerName = "SP_DTIISMCore_GetSiteByServerName";
            public const string GetSiteBindingsAll = "SP_DTIISMCore_ListAllBindings";
            public const string GetSiteBindingsBySiteId = "SP_DTIISMCore_GetBindingBySiteId";
            public const string GetSiteEventLogsAll = "SP_DTIISMCore_ListAllSiteEventLogs";
            public const string GetSiteEventLogById = "SP_DTIISMCore_GetSiteEventLogById";
            public const string GetSiteEventLogBySiteId = "SP_DTIISMCore_GetListSiteEventLogBySiteId";
            public const string GetSiteLogsAll = "SP_DTIISMCore_ListAllTransactions";
            public const string GetSiteLogsBySiteId = "SP_DTIISMCore_GetTransactionBySiteId";
            public const string GetSiteLogsByServerName = "SP_DTIISMCore_GetTransactionByServer";
            public const string GetSiteLogFilterExclItemsAll = "SP_DTIISMCore_ListAllTransactionFilters";
            public const string GetLastLogDateBySiteId = "SP_DTIISMCore_GetTransactionLastLogDateBySiteId";
            public const string GetSiteWebConfigsAll = "SP_DTIISMCore_ListAllWebConfigs";
            public const string GetSiteWebConfigBySiteId = "SP_DTIISMCore_GetWebConfigById";

            public const string PostSitePackVersion = "SP_DTIISMCore_GetPackageVersion";
            public const string PostSite = "SP_DTIISMCore_AddNewSite";
            public const string PostSiteTracker = "SP_DTIISMCore_SiteTracker";
            public const string PostSiteBinding = "SP_DTIISMCore_AddNewBinding";
            public const string PostSiteEventLog = "SP_DTIISMCore_AddNewSiteEventLog";
            public const string PostSiteLog = "SP_DTIISMCore_AddNewTransaction";
            public const string PostSiteWebConfig = "SP_DTIISMCore_AddNewWebConfig";

            public const string PostSitePackVersionMultiple = "SP_DTIISMCore_AddPackageInfoMultiple";
            public const string PostSiteMultiple = "SP_DTIISMCore_AddNewSiteMultiple";
            public const string PostSiteTrackerMultiple = "SP_DTIISMCore_SiteTrackerMultiple";
            public const string PostSiteBindingMultiple = "SP_DTIISMCore_AddNewBindingMultiple";
            public const string PostSiteEventLogMultiple = "SP_DTIISMCore_AddNewSiteEventLogMultiple";
            public const string PostSiteLogMultiple = "SP_DTIISMCore_AddNewTransactionMultiple";
            public const string PostSiteWebConfigMultiple = "SP_DTIISMCore_AddNewWebConfigMultiple";
        }
        public struct TrackingServices
        {
            public const string GetSiteConnectionStringsAll = "SP_DTIISMSHC_ListAllConnectionStrings";
            public const string GetSiteConnectionStringBySiteId = "SP_DTIISMSHC_GetListConnectionString";
            public const string GetSiteConnectionStringById = "SP_DTIISMSHC_GetConnectionString";
            public const string GetSiteEndpointsAll = "SP_DTIISMSHC_ListAllEndpoints";
            public const string GetSiteEndpointsBySiteId = "SP_DTIISMSHC_GetListEndpoint";
            public const string GetSiteEndpointById = "SP_DTIISMSHC_GetEndpoint";

            public const string PostSiteConnectionString = "SP_DTIISMSHC_AddNewConnectionString";
            public const string PostSiteEndpoint = "SP_DTIISMSHC_AddNewEndpoint";

            public const string PostSiteConnectionStringMultiple = "SP_DTIISMSHC_AddNewConnectionStringMultiple";
            public const string PostSiteEndpointMultiple = "SP_DTIISMSHC_AddNewEndpointMultiple";
        }
        public struct ManagementServices
        {
            public const string GetClientByMachineName = "SP_DTIISMMGMT_GetClientByMachineName";
            public const string GetAllClients = "SP_DTIISMMGMT_ListAllClients";
            public const string GetScheduler = "SP_DTIISMMGMT_GetSchedulerByClientAndServiceId";
            public const string GetServiceParameter = "SP_DTIISMMGMT_GetServiceParameter";
            public const string GetServicesAll = "SP_DTIISMMGMT_ListAllServices";

            public const string PostClient = "SP_DTIISMMGMT_SaveClient";
            public const string PostScheduler = "SP_DTIISMMGMT_SetScheduler";
            public const string EnableScheduler = "SP_DTIISMMGMT_EnableScheduler";
            public const string DisableScheduler = "SP_DTIISMMGMT_DisableScheduler";
            public const string SetServiceParameter = "SP_DTIISMMGMT_SetServiceParameter";
            public const string PostService = "SP_DTIISMMGMT_AddService";
        }
        public struct MailServices
        {
            public const string GetMailQueueAll = "SP_MSQ_ListTop10000";
            public const string GetMail = "SP_MSQ_GetMailFQ";
            public const string GetMailRecipientAll = "SP_MSR_ListAll";

            public const string DequeueMail = "SQ_MSQ_DequeueMail";
            public const string PostMailToQueue = "SP_MSQ_EnqueueMail";
            public const string DeleteMail = "SP_MSQ_RemoveMail";
        }
        public struct PlatformServices
        {
            public const string GetActiveDirectoryDomainsAll = "SP_DTIISMPlatformServices_GetDomains";
            public const string GetActiveDirectoryDomainUsersAll = "SP_DTIISMPlatformServices_GetDomainUsers";

            public const string PostActiveDirectoryDomainUser = "SP_DTIISMPlatformServices_AddNewDomainUser";
            public const string PostActiveDirectoryDomainUserMultiple = "SP_DTIISMPlatformServices_AddNewDomainUserMultiple";
        }
    }
}