namespace PracticeManagement.Library.Models
{
    public class Project
    {

        public Project(string shortName, string longName, int clientId)
        {
            isActive = true;
            OpenDate = DateTime.Now;
            ShortName = shortName;
            LongName = longName;
            ClientId = clientId;
        }
        
        public Project()
        {
            isActive = true;
            OpenDate = DateTime.Now;
            ShortName = String.Empty;
            LongName = String.Empty;
        }



        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public bool isActive { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }

        public int  ClientId { get; set; }
        
    }
}
