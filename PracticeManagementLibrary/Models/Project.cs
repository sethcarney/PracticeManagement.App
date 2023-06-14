using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.Library.Models
{
    public class Project
    {
        
        public Project(string shortName, string longName, Client attachedClient)
        {
            IsActive = true;
            OpenDate = DateTime.Now;
            ShortName = shortName;
            LongName = longName;
            Client = attachedClient;
        }


       
        public int Id { get;  set; }
        public DateTime OpenDate { get;  set; }
        public DateTime ClosedDate { get;  set; }
        public bool IsActive { get;  set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }

        public Client Client { get;  set; }
        public override string ToString()
        {
            return $"({ShortName})  {LongName} - {Client.Name}";
        }
    }
}
