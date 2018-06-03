using System;
using System.Collections.Generic;

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
        int maxAgeLimitPassenger = 110; // No one over the age of 110 takes the bus, I'm sure.

        int adultPrice = 75;
        int adolecentPrice = 50;
        int childPrice = 25;

        int adultLimit = 25;
        int childLimit = 13;

        public void Run() {

            while(true) {
                Console.Clear();
                Console.WriteLine("=== Welcome to the bus! ===");
                Console.WriteLine("\nPlease choose your action\n" +
                                  "in the menu below.\n" +
                                  "[A] Add Passenger\n" +
                                  "[S] Show prices\n" +
                                  "[R] Remove Passenger\n" +
                                  "[C] Current passengers\n" +
                                  "[P] Passenger Interaction\n" +
                                  "[Q] Quit");
                ConsoleKeyInfo inputFromUser = Console.ReadKey(true);
                switch(inputFromUser.Key) {
                    // Add passenger
                    case ConsoleKey.A: {
                        AddPassenger();
                        break;
                    }
                    // Prices
                    case ConsoleKey.S: {
                        Console.Clear();
                        Console.WriteLine("==== Prices for the bus ====\n" +
                                          "{0}kr for passengers of age {3} or older\n" +
                                          "{1}kr for passengers of age over {4} and under {3}\n" +
                                          "{2}kr for passengers of age {4} or under", adultPrice, adolecentPrice, childPrice
                                                                                    , adultLimit, childLimit);
                        Console.WriteLine("============================\n" +
                              "Press any key to continue...");
                        Console.ReadKey(true);
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
                    case ConsoleKey.P: {
                        Console.WriteLine("===== Passenger interaction =====");
                        Console.WriteLine("  [F] Find passengers with specific age\n" +
                                          "  [T] Total age\n" +
                                          "  [A] Average age\n" +
                                          "  [M] Max age\n" +
                                          "  [S] Sort bus by age\n" +
                                          "  [P] Poke\n" +
                                          "  [C] Current genders\n" +
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
                            // Max age
                            case ConsoleKey.M: {
                                MaxAge();
                                break;
                            }
                            // Sort bus by age
                            case ConsoleKey.S: {
                                SortBusByAge();
                                break;
                            }
                            // Poke
                            case ConsoleKey.P: {
                                Poke();
                                break;
                            }
                            // Current genders
                            case ConsoleKey.C: {
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
            string newName = "";
            int newAge = 0;
            string newGender = "a";
            ConsoleKeyInfo userInput;

            Console.Clear();
            Console.WriteLine("=== Add passenger ===");
            // Input name
            while(true) {
                Console.Write("Passenger name: ");
                try {
                    newName = Console.ReadLine();
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
                    newAge = Convert.ToInt32(Console.ReadLine());
                    if(newAge > maxAgeLimitPassenger) {
                        Console.WriteLine("Please write a smaller integer.");
                    }
                    else if(newAge < 0) { // I've never heard of anyone under the age of 0.
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
                    userInput = Console.ReadKey(true);  //Save the users input as a ConsoleKeyInfo
                    newGender = userInput.Key.ToString(); // Convert that ConsoleKeyInfo to a string
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }

                if(newGender == "X" || newGender == "Y" || newGender == "Z") {
                    break;  // Successful input
                }
                else {
                    Console.WriteLine("That is out of range, please try again");
                }
            }
            // Linear search
            for(int i = 0; i < seats.Length - 1; i++) {
                if(seats[i] == null) {
                    seats[i] = new Passenger(newName, newAge, newGender);
                    break;
                }
                else {
                    continue;
                }
            }

            Console.WriteLine(); // To get some space
            Prices(newName, newAge, newGender);
            Console.WriteLine("The new passenger has now boarded the bus. \n" +
                                          "Press any key to continue...");
        }
        
        private void Prices(string name, int age, string gender) {
            // Adults
            if(age >= adultLimit) {
                switch(gender) {
                    case "X": // female
                    Console.WriteLine("Greetings Madam {0}. It will cost you {1}kr",name ,adultPrice);
                    break;
                    case "Y": // male
                    Console.WriteLine("Hello Mister {0}. It will cost you {1}kr", name, adultPrice);
                    break;
                    case "Z": // queer
                    Console.WriteLine("Greetings {0}. It will cost you {1}kr, Mirdam", name, adultPrice); // Mirdam = Madam + Mister
                    break;
                }
            }
            // Adolecents
            else if(age < adultLimit && age > childLimit) {
                switch(gender) {
                    case "X": // female
                    Console.WriteLine("Hello young woman, that will be {0}kr, {1}", adolecentPrice, name);
                    break;
                    case "Y": // male
                    Console.WriteLine("Hey, that will be {0}kr for you {1}", adolecentPrice, name);
                    break;
                    case "Z": // queer
                    Console.WriteLine("Oh hello {0}. That will be {1}kr, youngster", name, adolecentPrice);
                    break;
                }
            }
            // Children
            else if(age <= childLimit) {
                switch(gender) {
                    case "X": // female
                    Console.WriteLine("Oh hello little {0}, this will cost you {1}kr", name, childPrice);
                    break;
                    case "Y": // male
                    Console.WriteLine("Hi boy, this will cost {0}kr, {1}", childPrice, name);
                    break;
                    case "Z": // queer
                    Console.WriteLine("Hello child, it will cost {0}kr for you, {1}", childPrice, name);
                    break;
                }
            }

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
                    Console.WriteLine("{0} with {1}years", person.Name, person.Age);
                }
            }

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        private void SortBusByAge() {
            Console.Clear();
            Console.WriteLine("=== Sort the bus by age ===");

            List<Passenger> temporarySortingList = new List<Passenger>();

            // Adds all passengers in the temporary list
            foreach(Passenger person in seats) {
                if(person == null) {
                    continue;
                }
                else {
                    temporarySortingList.Add(person);
                }
            }
            // Selection sort in temporary list
            for(int i = 0; i < temporarySortingList.Count; i++) {
                int currentIntex = i;
                for(int j = i + 1; j < temporarySortingList.Count; j++) {
                    if (temporarySortingList[j].Age < temporarySortingList[currentIntex].Age) {
                        currentIntex = j;
                    }
                }
                if(currentIntex != i) {
                    Passenger temporaryValueHolder = temporarySortingList[i];
                    temporarySortingList[i] = temporarySortingList[currentIntex];
                    temporarySortingList[currentIntex] = temporaryValueHolder;
                }
            }
            // Clear all seats
            Array.Clear(seats, 0, seats.Length - 1);
            // Add all passengers, now sorted in age
            for(int i = 0; i < temporarySortingList.Count; i++) {
                seats[i] = (temporarySortingList[i]);
            }
            // Print new passenger order
            int seatNumber = 0;
            foreach(Passenger person in seats) {
                seatNumber++;
                if(person == null) {
                    Console.WriteLine("Seatnumber {0}: This seat is empty", seatNumber);
                }
                else {
                    Console.WriteLine("Seatnumber {0}: {1}, {2} years old, {3}.", seatNumber, person.Name, person.Age, person.GenderPronoun());
                }
            }

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        private void Poke() {
            // Defining data
            int seatNumber = 0;
            int index = -1;

            Console.Clear();
            Console.WriteLine("=== Poke passenger ===");
            // Prints current passengers
            foreach(Passenger person in seats) {
                seatNumber++;
                if(person == null) {
                    Console.WriteLine("Seatnumber {0}: This seat is empty", seatNumber);
                }
                else {
                    Console.WriteLine("Seatnumber {0}: {1}, {2} years old, {3}.", seatNumber, person.Name, person.Age, person.GenderPronoun());
                }
            }
            Console.WriteLine("Choose a seatnumber for the \n" +
                              "passenger you want to poke.");
            // User input
            while(true) {
                try {
                    index = Convert.ToInt32(Console.ReadLine()) - 1; // -1 to get array index instead of seat number
                    if(index < 0 || index >= seats.Length) {
                        Console.WriteLine("Please choose a seat between 1 and {0}.", seats.Length);
                    }
                    else if(seats[index] == null) {
                        Console.WriteLine("That seat is empty, please choose another one.");
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
                // Adults
            if(seats[index].Age >= adultLimit) {
                switch(seats[index].Gender) {
                    case "X": // female
                    Console.WriteLine("{0} says with a laugh: Oh!, silly you!", seats[index].Name);
                    break;
                    case "Y": // male
                    Console.WriteLine("{0} asks: Yes? What is it?", seats[index].Name);
                    break;
                    case "Z": // queer
                    Console.WriteLine("{0} smiles softly", seats[index].Name);
                    break;
                }
            }
                // Adolecents
            else if(seats[index].Age < adultLimit && seats[index].Age > childLimit) {
                switch(seats[index].Gender) {
                    case "X": // female
                    Console.WriteLine("{0} pokes back and says: Is this a poke war?", seats[index].Name);
                    break;
                    case "Y": // male
                    Console.WriteLine("{0} says annoyingly: Screw you... ", seats[index].Name);
                    break;
                    case "Z": // queer
                    Console.WriteLine("{0} smiles and says: Hh, stop it!", seats[index].Name);
                    break;
                }
            }
                // Children
            else if(seats[index].Age <= childLimit) {
                switch(seats[index].Gender) {
                    case "X": // female
                    Console.WriteLine("{0} giggles and pokes you back", seats[index].Name);
                    break;
                    case "Y": // male
                    Console.WriteLine("{0} stares with big eyes.", seats[index].Name);
                    break;
                    case "Z": // queer
                    Console.WriteLine("{0} giggles happily", seats[index].Name);
                    break;
                }
            }

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
