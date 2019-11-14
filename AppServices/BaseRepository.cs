using DSM.Core.Ops;
using DSM.OrmService.Ops;

namespace DSM.OrmService
{
    public abstract class BaseRepository<Class> where Class : BaseRepository<Class>, new()
    {
        private readonly DataVault vault = null;
        private readonly string _consoleTitle = null;
        public BaseRepository(string dbConnectionString)
        {
            vault = new DataVault(dbConnectionString);

            string className = typeof(Class).Name;
            _consoleTitle = $"[DB - ENGINE]({className})-> ";

            XConsole.SetDefaultColorSet(DatabaseEngine.ConsoleColor);
            XConsole.SetTitle(_consoleTitle);
        }

        protected DataVault DataVault => vault;
    }
}
