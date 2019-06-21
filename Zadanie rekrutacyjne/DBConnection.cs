using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Zadanie_rekrutacyjne {
    class DBConnection {
        private static DBConnection _instance = null;
        private DBConnection() {
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder {
                UserID = DBInfo.user,
                Password = DBInfo.password,
                Server = DBInfo.server,
                Port = uint.Parse(DBInfo.port),
                Database = DBInfo.database
            };
            Conn = new MySqlConnection(connectionStringBuilder.ToString());
        }
        public MySqlConnection Conn { get; private set; }
        public static DBConnection Instance {
            get {
                return _instance ?? (_instance = new DBConnection());
            }
        }
        public static void GetCars() {
            List<string> cars = new List<string>();
            using(MySqlConnection conn = new MySqlConnection()) {

            }
        }
    }
}
