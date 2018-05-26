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
        Passenger[] seats = new Passenger[25];
        
        public void Run() {
            Console.WriteLine("=== Welcome to the bus! ===");

            //// Debug info
            seats[0] = new Passenger("Anna Avocado", 11, "x");
            seats[1] = new Passenger("Bärtil Banan", 22, "y");
            seats[3] = new Passenger("Pelle Påhittad", 33, "z");
            Console.WriteLine(0 + seats[0].Name + seats[0].Age + seats[0].Gender + "\n");
            Console.WriteLine(1 + seats[1].Name + seats[1].Age + seats[1].Gender + "\n");
            Console.WriteLine(3 + seats[3].Name + seats[3].Age + seats[3].Gender + "\n");

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
                        Console.ReadKey(true);
                        break;
                    }
                    // Add passenger
                    case ConsoleKey.A: {
                        Console.WriteLine("=== Add passenger ===");
                        Console.Write("Passenger name: ");
                        string name = Console.ReadLine();
                        Console.Write("Passenger age: ");
                        int age = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Choose a gender from belove \nFemale = x \nMale = y \nOther = z \n");
                        inputFromUser = Console.ReadKey(true);
                        string gender = inputFromUser.Key.ToString();

                        //  Linear search
                        for(int i = 0; i < seats.Length; i++) {
                            if(seats[i] == null) {
                                seats[i] = new Passenger(name, age, gender);
                                break;
                            }
                            else {
                                continue;
                            }
                        }
                        Console.WriteLine("The new passenger has now boarded the bus. \n" +
                                          "Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                    }
                    // Remove passenger
                    case ConsoleKey.R: {
                        Console.WriteLine("=== Remove passenger ===");
                        int seatNumber = 0;
                        foreach(Passenger person in seats) {
                            seatNumber++;
                            if(person == null) {
                                Console.WriteLine("Seatnumber {0}: This seat is empty", seatNumber);
                            }
                            else {
                                Console.WriteLine("Seatnumber {0}: {1}", seatNumber, person.Name);
                            }
                        }
                        Console.WriteLine("Choose a seatnumber for the \n" +
                                          "passenger to be removed.");
                        int index = Convert.ToInt32(Console.ReadLine()) - 1;
                        Console.WriteLine("{0} has now left the bus and \n" +
                                          "seat {1} is now free to use.", seats[index].Name, index + 1);
                        seats[index] = null;
                        Console.ReadKey(true);
                        break;
                    }

                    /* ========= SUB-MENU ========= *\ 
                    |  so it's not too overwhelming  |
                    |  to use this program. Yay.     |
                    \* ============================ */
                    case ConsoleKey.I: {
                        Console.WriteLine("===== Passenger interaction =====");
                        Console.WriteLine("  [F] Find passengers with specific age\n" +
                                          "  [T] Total age\n" +
                                          "  [A] Average age\n" +
                                          "  [M] Max age\n" +
                                          "  [S] Sort bus by age\n" +
                                          "  [P] Poke\n" +
                                          "  [G] Current genders\n" +
                                          "  [C] Current passengers\n" +
                                          "  [R] Return to main-menu");
                        ConsoleKeyInfo inputFromUserUndermenu = Console.ReadKey(true);

                        switch(inputFromUserUndermenu.Key) {
                            // Find passengers with specific age
                            case ConsoleKey.F: { 
                            Console.WriteLine("Find passengers with specific age");
                                break;
                            }
                            // Total age
                            case ConsoleKey.T: {
                                Console.WriteLine("Total age");
                                break;
                            }
                            // Average age
                            case ConsoleKey.A: {
                                Console.WriteLine("Average age");
                                break;
                            }
                            // Max age
                            case ConsoleKey.M: {
                                Console.WriteLine("Max age");
                                break;
                            }
                            // Sort bus by age
                            case ConsoleKey.S: {
                                Console.WriteLine("Sort bus by age");
                                break;
                            }
                            // Poke
                            case ConsoleKey.P: {
                                Console.WriteLine("Poke");
                                break;
                            }
                            // Current genders
                            case ConsoleKey.G: {
                                Console.WriteLine("Current genders ");
                                break;
                            }
                            // Current passengers
                            case ConsoleKey.C: {
                                Console.WriteLine("Current passengers");
                                int seatNumber = 0;
                                foreach(Passenger person in seats) {
                                    seatNumber++;
                                    if(person == null) {
                                            Console.WriteLine("Seatnumber {0}: This seat is empty", seatNumber);
                                    }
                                    else {
                                        Console.WriteLine("Seatnumber {0}: {1}, {2} years old, {3}.", seatNumber, person.Name, person.Age, person.Gender.ToString());
                                    }
                                }
                                break;
                            }
                            // Return to main-menu
                            case ConsoleKey.R: {
                                Console.WriteLine("Returns... \n");
                                continue;
                            }

                        }
                        Console.WriteLine("============================\n" +
                                          "Press any key to continue...");
                        Console.ReadKey(true);
                        break;
                        //=== END OF SUB-MENU ===\\
                    }
                    // Close console
                    case ConsoleKey.Q: {
                        Environment.Exit(0);
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
        private string name;
        private int age;
        private string gender;   // I never figuerd out enum. Maybe in the future?


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
            get { return gender; }
            set { gender = value; }
        }


        public string GetGender(string gender) { // Add different variations of tites based on age
            switch(gender) {
                case "X":
                case "x":
                    //girl
                    //young woman
                    //woman
                break;

                case "Y":
                case "y":
                    //boy
                    //young man
                    //man
                break;

                case "Z":
                case "z":
                    //child
                    //young aduld
                    //aduld
                break;
                }
            return gender;
        }
    }
}
