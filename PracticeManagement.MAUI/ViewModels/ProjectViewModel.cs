using System.Windows.Input;
using PracticeManagement.Library.Models;
using PracticeManagement.Library.Services;

namespace PracticeManagement.MAUI.ViewModels
{
    public class ProjectViewModel
    {
        public Project? Model { get; set; }
        public string? UpdatedShortName { get; set; }
        public string? UpdatedLongName { get; set; }
        public Client? SelectedClient { get; set; }


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
            ProjectService.Current.Delete(id);
        }

        public void ExecuteClose(Project current)
        {
            ProjectService.Current.Close(current);
        }

        public ICommand CloseCommand { get; private set; }

        public ProjectViewModel(Project currentProject)
        {
            Model = currentProject;
            if (Model != null)
            {
                UpdatedShortName = Model.ShortName;
                UpdatedLongName = Model.LongName;
                SelectedClient = currentProject.Client;

            }
            else
            {
                UpdatedShortName = "";
                UpdatedLongName = "";

            }
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ProjectViewModel).Model.Id));
            CloseCommand = new Command(
                (c) => ExecuteClose((c as ProjectViewModel).Model));



        }


        public void Add()
        {
            ProjectService.Current.Add(Model);
        }


        public List<Client> Clients
        {
            get
            {
                return new List<Client>(ClientService.Current.currentClients);
            }
        }




        public bool VerifyandUpdate()
        {
            if (SelectedClient == null || String.IsNullOrEmpty(UpdatedLongName) || String.IsNullOrEmpty(UpdatedShortName))
                return false;



            if (Model != null)
            {
                Model.ShortName = UpdatedShortName;
                Model.LongName = UpdatedLongName;
                if (!SelectedClient.Equals(Model.Client))
                {
                    Model.Client.Projects.Remove(Model);
                    Model.Client = SelectedClient;
                    SelectedClient.Projects.Add(Model);
                }
            }
            else
            {
                Model = new Project(UpdatedShortName, UpdatedLongName, SelectedClient);
                SelectedClient.Projects.Add(Model);
                Add();
            }
            return true;
        }


    }
}
