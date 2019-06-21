using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Timers;

namespace Zadanie_rekrutacyjne {
    class CarsRepository {
        MySqlConnection conn = DBConnection.Instance.Conn;
        List<Car> cars = new List<Car>();
        List<Car> buffor = new List<Car>();
        public CarsRepository() {
            SetTimer();
        }
        private Timer aTimer;
        public void GetAllCars() {
            cars.Clear();
            using (MySqlCommand command = new MySqlCommand("SELECT * FROM CARS;", conn)) {
                conn.Open();
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read()) {
                    cars.Add(new Car(dr));
                }
                conn.Close();
                foreach (var c in cars)
                    Console.WriteLine(c);
            }
        }
        private void AddCar(Car c) {
            using (MySqlCommand command = conn.CreateCommand()) {
                conn.Open();
                command.CommandText = "INSERT INTO CARS VALUES(@name, @model, @capacity)";
                command.Parameters.AddWithValue("@name", c.Name);
                command.Parameters.AddWithValue("@model", c.Model);
                command.Parameters.AddWithValue("@capacity", c.Capacity);
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void AddToBuffer(string name, string model, string capacity) {
            buffor.Add(new Car(name, model, capacity));
        }
        private void SetTimer() {
            aTimer = new System.Timers.Timer(10000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e) {
            if (buffor.Count > 0) {
                foreach (var v in buffor)
                    AddCar(v);
                buffor.Clear();
            }

        }

    }
}
