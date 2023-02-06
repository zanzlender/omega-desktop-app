using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using Microsoft.Data.Sqlite;

namespace OmegaApp.Klase
{
    class Database
    {
        private static Database instance;

        //SERVER-BAZA
        //private static string connectionString = @"Data Source =31.147.204.119\PISERVER,1433; Initial Catalog =PI20_004_DB; User=PI20_004_User; Password =dt]hogeL";

        //TESTNA-BAZA
        private string connectionString = @"Data Source =" + Environment.CurrentDirectory + "\\TestnaBaza\\testna.db;";

        private static Microsoft.Data.Sqlite.SqliteConnection Connection;
        public void Connect()
        {
            Connection = new Microsoft.Data.Sqlite.SqliteConnection(connectionString);

            Connection.Open();
        }

        public void Disconnect()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }

        public IDataReader GetDataReader(string sqlUpit)
        {
            SqliteCommand command = new SqliteCommand(sqlUpit, Connection);
            return command.ExecuteReader();
        }

        public object GetValue(string sqlUpit)
        {
            SqliteCommand command = new SqliteCommand(sqlUpit, Connection);
            return command.ExecuteScalar();
        }

        public int ExecuteCommand(string sqlUpit)
        {
            SqliteCommand command = new SqliteCommand(sqlUpit, Connection);
            return command.ExecuteNonQuery();
        }

    }
}
