using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.ConsoleApp.Models
{
    internal class Project
    {
        private static int projectNumber = 0;
        public Project(string shortName, string longName)
        {
            Id = ++projectNumber;
            IsActive = true;
            OpenDate = DateTime.Now;
            ShortName = shortName;
            LongName = longName;
            ClientId = -1;
            ClientName = "";
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

        public void display ()
        {
            Console.WriteLine(this.Id + "\t" + this.ShortName + "\t" + this.LongName + "\t" + this.OpenDate.ToString()+ "\tLinked Client:"+this.ClientId+"\n");
        }
        public int Id { get; private set; }
        public DateTime OpenDate { get; private set; }
        public DateTime ClosedDate { get; private set; }
        public bool IsActive { get; private set; }
        public string ShortName { get; private set; }
        public string LongName { get; private set; }

        public int ClientId { get; private set; }
        public string ClientName { get; private set;}
    }
}
