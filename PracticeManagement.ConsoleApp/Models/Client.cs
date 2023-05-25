using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.ConsoleApp.Models
{

    public class Client
    {
        public Client(int id, string name, string notes)
        {
            Id = id;
            OpenDate = DateTime.Now;
            isActive = true;
            Name = name;
            Notes = notes;
        }

        public Client()
        {
           Name = string.Empty;
        }
        public int Id { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public bool isActive { get; set; }

        public string Name { get; set; }
        public string ? Notes { get; set; }

        public override string ToString()
        {
            return $"{Id} . {Name} . {Notes}";
        }
    }
}