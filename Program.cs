using System;
using System.Collections;
using System.Linq;

class Phonebook
{
    public static void Main()
    {
        //Create Hashtable
        Hashtable pb = new Hashtable();
        string answer = "";

        //Ask user to choose a path
        while (answer != "4")
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Choose 1, to add a new contact in your phonebook, 2, to search for an existing contact, 3, to delete a contact, and 4, to exit the phonebook.");
            Console.ResetColor();
            answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.WriteLine("Enter a valid phone number that consists of exactly 10 digits and starts with a zero:");
                int num = 0;
                int count = 0;
                string number = Console.ReadLine();
                count = number.Count();
                bool result = int.TryParse(number, out num);
                if (result == true && count == 10)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Enter the corresponding name to the phone number:");
                    Console.ResetColor();
                    string name = Console.ReadLine();
                    try
                    {
                        pb.Add(num, name);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"A person with phone number {num} already exists");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered an invalid phone number.");
                    Console.ResetColor();
                }
            }
            else if (answer == "2")
            {
                Console.WriteLine("Which phone number would you like to search for?");
                int search = Convert.ToInt32(Console.ReadLine());
                if(pb.Contains(search) == true)
                {
                    string name = (string)pb[search];
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The phone number {search} is in the phonebook, under the name {name}.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The phone number {search} is NOT in the phonebook.");
                    Console.ResetColor();
                }

            }
            else if (answer == "3")
            {
                Console.WriteLine("Which phone number would you like to remove?");
                int rmvNum = Convert.ToInt32(Console.ReadLine());
                if (pb.ContainsKey(rmvNum))
                {
                    pb.Remove(rmvNum);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The phone number {rmvNum} was successfully removed from your phonebook!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("This number doesn't exist in your phonebook!");
                    Console.ResetColor();
                }
            }
            else if (answer == "4")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Input a number between 1 and 4 to access your phonebook!");
                Console.ResetColor();
            }
        }

    }
}
