using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussen {
    class Program {
        static void Main(string[] args) {
            var myBus = new Bus();
            myBus.Run();
            Console.ReadKey(true);
        }
    }
    
    class Bus {
        object[] seats = new object[25];


        public void Run() {
            Console.WriteLine("=== Welcome to the bus! ===");

            bool continueMenu = true;
            while(continueMenu) {
                Console.WriteLine("\nPlease choose your action\n" +
                                  "in the menu below.\n" +
                                  "[P] Prices\n" +
                                  "[A] Add Passenger\n" +
                                  "[R] Remove Passenger\n" +
                                  "[I] Passenger Interaction\n" +
                                  "[Q] Quit");
                ConsoleKeyInfo inputFromUser = Console.ReadKey(true);
                switch(inputFromUser.Key) {
                    case ConsoleKey.P: {
                        Console.WriteLine("Prices");
                        break;
                    }
                    case ConsoleKey.A: {
                        Console.Write("Passenger name: ");
                        string name = Console.ReadLine();
                        Console.Write("Passenger age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Choose a gender from belove \nFemale = x \nMale = y \nOther = z \n");
                        string gender = Convert.ToString(Console.ReadKey(true));

                        seats[0] = new Passenger(name, age, gender);
                        Console.WriteLine("The new passenger has now boarded the bus. \n" +
                                          "Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    case ConsoleKey.R: {
                        Console.WriteLine("Remove passenger");
                        break;
                    }

                    /*           SUB-MENU           *\ 
                    |  so it's not too overwhelming  |
                    \* to use this program. Yay.    */
                    case ConsoleKey.I: {
                        Console.WriteLine("Passenger interaction");
                        Console.WriteLine("[F] Find passengers with specific age\n" +
                                            "[T] Total age\n" +
                                            "[A] Average age\n" +
                                            "[M] Max age\n" +
                                            "[S] Sort bus by age\n" +
                                            "[P] Poke\n" +
                                            "[G] Current genders\n" +
                                            "[C] Current passengers\n" +
                                            "[R] Return \n");
                        ConsoleKeyInfo inputFromUserUndermenu = Console.ReadKey(true);

                        switch(inputFromUserUndermenu.Key) {
                            case ConsoleKey.F: {
                                Console.WriteLine("Find passengers with specific age");
                            break;
                        }
                            case ConsoleKey.T: {
                                Console.WriteLine("Total age");
                            break;
                        }
                            case ConsoleKey.A: {
                                Console.WriteLine("Average age");
                            break;
                        }
                            case ConsoleKey.M: {
                                Console.WriteLine("Max age");
                            break;
                        }
                            case ConsoleKey.S: {
                                Console.WriteLine("Sort bus by age");
                            break;
                        }
                            case ConsoleKey.P: {
                                Console.WriteLine("Poke");
                            break;
                        }
                            case ConsoleKey.G: {
                                Console.WriteLine("Current genders ");
                            break;
                        }
                            case ConsoleKey.C: {
                                Console.WriteLine("Current passengers");
                            break;
                        }
                            case ConsoleKey.R: {
                                Console.WriteLine("Returns... \n");
                            return;
                            }
                        }
                        break;
                    }
                    case ConsoleKey.Q: {
                        continueMenu = false;
                        return;
                    }
                    default: {
                        Console.WriteLine("Please choose something in the menu");
                        break;
                    }
                }

            }
        }
    }


    class Passenger {
        private static string name = "";
        private static int age = 0;
        private static string gender = "";   // I never figuerd out enum. Maybe in the future?


        public Passenger(string _name, int _age, string _gender) {
            this.Name = _name;
            this.Age = _age;
            this.Gender = _gender;
        }


        public string Name {
            get { return name; }
            set { name = value; }
        }

        public int Age {
            get { return age; }
            set { age = value; }
        }

        public string Gender {
            get {
                switch(gender) {
                    case "x":
                    gender = "Female";
                    break;

                    case "y":
                    gender = "Male";
                    break;

                    case "z":
                    gender = "Other";
                    break;
                }
                return gender;
            }
            set {
                gender = value;
            }
        } 
    }
}
