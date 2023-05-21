using System;
using PracticeManagement.ConsoleApp.Models;

namespace PracticeManagement // Note: actual namespace depends on the project name.
{
    internal class Program
    {
      
        static public void Main(string[] args)
        {
            List <Client> clients = new List <Client> ();
            List <Project> projects = new List <Project> ();

            while (true)
            {
                Console.WriteLine(
                    "a -> add Client\n" +
                    "p -> add Project\n"+
                    "w -> link project to client\n"+
                    "c -> list all clients\n"+
                    "l -> list all projects\n"+
                    "d -> delete project\n"+
                    "r -> remove client\n" +
                    "Enter your selection\n");

                string input = Console.ReadLine();
                if (input == "q")
                    break;

                if (input == "a")
                {
                    DateTime start = DateTime.Now;
                    Console.WriteLine("Enter name\n");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Enter notes\n");
                    string Notes = Console.ReadLine();
                    Client myClient = new Client(start, Name, Notes);
                    clients.Add (myClient);
                    Console.WriteLine("Client successfully added\n");
                }
                else if (input == "c" )
                {
                    clients.ForEach(client => { client.display(); });
                }
                else if (input == "r")
                {
                    Console.WriteLine("Enter client number to delete\n");
                    int delNum = Convert.ToInt32(Console.ReadLine());
                    var result = clients.Find(x => x.Id == delNum);
                    if (result == null)
                        Console.WriteLine("That id is not present");
                    else
                    {
                        clients.Remove(result);
                        Console.WriteLine("Successfully deleted");
                    }
                    

                }
                else if (input == "d" )
                {
                    Console.WriteLine("Enter project number to delete\n");
                    int delNum = Convert.ToInt32(Console.ReadLine());
                    projects.Find(x => x.Id == delNum);
                    Console.WriteLine("Successfully deleted");
                }
            }
            
           
        }

    }
}