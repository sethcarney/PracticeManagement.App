using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Library.Models
{

    public class Client
    {
        public Client()
        {
        }

        public Client(string name, string notes)
        {
            OpenDate = DateTime.Now;
            isActive = true;
            Name = name;
            Notes = notes;
            Projects = new List<Project>();
        }

       
        public int Id { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public bool isActive { get; set; }

        public string Name { get; set; }
        public string ? Notes { get; set; }

        public string printVal { get { return $"{Name} - {Notes}"; } }
        public List<Project> Projects { get; set; }
        public override string ToString()
        {
            return printVal;
        }
    }
}