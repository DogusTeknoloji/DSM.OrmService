using DSM.Core.Models;
using System.Collections.Generic;

namespace DSM.OrmService
{
    public class MailRecipientsRepository : BaseRepository<MailRecipientsRepository>
    {
        public MailRecipientsRepository() : base(DatabaseEngine.MailServerConnectionString) { }

        public IEnumerable<IISAlertMailRecipient> All()
        {
            return DataVault
                 .GetList<IISAlertMailRecipient>(DapperMethod.MailServices.GetMailRecipientAll);
        }
    }
}
