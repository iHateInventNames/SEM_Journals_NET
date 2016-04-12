using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SEM.WcfServiceApplication
{
    [DataContract]
    public class Subscription
    {
        [DataMember]
        public int JournalId { get; set; }

        [DataMember]
        public string Title { get; set; }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceJournalsAccess
    {
        [OperationContract]
        byte[] GetJournal(string login, string password, int value);

        [OperationContract]
        IEnumerable<Subscription> GetMySubscriptions(string login, string password);
    }
}
