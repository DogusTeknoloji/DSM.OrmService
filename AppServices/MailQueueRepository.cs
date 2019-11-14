using DSM.Core.Models;
using System.Collections.Generic;

namespace DSM.OrmService
{
    public class MailQueueRepository : BaseRepository<MailQueueRepository>
    {
        public MailQueueRepository() : base(DatabaseEngine.MailServerConnectionString) { }

        public IEnumerable<IISMailQueue> All()
        {
            return DataVault
                .GetList<IISMailQueue>(DapperMethod.MailServices.GetMailQueueAll);
        }
        public IISMailQueue DequeueMail()
        {
            return DataVault
                 .Get<IISMailQueue>(DapperMethod.MailServices.DequeueMail);
        }
        public IISMailQueue GetMail(int id)
        {
            return DataVault
                 .Get<IISMailQueue>(DapperMethod.MailServices.GetMail,
                                    new { @Id = id });
        }

        public int PostMailToQueue(IISMailQueue mail)
        {
            return DataVault
                 .Post(DapperMethod.MailServices.PostMailToQueue, mail);
        }

        public int DeleteMail(IISMailQueue mail)
        {
            return DataVault
                 .Post(DapperMethod.MailServices.DeleteMail, mail);
        }
    }
}
