using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Classroom
{
    class StudentsDatabase
    {

        private static StudentsDatabase _instance;
        
        private Random r = new Random();

        private readonly String _server = "localhost";
        private readonly String _database = "students";
        private readonly String _uid = "braviuser";
        private readonly String _password = "Z0mbies!";

        private readonly string connectionString;

        private StudentsDatabase(){
            connectionString = "SERVER=" + _server + ";"
                + "DATABASE=" + _database + ";"
                + "UID=" + _uid + ";"
                + "PASSWORD=" + _password + ";";
            

        }

        private bool OpenConnection(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException e)
            {
                switch (e.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;

                    default:
                        MessageBox.Show("An error has occured.");
                        break;
                }
                return false;
            }
        }

        

        public static StudentsDatabase GetInstance()
        {
            if (_instance == null)
                _instance = new StudentsDatabase();
            return (StudentsDatabase)_instance;
        }


        public DataTableReader ExecuteSelect(String sql) {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        OpenConnection(connection);
                        var dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        return dt.CreateDataReader();
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
            }
        }

        public bool ExecuteInsertUpdateDelete(string sql) {

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        OpenConnection(connection);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException)
            {
                throw;
                return false;
            }
        }
    }
}
