using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;
namespace PracticeManagement // Note: actual namespace depends on the project name.
{
    internal class Program
    {

        static public void Main(string[] args)
        {
            List<Project> projects = new List<Project>();
            var myClientService = ClientService.Current;
            while (true)
            {
                Console.WriteLine("C. Clients");
                Console.WriteLine("P. Projects");
                Console.WriteLine("Q. Quit");

                String choice = Console.ReadLine() ?? String.Empty;
                Console.WriteLine();
                if (choice.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    clientMenu();
                }
                else if (choice.Equals("P", StringComparison.InvariantCultureIgnoreCase))
                {
                    projectMenu(projects);
                }
                else if (choice.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid menu selection");
                }
            }
        }

        public static void clientMenu()
        {
            var myClientService = ClientService.Current;
            while (true)
            {
                Console.WriteLine("C. Create a Client");
                Console.WriteLine("R. List Clients");
                Console.WriteLine("U. Update a Client");
                Console.WriteLine("D. Delete a Client");
                Console.WriteLine("Q. Quit back to main menu");


                var input = Console.ReadLine() ?? string.Empty;
                Console.WriteLine("\n");
                //Quit if q or nothing
                if (input == string.Empty || input.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                    break;

                if (input.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter a Id:\n");
                    int id = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Enter name\n");
                    string Name = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter notes\n");
                    string Notes = Console.ReadLine() ?? string.Empty;
                    if (Name != string.Empty)
                    {
                        myClientService.Add(new Client(Name, Notes));
                        Console.WriteLine("Client successfully added\n");
                    }
                    else
                        Console.WriteLine("No name given\n");

                }
                else if (input.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    myClientService.Read();
                    Console.WriteLine();
                }
                else if (input.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter client number to delete\n");
                    myClientService.Read();
                    var delNum = Convert.ToInt32(Console.ReadLine() ?? "0");
                    //var result = clients.Find(x => x.Id == delNum);
                    myClientService.Delete(delNum);


                }
                else if (input.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter client number to update\n");
                    myClientService.Read();
                    var updateNum = Convert.ToInt32(Console.ReadLine() ?? "0");
                    //var result = clients.Find(x => x.Id == delNum);
                    var result = myClientService.Get(updateNum);
                    if (result == null)
                        Console.WriteLine("That id is not present");
                    else
                    {
                        Console.WriteLine("Enter new name\n");
                        string Name = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Enter new notes\n");
                        string Notes = Console.ReadLine() ?? string.Empty;
                        if (Name != string.Empty)
                        {
                            result.Name = Name;
                            result.Notes = Notes;
                            Console.WriteLine("Client successfully updated\n");
                        }
                        else
                            Console.WriteLine("No name given\n");
                    }
                }
                else if (input.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }
                else
                { Console.WriteLine("Invalid choice"); }
            }
        }

        public static void projectMenu(List<Project> projects)
        {
            while (true)
            {
                Console.WriteLine("C. Create a Project");
                Console.WriteLine("R. List Projects");
                Console.WriteLine("U. Update a Project");
                Console.WriteLine("D. Delete a Project");
                Console.WriteLine("Q. Quit back to main menu");

                string input = Console.ReadLine() ?? String.Empty;

                if (input.Equals("C", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter a Id:\n");
                    int id = int.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("Enter short name");
                    string shortName = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Enter long name");
                    string longName = Console.ReadLine() ?? string.Empty;
                    if (shortName != string.Empty && longName != string.Empty)
                    {
                        projects.Add(new Project(shortName, longName, new Client("Fake", "Notes")));

                        Console.WriteLine("Project successfully added\n");
                    }
                    else
                        Console.WriteLine("Invalid names given\n");

                }
                else if (input.Equals("R", StringComparison.InvariantCultureIgnoreCase))
                {
                    projects.ForEach(Console.WriteLine);
                    Console.WriteLine();
                }
                else if (input.Equals("D", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter project number to delete\n");
                    projects.ForEach(Console.WriteLine);
                    var delNum = Convert.ToInt32(Console.ReadLine() ?? "0");
                    //var result = clients.Find(x => x.Id == delNum);
                    var result = projects.FirstOrDefault(x => x.Id == delNum);
                    if (result == null)
                        Console.WriteLine("That id is not present");
                    else
                    {
                        projects.Remove(result);
                        Console.WriteLine("Successfully deleted");
                    }


                }
                else if (input.Equals("U", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Enter project number to update");
                    projects.ForEach(Console.WriteLine);
                    var updateNum = Convert.ToInt32(Console.ReadLine() ?? "0");
                    //var result = clients.Find(x => x.Id == delNum);
                    var result = projects.FirstOrDefault(x => x.Id == updateNum);
                    if (result == null)
                        Console.WriteLine("That id is not present");
                    else
                    {
                        Console.WriteLine("Enter new shortName");
                        string shortName = Console.ReadLine() ?? string.Empty;
                        Console.WriteLine("Enter new longName");
                        string longName = Console.ReadLine() ?? string.Empty;
                        if (shortName != string.Empty && longName != string.Empty)
                        {
                            Console.WriteLine("add a client id:");
                            int linkedClient = Convert.ToInt32(Console.ReadLine() ?? "0");
                            result.ShortName = shortName;
                            result.LongName = longName;


                            Console.WriteLine("Project successfully updated\n");
                        }
                        else
                            Console.WriteLine("Invalid fields given");
                    }
                }
                else if (input.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }
                else
                { Console.WriteLine("Invalid choice"); }

                Console.WriteLine();
            }
        }

    }


}
