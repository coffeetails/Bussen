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
        int maxAgeLimitPassenger = 110; // No one over tha age of 110 takes the bus, I'm sure.

        public void Run() {
            // Debug data
            seats[0] = new Passenger("Anna Avocado", 11, "X");
            seats[1] = new Passenger("Bärtil Banan", 22, "Y");
            seats[3] = new Passenger("Pelle Påhittad", 33, "Z");
            
            while(true) {
                Console.Clear();
                Console.WriteLine("=== Welcome to the bus! ===");
                Console.WriteLine("\nPlease choose your action\n" +
                                  "in the menu below.\n" +
                                  "[A] Add Passenger\n" +
                                  "[P] Prices\n" +
                                  "[R] Remove Passenger\n" +
                                  "[C] Current passengers\n" +
                                  "[I] Passenger Interaction\n" +
                                  "[Q] Quit");
                ConsoleKeyInfo inputFromUser = Console.ReadKey(true);
                switch(inputFromUser.Key) {
                    // Add passenger
                    case ConsoleKey.A: {
                        AddPassenger();
                        break;
                    }
                    // Prices*
                    case ConsoleKey.P: {
                        Prices();
                        break;
                    }
                    // Remove passenger
                    case ConsoleKey.R: {
                        RemovePassenger();
                        break;
                    }
                    // Current passengers
                    case ConsoleKey.C: {
                        PrintPassengers();
                        break;
                    }
                    // Sub-menu
                    case ConsoleKey.I: {
                        Console.WriteLine("===== Passenger interaction =====");
                        Console.WriteLine("  [F] Find passengers with specific age\n" +
                                          "  [T] Total age\n" +
                                          "  [A] Average age\n" +
                                          "  [M] Max age\n" +
                                          "  [S] Sort bus by age\n" +
                                          "  [P] Poke\n" +
                                          "  [G] Current genders\n" +
                                          "  [R] Return to main-menu");
                        ConsoleKeyInfo inputFromUserUndermenu = Console.ReadKey(true);
                        switch(inputFromUserUndermenu.Key) {
                            // Find passengers with specific age
                            case ConsoleKey.F: {
                                FindAge();
                                break;
                            }
                            // Total age
                            case ConsoleKey.T: {
                                TotalAge();
                                break;
                            }
                            // Average age
                            case ConsoleKey.A: {
                                AverageAge();
                                break;
                            }
                            // Max age*
                            case ConsoleKey.M: {
                                MaxAge();
                                break;
                            }
                            // Sort bus by age*
                            case ConsoleKey.S: {
                                SortBusByAge();
                                break;
                            }
                            // Poke*
                            case ConsoleKey.P: {
                                Poke();
                                break;
                            }
                            // Current genders*
                            case ConsoleKey.G: {
                                PrintGender();
                                break;
                            }
                            // Return to main-menu
                            case ConsoleKey.R: {
                                Console.WriteLine("Returns... \n" +
                                                    "============================");
                                continue;
                            }
                            default: {
                                Console.WriteLine("Please choose something in the menu");
                                break;
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

        //      METHODS FOR THE MAIN-MENU
        private void AddPassenger() {
            // Defining data
            string name = "";
            int age = 0;
            string gender = "a";
            ConsoleKeyInfo userInput;

            Console.Clear();
            Console.WriteLine("=== Add passenger ===");
            // Input name
            while(true) {
                Console.Write("Passenger name: ");
                try {
                    name = Console.ReadLine();
                    break;  // Successful input
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }
            // Input age
            while(true) {
                try {
                    Console.Write("Passenger age: ");
                    age = Convert.ToInt32(Console.ReadLine());
                    if(age > maxAgeLimitPassenger) {
                        Console.WriteLine("Please write a smaller integer.");
                    }
                    else if(age < 0) { // I've never heard of anyone under the age of 0.
                        Console.WriteLine("Please write a bigger integer.");
                    }
                    else {
                        break;  // Successful input
                    }
                }
                catch(FormatException) {
                    Console.WriteLine("Please write an integer.");
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }

            }
            // Input gender identity
            while(true) {
                Console.Write("Choose a gender from belove \nFemale = x \nMale = y \nOther = z \n");
                try {
                    userInput = Console.ReadKey(true);
                    gender = userInput.Key.ToString();
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }

                if(gender == "X" || gender == "Y" || gender == "Z") {
                    break;  // Successful input
                }
                else {
                    Console.WriteLine("That is out of range, please try again");
                }
            }
            // Linear search
            for(int i = 0; i < seats.Length - 1; i++) {
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
        }

        private void Prices()/* TODO prices */ {
            Console.Clear();
            Console.WriteLine("=== Prices ===");

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        private void RemovePassenger() {
            // Defining data
            int seatNumber = 0;
            int index = -1;

            Console.Clear();
            Console.WriteLine("=== Remove passenger ===");
            // Prints current passengers
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
            // User input
            while(true) {
                try {
                    index = Convert.ToInt32(Console.ReadLine()) - 1; // -1 to get array index instead of seat number
                    if(index < 0 || index >= seats.Length) {
                        Console.WriteLine("Please choose a seat between 1 and {0}.", seats.Length);
                    }
                    else if(seats[index] == null) {
                        Console.WriteLine("That seat is already empty, please choose another one.");
                    }
                    else {
                        break;  // Successful input
                    }
                }
                catch(FormatException) {
                    Console.WriteLine("Please write an integer.");
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }

            }
            // Output
            Console.WriteLine("\n{0} has now left the bus and \n" +
                              "seat {1} is now free to use.", seats[index].Name, index + 1);
            seats[index] = null;

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        private void PrintPassengers() {
            Console.Clear();
            Console.WriteLine("=== Current passengers ===");
            int seatNumber = 0;
            foreach(Passenger person in seats) {
                seatNumber++;
                if(person == null) {
                    Console.WriteLine("Seatnumber {0}: This seat is empty", seatNumber);
                }
                else {
                    Console.WriteLine("Seatnumber {0}: {1}, {2} years old, {3}.", seatNumber, person.Name, person.Age, person.GenderPronoun());
                    //Console.WriteLine("Debug! " + person.GenderPronoun()); // Debug info
                }
            }
            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        //      METHODS FOR THE SUB-MENU
        private void FindAge() {
            Console.Clear();
            Console.WriteLine("=== Passengers with specific age ===");

            // Input
            int findSpecificAge = 0;
            while(true) {
                Console.Write("Desired age to find among passengers: ");
                try {
                    findSpecificAge = Convert.ToInt32(Console.ReadLine());
                    if(findSpecificAge > maxAgeLimitPassenger) {
                        Console.WriteLine("Please write a smaller integer.");
                    }
                    else if(findSpecificAge < 0) {
                        Console.WriteLine("Please write a bigger integer.");
                    }
                    else {
                        break;  // Successful input
                    }
                }
                catch(FormatException) {
                    Console.WriteLine("Please write an integer.");
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }

            /*  Search for the passenger and also      *\
            \* count how many matches the desired age. */
            int numberOfFoundPassengers = 0;
            foreach(Passenger person in seats) {
                if(person == null) {
                    continue;   // Seat is empty
                }
                else if(person.Age == findSpecificAge) {
                    Console.WriteLine(person.Name);
                    numberOfFoundPassengers++;
                }
                else {
                    continue;
                }
            }
            
            if(numberOfFoundPassengers == 0) {
                Console.WriteLine("\nNo passengers matched your search.");
            }
            else {
                Console.WriteLine("\nYou got {0} matches on your search.", numberOfFoundPassengers);
            }

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        private void TotalAge() {
            Console.Clear();
            Console.WriteLine("=== Total age ===");
            int totalAgeOfPassengers = 0;
            foreach(Passenger person in seats) {
                if(person == null) {
                    continue;   // Seat is empty
                }
                else {
                    totalAgeOfPassengers += person.Age;
                }
            }
            Console.WriteLine("The total age of the current passengers is {0} years.", totalAgeOfPassengers);

            Console.WriteLine("============================\n" +
                                          "Press any key to continue...");
            Console.ReadKey(true);
        }

        private void AverageAge() {
            Console.Clear();
            Console.WriteLine("=== Average age ===");
            int numberOfPassengers = 0;
            int totalAgeOfPassengers = 0;
            foreach(Passenger person in seats) {
                if(person == null) {
                    continue;   // Seat is empty
                }
                else {
                    totalAgeOfPassengers += person.Age;
                    numberOfPassengers++;
                }
            }
            Console.WriteLine("The average age of the current passengers is {0}years.", totalAgeOfPassengers / numberOfPassengers);

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }
        
        private void MaxAge() {
            // Defining data
            int oldest = 0;

            Console.Clear();
            Console.WriteLine("=== Max Age ===");
            // Find oldest passenger
            foreach(Passenger person in seats) {
                if(person == null) {
                    continue;
                }
                else if(person.Age > oldest) {
                    oldest = person.Age;
                }
            }

            Console.WriteLine("The oldest passengers on board are: ");
            foreach(Passenger person in seats) {
                if (person == null) {
                    continue;
                }
                else if(person.Age == oldest) {
                    Console.WriteLine(person.Name);
                }
            }

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        private void SortBusByAge()/* TODO sort bus by age */ {
            // Defining data
            int i;
            int j;
            int currentIndex;

            Console.Clear();
            Console.WriteLine("=== Sort the bus by age ===");

            //Some fucking ass shit code

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        private void Poke()/* TODO poke */ {
            Console.Clear();
            Console.WriteLine("=== Poke a passenger ===");

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        private void PrintGender() {
            int seatNumber = 0;

            Console.Clear();
            Console.WriteLine("=== Current genders on the bus ===");
            foreach(Passenger person in seats) {
                seatNumber++;
                if(person == null) {
                    Console.WriteLine("Seatnumber {0}: This seat is empty", seatNumber);
                }
                else {
                    Console.WriteLine("Seatnumber {0}: Here sits a {1}", seatNumber, person.GenderPronoun());
                }
            }
            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

    }


    class Passenger {
        // Data about passenger
        private string name;
        private int age;
        private string gender;   // I never figuerd out enum. Maybe in the future?
        private int childAgeLimit = 15;
        private int adultAgeLimit = 19;


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


        public string GenderPronoun() {
            switch(gender) {
                case "X":
                case "x":
                    if(age < childAgeLimit) {
                    gender = "girl";
                    }
                    else if(age > childAgeLimit && age < adultAgeLimit) {
                    gender = "young woman";
                    }
                    else {
                    gender = "woman";
                    }
                break;

                case "Y":
                case "y":
                    if(age < childAgeLimit) {
                        gender = "boy";
                    }
                    else if(age > childAgeLimit && age < adultAgeLimit) {
                        gender = "young man";
                    }
                    else {
                        gender = "man";
                    }
                break;

                case "Z":
                case "z":
                    if(age < childAgeLimit) {
                        gender = "genderqueer child";
                    }
                    else if(age > childAgeLimit && age < adultAgeLimit) {
                        gender = "genderqueer young adult";
                    }
                    else {
                        gender = "genderqueer adult";
                    }
                break;
                }
            return gender;
        }
    }
}
