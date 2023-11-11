using System.Diagnostics;

namespace AW_Inheritance_Business
{
    public static class UserInterface
    {
        public static void Initialise()
        {
            EmployeeManagement employeeManagement = new();
            bool repeatMenu = true;

            while (repeatMenu)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Print.TextToConsole("");
                Print.TextToConsole("*** Welcome to the Researchineer Inc. Employee Database! ***");
                Print.TextToConsole("");
                Print.TextToConsole("What would you like to do?");
                Print.TextToConsole("[1] Add an employee", true, ConsoleColor.DarkMagenta);
                Print.TextToConsole("[2] Delete an employee", true, ConsoleColor.DarkMagenta);
                Print.TextToConsole("[3] Exit", true, ConsoleColor.DarkMagenta);
                Print.TextToConsole("", false);
                string menuChoice = Console.ReadKey().KeyChar.ToString();

                switch (menuChoice)
                {
                    case "1":
                        Console.Clear();
                        AddEmployee();
                        break;
                    case "2":
                        Console.Clear();
                        DeleteEmployee();
                        break;
                    case "3":
                        Console.Clear();
                        repeatMenu = false;
                        break;
                }
            }

            void AddEmployee()
            {
                Print.TextToConsole("\n\tPlease enter new employee first name: ", false, ConsoleColor.Black, ConsoleColor.Cyan);
                Print.TextToConsole("", false);
                var firstName = Console.ReadLine();
                Print.TextToConsole("\n\tPlease enter new employee last name: ", false, ConsoleColor.Black, ConsoleColor.Cyan);
                Print.TextToConsole("", false);
                var lastName = Console.ReadLine();
                Print.TextToConsole("\n\tChoose position: [M]anager, [E]ngineer, [R]esearcher: ", false, ConsoleColor.Black, ConsoleColor.Cyan);
                Print.TextToConsole("", false);
                var positionChoice = Console.ReadKey().KeyChar.ToString().ToUpper();
                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(positionChoice) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                {
                    Print.WarningToConsole("First name, last name or type not valid.");
                }
                else
                {
                    switch (positionChoice)
                    {
                        case "M":
                            employeeManagement.AddManager(firstName, lastName);
                            Print.TextToConsole($"Added {firstName} {lastName} to database");
                            break;

                        case "E":

                            Print.TextToConsole($"\n\t{firstName} {lastName}'s engineering field: ", false, ConsoleColor.Black, ConsoleColor.Cyan);
                            Print.TextToConsole("", false);
                            var type = Console.ReadLine();
                            int experience;

                            if (string.IsNullOrWhiteSpace(type))
                            {
                                Print.WarningToConsole("Type of engineer cannot be null.");
                                break;
                            }
                            else
                            {
                                try
                                {
                                    Print.TextToConsole($"\n\t{firstName} {lastName}'s experience in years: ", false, ConsoleColor.Black, ConsoleColor.Cyan);
                                    Print.TextToConsole("", false);
                                    experience = Convert.ToInt32(Console.ReadLine());
                                }
                                catch
                                {
                                    Print.WarningToConsole("Experience must be a number.");
                                    break;
                                }
                                employeeManagement.AddEngineer(firstName, lastName, type, experience);
                                Print.TextToConsole($"Added {firstName} {lastName} to database.");

                                break;
                            }

                        case "R":
                            Print.TextToConsole($"\n\tUniversity where {firstName} {lastName} matriculated: ", false, ConsoleColor.Black, ConsoleColor.Cyan);
                            Print.TextToConsole("", false);
                            var almaMater = Console.ReadLine();

                            Print.TextToConsole($"\n\tThe topic of {firstName} {lastName}'s dissertation: ", false, ConsoleColor.Black, ConsoleColor.Cyan);
                            Print.TextToConsole("", false);
                            var dissertationTopic = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(almaMater) || string.IsNullOrWhiteSpace(dissertationTopic))
                            {
                                Print.WarningToConsole("Alma Mater or dissertation topic cannot be null.");
                                break;
                            }

                            employeeManagement.AddResearcher(firstName, lastName, almaMater, dissertationTopic);
                            Print.TextToConsole($"Added {firstName} {lastName} to database.");
                            break;
                    }
                }
                Print.TextToConsole("\n\t>> Press any key to continue.", true, ConsoleColor.Magenta);
                Console.ReadKey();

            }

            void DeleteEmployee()
            {
                Print.TextToConsole($"\n\tPlease enter the last name of the employee you would like to delete: ", false, ConsoleColor.Black, ConsoleColor.Yellow);
                Print.TextToConsole("", false);
                var searchWord = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(searchWord))
                {
                    Print.WarningToConsole("Search term must contain at least one letter.");
                }
                else
                {
                    var foundEmployees = employeeManagement.FindEmployeesByLastName(searchWord);
                    if (foundEmployees != null && foundEmployees.Count > 0)
                    {
                        for (int i = 0; i < foundEmployees.Count; i++)
                        {
                            Print.TextToConsole($"[{i}] {foundEmployees[i].FirstName} {foundEmployees[i].LastName}");
                        }
                        Print.TextToConsole("");
                        Print.TextToConsole("Please enter number of the employee you would like to delete.");
                        var numberInput = Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
                        Print.TextToConsole($"Are you sure you would like to delete {foundEmployees[numberInput].FirstName} {foundEmployees[numberInput].LastName}? [y/n]");

                        var deleteChoice = Console.ReadKey().KeyChar.ToString();

                        if (deleteChoice.ToLower() == "y")
                        {
                            employeeManagement.DeleteEmployee(foundEmployees[numberInput]);
                        }
                    }
                    else
                    {
                        Print.WarningToConsole("No names found.");
                    }
                }

                Print.TextToConsole("\n\t>> Press any key to continue.", true, ConsoleColor.Magenta);
                Console.ReadKey();
                Console.Clear();
            }
        }


    }
}