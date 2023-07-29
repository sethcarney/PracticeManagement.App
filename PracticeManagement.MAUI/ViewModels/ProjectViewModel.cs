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
        public int SelectedClientId { get; set; }
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

        public void ExecuteBilling(int id)
        {
            Shell.Current.GoToAsync($"//Bills?projectId={id}?clientId=0");
        }

        public ICommand BillingCommand { get; private set; }
        public ProjectViewModel(Project currentProject)
        {
            Model = currentProject;
            if (Model != null)
            {
                UpdatedShortName = Model.ShortName;
                UpdatedLongName = Model.LongName;
                SelectedClientId = currentProject.ClientId;

            }
            else
            {
                UpdatedShortName = "";
                UpdatedLongName = "";
                SelectedClientId = 0;

            }
            DeleteCommand = new Command(
                (c) => ExecuteDelete((c as ProjectViewModel).Model.Id));
            CloseCommand = new Command(
                (c) => ExecuteClose((c as ProjectViewModel).Model));
            BillingCommand = new Command(
                (c) => ExecuteBilling((c as ProjectViewModel).Model.Id));



        }

        //TODO Enable update on proj
        public void AddorUpdate()
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
            if (SelectedClientId == 0 || String.IsNullOrEmpty(UpdatedLongName) || String.IsNullOrEmpty(UpdatedShortName))
                return false;

            var SelectedClient = ClientService.Current.Get(SelectedClientId);

            if (Model != null)
            {
               
                Model.ShortName = UpdatedShortName;
                Model.LongName = UpdatedLongName;
                if (SelectedClientId != Model.ClientId)
                {
                    var OldClient = ClientService.Current.Get(Model.ClientId);
                    OldClient.Projects.Remove(Model);
                    SelectedClient.Projects.Add(Model);
                    Model.ClientId = SelectedClientId;
                }
            }
            else
            {
                Model = new Project(UpdatedShortName, UpdatedLongName, SelectedClientId);
                SelectedClient.Projects.Add(Model);
                
            }
            AddorUpdate();
            return true;
        }


    }
}
