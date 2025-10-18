using AutomationEdariSamyaran.WPF.Models;
using AutomationEdariSamyaran.WPF.Services;
using AutomationEdariSamyaran.WPF.Views;
using AutomationEdariSamyaran.WPF.Views.Workflow;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly RestApiService _apiService;

        [ObservableProperty]
        private string _selectedAction;

        [ObservableProperty]
        private UserControl _currentView;
        public AsyncRelayCommand<string> SelectActionCommand { get; }

        [ObservableProperty]
        private bool _isBusy;
        [ObservableProperty]
        private string _busyMessage = "در حال بارگذاری...";

        public MainViewModel()
        {
            _apiService = new RestApiService();
            SelectActionCommand = new AsyncRelayCommand<string>(SelectActionAsync);
        }


        private async Task SelectActionAsync(string action)
        {
            IsBusy = true;
            BusyMessage = "در حال بارگذاری داده‌ها...";

            SelectedAction = action;

            switch (action)
            {
                case "PersonalList":
                    CurrentView = new Views.PersonalListView();
                    break;

                case "OpenWorkflow":
                    var workflowVm = new WorkflowViewModel(_apiService);
                    var workflowView = new WorkflowUcView { DataContext = workflowVm };
                    CurrentView = workflowView;
                    break;

                case "OpenRoleList":
                    var rollVm = new RollUcViewModel(_apiService);
                    var rollView = new RollUcView(_apiService) { DataContext = rollVm };
                    CurrentView = rollView;
                    break;

                default:
                    CurrentView = new Views.AccessTreeView();
                    break;
            }

            IsBusy = false;
        }

        //[RelayCommand]
        //private void EditWorkflow(WorkflowDto selectedWorkflow)
        //{
        //    if (selectedWorkflow == null) return;

        //    // فرض می‌کنیم _apiService یک فیلد از قبل ساخته شده است
        //    var editVm = new EditWorkflowViewModel(_apiService, selectedWorkflow);

        //    var editWindow = new EditWorkflowView
        //    {
        //        DataContext = editVm
        //    };

        //    editWindow.ShowDialog();
        //}


 


    }
}
