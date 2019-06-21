using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Zadanie_rekrutacyjne {
    class Car {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Capacity { get; set; }

        public Car(IDataReader dataReader) {
            Name = dataReader["name"].ToString();
            Model = dataReader["model"].ToString();
            Capacity = dataReader["capacity"].ToString();
        }
        public Car(string name,string model,string capacity) {
            Name = name;
            Model = model;
            Capacity = capacity;
        }
        public override string ToString() {
            return $"{Name} {Model} {Capacity}";
        }
    }
}
