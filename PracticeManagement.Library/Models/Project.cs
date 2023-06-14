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
            isActive = true;
            OpenDate = DateTime.Now;
            ShortName = shortName;
            LongName = longName;
            Client = attachedClient;
        }


       
        public int Id { get;  set; }
        public DateTime OpenDate { get;  set; }
        public DateTime ClosedDate { get;  set; }
        public bool isActive { get;  set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }

        public Client Client { get;  set; }

        public string printVal 
        { 
            get
            {
                return $"[{ShortName}] - {LongName}\n {Client.Name}";
            } 
        }
        public override string ToString()
        {
            return printVal;
        }
    }
}
