using Dapper;
using Server.Clases.Base;
using Server.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Clases.OnlineBase
{
    class OnlineGroup : Group
    {
        ChatService serv = null;
        Dictionary<OnlineUser, UserInGroup> onlineUsers = new Dictionary<OnlineUser, UserInGroup>();

        public OnlineGroup(ChatService serv) {
            this.serv = serv ?? throw new NullReferenceException("ChatService not be null!");
        }

        public void AddNewUsers(OnlineUser usr, List<int> IDs) {
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChatBase"].ConnectionString))
            {
                if (onlineUsers.FirstOrDefault((x) => x.Key.ID == usr.ID).Key != null) {
                    if (onlineUsers.FirstOrDefault((x) => x.Key.ID == usr.ID && x.Value.RoleID > 0 && x.Value.RoleID < 4).Key != null) {
                        List<UserInGroup> user = cnn.Query<UserInGroup>($"SELECT UserID FROM UsersInGroups WHERE GroupID = @ID;", new { ID }).ToList();
                        string query = String.Empty;
                        foreach (int item in IDs)
                        {
                            if (user.FirstOrDefault((x) => x.UserID == item) == null)
                                query += $"INSERT INTO UsersInGroups VALUES ({item}, {ID}, 4, 0);";
                            else
                            {
                                query = String.Empty;
                                break;
                            }
                        }
                        if (query != String.Empty)
                        {
                            cnn.Query(query);
                            Dictionary<User, UserInGroup> newUsers = new Dictionary<User, UserInGroup>();
                            // WORK STOPPED


                        }
                        else usr.SOM.Error("Incorrect users!");
                    }
                    else usr.SOM.Error("You can't adding users!");

                }
                else usr.SOM.Error("Incorrct group!");
            }
        }



    }
}
