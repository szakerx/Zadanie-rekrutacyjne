using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Zadanie_rekrutacyjne {
    class Program {
        private static CarsRepository cs = new CarsRepository();
        static void Main(string[] args) {
            bool keepGoing = true;
            while (keepGoing) {
                Console.Write("Podaj operacje (1 - lista, 2 - dodawanie, 3 – wyjscie):");
                switch (Console.ReadLine()) {
                    case "1":
                        cs.GetAllCars();
                        break;
                    case "2":
                        AddCar();
                        break;
                    case "3":
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Wprowadzono błędny znak, spróbuj ponownie");
                        break;
                }
            }
        }
        private static void AddCar() {
            string dialog;
            string name;
            string model;
            string capacity;

            Console.Write("Podaj producenta: ");
            dialog = Console.ReadLine();
            if (CheckName(dialog)) {
                name = dialog;
            }
            else {
                Console.WriteLine("Podano złego producenta");
                return;
            }

            Console.Write("Podaj model: ");
            dialog = Console.ReadLine();
            if (CheckModel(dialog)) {
                model = dialog;
            }
            else {
                Console.WriteLine("Podano zły model");
                return;
            }

            Console.Write("Podaj pojemność: ");
            dialog = Console.ReadLine();
            if (CheckCapacity(dialog)) {
                capacity = dialog;
            }
            else {
                Console.WriteLine("Podano złą pojemność");
                return;
            }
            cs.AddToBuffer(name, model, capacity);
        }
        private static bool CheckName(string name) {
            //if ((name.First() <= 90 || name.First() >= 65) && !name.Contains(" "))
            //    return true;
            Regex nameRegex = new Regex(@"^([A-Z])([a-z]+\b)$");
            if (nameRegex.IsMatch(name))
                return true;
            return false;
        }
        private static bool CheckModel(string name) {
            Regex modelRegex = new Regex(@"[A - Za - z\d]");
            if (modelRegex.IsMatch(name))
                return true;
            return false;
        }
        private static bool CheckCapacity(string name) {
            Regex capacityRegex = new Regex(@"^\d+\.\d+$");
            if (capacityRegex.IsMatch(name))
                return true;
            return false;
        }

    }
}
