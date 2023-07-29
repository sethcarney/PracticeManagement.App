namespace PracticeManagement.Library.Models
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
            Projects = new List<Project>();
        }

        public Client()
        {
            Name = String.Empty;
            Notes = String.Empty;
            Projects = new List<Project>();
        }



        public int Id { get; set; }

        public DateTime OpenDate { get; set; }
        public DateTime? ClosedDate { get; set; }

        public bool isActive { get; set; }

        public string Name { get; set; }
        public string? Notes { get; set; }

        public List<Project> Projects { get; set; }
    }
}