using System.ServiceModel;

namespace WCF_ChatService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IChatService" in both code and config file together.
    [ServiceContract]
    public interface IChatService
    {
        [OperationContract]
        void AddUser(string user);

        [OperationContract]
        void DelUser(string user);

        [OperationContract]
        string GetChat();

        [OperationContract]
        string GetUsers();

        [OperationContract]
        void Say(string str);
    }
}
