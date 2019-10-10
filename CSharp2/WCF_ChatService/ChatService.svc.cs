using System;
using System.Collections.Generic;

namespace WCF_ChatService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ChatService.svc or ChatService.svc.cs at the Solution Explorer and start debugging.
    public class ChatService : IChatService
    {
        static List<string> listChat = new List<string>();
        static List<string> listUsers = new List<string>();

        public void AddUser(string user)
        {
            listUsers.Add(user);
        }

        public void DelUser(string user)
        {
            listUsers.Remove(user);
        }

        public string GetChat()
        {
            string chat = string.Empty;

            foreach (var s in listChat)
                chat += s + Environment.NewLine;

            return chat;
        }

        public string GetUsers()
        {
            string users = string.Empty;

            foreach (var user in listUsers)
                users += user + Environment.NewLine;

            return users;
        }

        public void Say(string str)
        {
            listChat.Add(str);
        }
    }
}
