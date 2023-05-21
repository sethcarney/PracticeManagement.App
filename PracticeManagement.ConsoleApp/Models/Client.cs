using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.ConsoleApp.Models
{
  
    internal class Client
    {
        private static int clientNumber = 0;
        private int numclients
        {
            get
            {
                return clientNumber;
            }
            set
            {
                clientNumber = value;
            }
        }
       public Client( DateTime openDate, string name, string notes)
        {
            Id = ++numclients;
            OpenDate = openDate;
            isActive = true;
            Name = name;
            Notes = notes;
        }
        public int Id { get; private set; }

        public DateTime OpenDate { get; private set; }
        public DateTime ClosedDate { get; private set; }

        public bool isActive { get; private set; }

        public string Name { get; private set; }
        public string Notes { get; private set; }

        public void display ()
        {
            Console.WriteLine(this.Id + "\t"+ this.Name + "\t"+ this.Notes + "\t" + this.OpenDate.ToString());
        }

    }
}
