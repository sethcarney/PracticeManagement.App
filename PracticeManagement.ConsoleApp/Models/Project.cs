using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.ConsoleApp.Models
{
    internal class Project
    {
        public Project(int id, bool isActive, string shortName, string longName, int clientId, string clientName)
        {
            Id = id;
            IsActive = isActive;
            ShortName = shortName;
            LongName = longName;
            ClientId = clientId;
            ClientName = clientName;
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
