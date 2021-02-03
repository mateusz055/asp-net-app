using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;
//Add MySql 
using MySql.Data.MySqlClient;
using WebApplication1.ViewModels;

namespace WebApplication1.Models
{
    public class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Database()
        {
            DBInitialize();
        }
        private void DBInitialize()
        {
            server = "127.0.0.1";
            database = "wyszukiwanie_film";
            uid = "root";
            password = "1234";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
        }
        public List<string>[] LoginSelect()
        {
            string query = "SELECT id_uzytkownika,login,haslo FROM uzytkownicy WHERE id_uzytkownika=1";
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();


            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id_uzytkownika"] + "");
                    list[1].Add(dataReader["login"] + "");
                    list[2].Add(dataReader["haslo"] + "");
                }

                dataReader.Close();
                this.CloseConnection();
                return list;

            } else
            {
                return list;

            }


        }
        public List<string>[] MovieSelect(string query)
        {  
            
            List<string>[] list = new List<string>[4];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();


            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["id_filmu"] + "");
                    list[1].Add(dataReader["tytul"] + "");
                    list[2].Add(dataReader["opis"] + "");
                    list[3].Add(dataReader["autor"] + "");
                }

                dataReader.Close();
                this.CloseConnection();
                return list;

            }
            else
            {
                return list;

            }
        }
    }
}