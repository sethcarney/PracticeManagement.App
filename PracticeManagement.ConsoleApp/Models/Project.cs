using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticeManagement.ConsoleApp.Models
{
    internal class Project
    {
        public Project(int id,string shortName, string longName)
        {
            Id = id;
            IsActive = true;
            OpenDate = DateTime.Now;
            ShortName = shortName;
            LongName = longName;
            ClientId = -1;
            ClientName = "";
        }

        public Project() 
        {
            ShortName = String.Empty;
            LongName = String.Empty;
            ClientName = String.Empty;
            ClientId= -1;
        }

        //This function will return true on success, and false if the client is already set
        public bool linkClient (int clientID)
        {
            if (this.ClientId == -1)
            {
                this.ClientId = clientID;

                //Insert helper function that can query client name using id && verify it is real client

                return true;
            }
            return false;
        }

        public int Id { get;  set; }
        public DateTime OpenDate { get;  set; }
        public DateTime ClosedDate { get;  set; }
        public bool IsActive { get;  set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }

        public int ClientId { get;  set; }
        public string ClientName { get;  set;}
        public override string ToString()
        {
            return $"{Id} . {ShortName} . {LongName} . {ClientId}";
        }
    }
}
