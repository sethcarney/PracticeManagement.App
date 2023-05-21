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
                    "c -> list all clients\n"+
                    "l -> list all projects\n"+
                    "d -> delete project\n"+
                    "r -> remove client\n" +
                    "link -> project + client\n"+
                    "u -> update a client or project\n"+
                    "Enter your selection\n");

                string input = Console.ReadLine();
                Console.WriteLine("\n");
                if (input == "q")
                    break;

                if (input == "a")
                {
                    
                    Console.WriteLine("Enter name\n");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Enter notes\n");
                    string Notes = Console.ReadLine();
                    Client myClient = new Client( Name, Notes);
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
                    int delNum = Convert.ToInt32(Console.ReadLine());http://help.instructure.com/
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
                else if ( input == "p")
                {
                    Console.WriteLine("Enter the short Name \n");
                    string shortname = Console.ReadLine();
                    Console.WriteLine("Enter the long Name \n");
                    string longName = Console.ReadLine();

                    Project newProj = new Project(shortname, longName);
                    projects.Add(newProj);
                    Console.WriteLine("Project added successfully\n");
                }
                else if ( input == "l")
                {
                    projects.ForEach(project => { project.display(); });
                }
                else if ( input == "d")
                {
                    Console.WriteLine("Enter client number to delete\n");
                    int delNum = Convert.ToInt32(Console.ReadLine()); http://help.instructure.com/
                    var result = projects.Find(x => x.Id == delNum);
                    if (result == null)
                        Console.WriteLine("That id is not present");
                    else
                    {
                        projects.Remove(result);
                        Console.WriteLine("Successfully deleted");
                    }

                }
                else if (input == "link")
                {
                    Console.WriteLine("Enter client Id\n");
                    int clientNum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter project Id\n");
                    int projectNum = Convert.ToInt32(Console.ReadLine());
                    var result = clients.Find(x => x.Id == clientNum);
                    if (result == null) Console.WriteLine("Invalid client Id");
                    else
                    {
                        var projectToChange = projects.Find(x => x.Id == projectNum);
                        if (projectToChange == null) Console.WriteLine("Invalid project num");
                        else
                        {
                            projectToChange.linkClient(result.Id);
                            Console.WriteLine("Project successfully linked.\n");
                        }

                    }
                }
                else if (input == "u")
                {
                    Console.WriteLine("Would you like to update project or client (p or c)\n");
                    string choice = Console.ReadLine();
                    if (choice == "c")
                    {
                        Console.WriteLine("which client would you like to update (provide id)\n");
                        int currentID = Convert.ToInt32(Console.ReadLine());
                        var result = clients.Find(x => x.Id == currentID);
                        if (result == null) Console.WriteLine("That client does not exist !\n");
                        else
                        {
                            Console.WriteLine("What member would you like to change\n"
                                +"1 : Name\n"
                                +"2 : Notes\n");


                            int updatefield = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the new value\n");
                            string newVal = Console.ReadLine();
                            if (newVal != null)
                            {
                                if (updatefield == 1)
                                {
                                    result.Name = newVal;
                                }
                                else if (updatefield == 2)
                                {
                                    result.Notes = newVal;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid request\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid request\n");
                            }    
                        }



                    }
                    else if (choice == "p")
                    {
                        Console.WriteLine("which project would you like to update (provide id)\n");
                        int currentID = Convert.ToInt32(Console.ReadLine());
                        var result = projects.Find(x => x.Id == currentID);
                        if (result == null) Console.WriteLine("That client does not exist !\n");
                        else
                        {
                            Console.WriteLine("What member would you like to change\n"
                                + "1 : Short Name\n"
                                + "2 : Long Name\n");


                            int updatefield = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter the new value\n");
                            string newVal = Console.ReadLine();
                            if (newVal != null)
                            {
                                if (updatefield == 1)
                                {
                                    result.ShortName = newVal;
                                }
                                else if (updatefield == 2)
                                {
                                    result.LongName = newVal;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid request\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid request\n");
                            }
                        }
                    }
                }
            }
            
           
        }

    }
}