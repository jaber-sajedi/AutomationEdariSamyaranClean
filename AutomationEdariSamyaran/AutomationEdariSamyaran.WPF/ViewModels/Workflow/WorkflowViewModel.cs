using AutomationEdariSamyaran.WPF.Models;
using AutomationEdariSamyaran.WPF.Services;
using AutomationEdariSamyaran.WPF.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class WorkflowViewModel : ObservableObject
    {
        [ObservableProperty]
        private WorkflowDto _selectedWorkflow;

        [ObservableProperty]
        private ObservableCollection<WorkflowDto> _workflows = new();

        private readonly RestApiService _apiService;

        public WorkflowViewModel(RestApiService apiService)
        {
            _apiService = apiService;
            LoadWorkflows();
        }

        private async void LoadWorkflows()
        {
            var list = await _apiService.GetWorkflowsAsync();
            Workflows = new ObservableCollection<WorkflowDto>(list ?? new List<WorkflowDto>());
        }

        [RelayCommand]
        private void AddWorkflow()
        {
            // ایجاد ViewModel برای ویرایش Workflow جدید
            var editVm = new EditWorkflowViewModel(_apiService, new WorkflowDto());
            var editWindow = new EditWorkflowView
            {
                DataContext = editVm
            };
            editWindow.ShowDialog();

            // بارگذاری مجدد لیست بعد از اضافه شدن
            LoadWorkflows();
        }

        [RelayCommand]
        private void EditWorkflow()
        {
            if (SelectedWorkflow == null) return;

            // ایجاد ViewModel برای ویرایش Workflow انتخاب شده
            var editVm = new EditWorkflowViewModel(_apiService, SelectedWorkflow);
            var editWindow = new EditWorkflowView
            {
                DataContext = editVm
            };
            editWindow.ShowDialog();

            // بارگذاری مجدد لیست بعد از ویرایش
            LoadWorkflows();
        }

        [RelayCommand]
        private void ShowSteps()
        {
            if (SelectedWorkflow == null) return;

            // نمایش مراحل Workflow انتخاب شده
            var stepsVm = new WorkflowStepViewModel(_apiService, SelectedWorkflow.Id);
            var stepsWindow = new WorkflowStepView
            {
                DataContext = stepsVm
            };
            stepsWindow.ShowDialog();
        }
    }
}
