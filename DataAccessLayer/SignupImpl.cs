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
        public bool ValidateUser(UserData user)
        {
            var con = GetConnection();
            con.Open();
            string stm = "SELECT * FROM Signup";

            using var cmd = new SQLiteCommand(stm, con);
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<UserData> registeredusers = new List<UserData>();
            var flag = false;
            while (rdr.Read())
            {
                UserData registereduser = new UserData
                {
                    Email = rdr.GetString(0),
                    Password = rdr.GetString(1),
                    RepeatPassword = rdr.GetString(2),
                };
                registeredusers.Add(registereduser);
            }
            foreach(var item in registeredusers)
            {
                if (item.Email == user.Email && item.Password == user.Password)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
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
