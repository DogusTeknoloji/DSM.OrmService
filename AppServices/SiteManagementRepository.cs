namespace DSM.OrmService
{
    public class SiteManagementRepository : BaseRepository<SiteManagementRepository>
    {
        public SiteManagementRepository() : base(DatabaseEngine.ManagementServerConnectionString) { }

    }
}