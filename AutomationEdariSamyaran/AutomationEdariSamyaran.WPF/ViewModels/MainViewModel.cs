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
        private string selectedAction;

        [ObservableProperty]
        private UserControl currentView;
        public AsyncRelayCommand<string> SelectActionCommand { get; }

        [ObservableProperty]
        private bool isBusy;
        [ObservableProperty]
        private string busyMessage = "در حال بارگذاری...";

        public MainViewModel()
        {
            _apiService = new RestApiService();
            SelectActionCommand = new AsyncRelayCommand<string>(SelectActionAsync);
        }


        private async Task SelectActionAsync(string action)
        {
            IsBusy = true;
            BusyMessage = "در حال بارگذاری داده‌ها...";

            // شبیه‌سازی عملیات طولانی
            await Task.Delay(1000);

            SelectedAction = action;

            switch (action)
            {
                case "PersonalList":
                    CurrentView = new Views.PersonalListView();
                    break;

                case "OpenWorkflow":
                    var workflowVm = new WorkflowViewModel(_apiService);
                    var workflowView = new WorkflowUCView { DataContext = workflowVm };
                    CurrentView = workflowView;
                    break;

                case "OpenRoleList":
                    var rollVm = new RollUCViewModel(_apiService);
                    var rollView = new RollUCView(_apiService) { DataContext = rollVm };
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



        [RelayCommand]
        public void OpenWorkflowView()
        {
            var vm = new WorkflowViewModel(_apiService);
            var window = new WorkflowView
            {
                DataContext = vm
            };
            window.Show(); // مستقل باز می‌شود
        }


    }
}
