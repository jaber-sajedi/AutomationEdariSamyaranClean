using AutomationEdariSamyaran.WPF.Models;
using AutomationEdariSamyaran.WPF.Services;
using AutomationEdariSamyaran.WPF.Views;
using AutomationEdariSamyaran.WPF.Views.Workflow;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        public RelayCommand<string> SelectActionCommand { get; }
        public MainViewModel()
        {
            _apiService = new RestApiService();
            SelectActionCommand = new RelayCommand<string>(SelectAction);
        }
       

        // این متد Command اصلی است
        public void SelectAction(string action)
        {
            SelectedAction = action;

            switch (action)
            {
                case "PersonalList":
                    CurrentView = new Views.PersonalListView();
                    break;

             
                case "OpenWorkflow":
                    {
                        var vm = new WorkflowViewModel(_apiService);
                        var window = new WorkflowUCView
                        {
                            DataContext = vm
                        };
                        CurrentView = window;
                    }
                    break;
                // case "Cut":
                //     CurrentView = new Views.CutView();
                //     break;
                // case "Copy":
                //     CurrentView = new Views.CopyView();
                //     break;
                // case "Paste":
                //     CurrentView = new Views.PasteView();
                //     break;

                default:
                    CurrentView = new Views.AccessTreeView();
                    break;
            }
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
