using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussen {
    class Bus {
        static void Main(string[] args) {
            Run();
            Console.ReadKey();
        }

        static void Run() {
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
                    case ConsoleKey.P:
                    Console.WriteLine("Prices");
                    break;

                    case ConsoleKey.A:
                    Console.WriteLine("Add passenger");
                    break;

                    case ConsoleKey.R:
                    Console.WriteLine("Remove passenger");
                    break;

                    //      UNDERMENU 
                    // so it's not that overwhelming
                    // to use this program. Yay.
                    case ConsoleKey.I:
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
                        case ConsoleKey.F:
                        Console.WriteLine("Find passengers with specific age");
                        break;

                        case ConsoleKey.T:
                        Console.WriteLine("Total age");
                        break;

                        case ConsoleKey.A:
                        Console.WriteLine("Average age");
                        break;

                        case ConsoleKey.M:
                        Console.WriteLine("Max age");
                        break;

                        case ConsoleKey.S:
                        Console.WriteLine("Sort bus by age");
                        break;

                        case ConsoleKey.P:
                        Console.WriteLine("Poke");
                        break;

                        case ConsoleKey.G:
                        Console.WriteLine("Current genders ");
                        break;

                        case ConsoleKey.C:
                        Console.WriteLine("Current passengers");
                        break;

                        case ConsoleKey.R:
                        Console.WriteLine("return");
                        return;
                    }
                    break;

                    case ConsoleKey.Q:
                    continueMenu = false;
                    return;

                    default:
                    Console.WriteLine("Please choose something in the menu");
                    break;
                }
            }
        }


    }

    class Passenger {
        private string name = "";
        private int age = 0;
        private enum gender { Female = 'X', // Still trying to figue out how this works.
                              Male = 'Y',
                              Other = 'Z' };

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public int Age {
            get { return age; }
            set { age = value; }
        }
        
    }
}
