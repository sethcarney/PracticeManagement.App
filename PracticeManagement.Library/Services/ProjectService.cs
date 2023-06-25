using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PracticeManagement.Library.Models;

namespace PracticeManagement.Library.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;
        private List<Project> projects;
        private static object _lock = new object();
        private static int _counter = 1;
        public static ProjectService Current
        {
            get
            {
                //Thread safety, mission critical
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectService();
                    }
                }
                return instance;
            }
        }

        private ProjectService() 
        {
            projects = new List<Project>();
            /*
             * projects.Add(new Project
                        {
                            Id = 1,
                            Name = "BOB",
                            Notes = "Is cool"
                        });
            projects.Add(new Project
            {
                Id = 1,
                Name = "Susan",
                Notes = "Is even cooler"
            });
            */
        }

        public List<Project> currentProjects
        {
            get { return projects; }
        }

        
        public Project? Get(int id)
        {
            return projects.FirstOrDefault(e => e.Id == id);
        }

        public Project? Get(Project project)
        {
            return projects.FirstOrDefault(e => e == project);
        }

        public void Add(Project? Project)
        {   

            if(Project != null)
            {
                Project.Id = _counter++;
                projects.Add(Project);
            }
        }

        public void Delete(int id)
        {
            var toRemove = Get(id);
            if (toRemove != null)
            {
                projects.Remove(toRemove);
            }
        }

        public void Delete(Project s)
        {
            Delete(s.Id);
        }

        public List<Project> Search (List<Project> filtered, string query)
        {
            return filtered.Where(s => s.ShortName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 || s.LongName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 || s.Client.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ).ToList();
        }
        
        public List<Project> applyFilters(SearchFilters filter)
        {
            List<Project> filtered = currentProjects;
            foreach (var filterItem in filter.Filters)
            {
                if(filterItem.Name == "Show Closed")
                 filtered = filtered.Where(p => p.isActive != filterItem.Applied).ToList();
            }

            
            return filtered;
        }
        
        public void Close(Project proj)
        {
            if (proj.isActive)
            {
                proj.isActive = false;
            }
            else
            {
                 proj.isActive= true;
            }

        }

        public void Read()
        {
            projects.ForEach(Console.WriteLine);
        }
    }
}
