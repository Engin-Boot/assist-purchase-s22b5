using DataModel;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Text;

namespace DataAccessLayer
{
    public class SignupImpl : ISignup
    {

        public HttpStatusCode RegisterUser(UserData userData)
        {
            var con = GetConnection();
            con.Open();
            var cmd = new SQLiteCommand(con)
            {
                CommandText =
                       @"INSERT INTO Signup(email,password,repeatPassword) 
                                    VALUES
                                    ('"+userData.Email+"','"+userData.Password+"','"+userData.RepeatPassword+"')"
            };
            cmd.ExecuteNonQuery();
            return HttpStatusCode.OK;
        }
        private static SQLiteConnection GetConnection()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var cs = $@"URI=file:{Path.GetFullPath(Path.Combine(path!, @"..\..\..\"))}AssistPurchase.db";
            var con = new SQLiteConnection(cs);
            return con;
        }
    }
}
