using Server.Clases.Base;
using Server.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Server.Clases
{
    class OnlineUser : User
    {
        static int uID { get; set; } = 0;
        public string AuthKey { get; private set; }
        public ICallBack SOM { get; private set; }

        public OnlineUser(ICallBack SOM) {
            AuthKey = Common.get_unique_string(30).Insert(15, ID.ToString());
            ID++;
            this.SOM = SOM;
        }

        public bool GetUsers(TypeGetUsers tps, out List<User> usr, int GroupID = 0) {
            usr = null;
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString)) {
                string query;
                switch (tps)
                {
                    case TypeGetUsers.All:
                        query = $"SELECT * FROM Users";
                        break;
                    case TypeGetUsers.OnlyInGroup:
                        query = $"SELECT * FROM Users WHERE ID in (SELECT UserID FROM UsersInGroups WHERE GroupID = {GroupID})";
                        break;
                    case TypeGetUsers.OnlyOutInGroup:
                        query = $"SELECT * FROM Users WHERE ID in (SELECT UserID FROM UsersInGroups WHERE GroupID <> {GroupID})";
                        break;
                    default:
                        return false;
                }
                usr = cnn.Query<User>(query).ToList();
                return true;
            }
        }

        public bool RemoveGroup(int ID) {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
            {
                if (cnn.Query<UserInGroup>($"(SELECT UserID FROM UsersInGroups WHERE UserID = {this.ID} AND GroupID = {ID} AND RoleID = 1").Count() > 0)
                {
                    cnn.Query($"UPDATE Groups SET IsDeleted = 1 WHERE ID = {ID};");
                    return true;
                }
            }
            return false;
        }

        public bool CreateGroup(string name) {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
            {
                if (cnn.Query<Group>($"SELECT ID FROM Groups WHERE Name = '{name}' AND ID in (SELECT GroupID FROM UsersInGroups WHERE UserID = {ID} AND RoleID = 1);").Count() == 0)
                {
                    cnn.Query($"INSERT INTO Groups VALUES (Name = '{AuthKey}');");
                    cnn.Query($"INSERT INTO UsersInGroups VALUES ({ID}, (SELECT ID FROM Groups WHERE Name = '{AuthKey}'), 0, 0);");
                    cnn.Query($"UPDATE Groups SET Name = '{name}' WHERE Name = '{AuthKey}'");
                    return true;
                }
            }
            return false;
        }

        public bool AddUsersToGroup(int ID, List<int> IDs) {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
            {
                if (cnn.Query<Group>($"SELECT ID FROM Groups WHERE ID = {ID} AND ID in (SELECT GroupID FROM UsersInGroups WHERE UserID = {this.ID});").Count() > 0)
                {
                    foreach (int item in IDs)
                    {
                        try
                        {
                            if (cnn.Query<UserInGroup>($"SELECT UserID FROM UsersInGroups WHERE GroupID = {ID} AND UserID = {item} ") == null)
                                cnn.Query($"INSERT INTO UsersInGroups VALUES ({item}, {ID}, 4, 0)");
                        }
                        catch (Exception)
                        {
                            return false;
                        }
                       
                    }
                    return true;
                }
            }
            return false;
        }

        public bool GetMyGroups(out Dictionary<Group, UserInGroup> group) {
            group = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
                {
                    List<UserInGroup> user = cnn.Query<UserInGroup>($"SELECT * FROM UsersInGroups WHERE UserID = {ID};").ToList();
                    group = new Dictionary<Group, UserInGroup>();
                    foreach (UserInGroup item in user)
                        group.Add(cnn.Query<Group>($"SLECT TOP(1) * FROM Groups WHERE ID = {item.GroupID}").First(), item);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GetMessages(int groupID, TypeGetMessage tgm, int count, out List<GroupMessage> grMsg) {
            grMsg = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
                {
                    if (cnn.Query<UserInGroup>($"SELECT TOP(1) ID FROM Users WHERE ID in (SELECT UserID FROM UsersInGroups WHERE GroupID = {groupID});").Count() > 0) {
                        grMsg = cnn.Query<GroupMessage>($"SELECT " + (tgm != TypeGetMessage.All ? $"TOP({count}" : String.Empty) + " * FROM GroupsMessages WHERE GroupID = ID ORDER BY ID" + (TypeGetMessage.Last == tgm ? "DESC;" : ";")).ToList();
                        return true;
                    }
                    
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SendMessage (int groupID, string message)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
                {
                    if (cnn.Query<UserInGroup>($"SELECT TOP(1) GroupID FROM UsersInGroups WHERE UserID = {ID} AND GroupID = {groupID};").Count() > 0)
                    {
                        cnn.Query($"INSERT INTO GroupsMessages VALUES ({ID}, {groupID}, '{message}', 0);");
                        return true;
                    }

                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
