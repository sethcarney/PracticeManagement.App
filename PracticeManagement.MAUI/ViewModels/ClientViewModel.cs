

using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;



namespace PracticeManagement.MAUI.ViewModels
{
    public class ClientViewModel
    {
        public Client Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString() ?? string.Empty;
            }
        }

        public ICommand DeleteCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            ClientService.Current.Delete(id);
        }



        public ClientViewModel(Client client)
        {
            if (client == null)
            {
                UpdatedName = String.Empty; UpdatedNotes = String.Empty;
            }
            else
            {
                Model = client;
                UpdatedName = Model.Name;
                UpdatedNotes = Model.Notes;
            }


            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));


        }


        public void Add()
        {
            ClientService.Current.Add(Model);
        }




        public string? UpdatedName { get; set; }
        public string? UpdatedNotes { get; set; }

        public List<Project> linkedProjects { get; set; }



        public bool Update()
        {
            if (String.IsNullOrEmpty(UpdatedName))
                return false;

            if (Model != null)
            {
                Model.Name = UpdatedName;
                Model.Notes = UpdatedNotes;
            }
            else
            {
                Model = new Client(0,UpdatedName, UpdatedNotes);
                Add();
            }

            return true;
        }
    }
}
