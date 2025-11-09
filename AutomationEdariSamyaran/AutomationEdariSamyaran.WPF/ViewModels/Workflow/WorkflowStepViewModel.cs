using AutomationEdariSamyaran.WPF.Models;
using AutomationEdariSamyaran.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class WorkflowStepViewModel : ObservableObject
    {
        private readonly RestApiService _apiService;
        public int WorkflowId { get; set; }

        [ObservableProperty]
        private ObservableCollection<WorkflowStepDto> _steps = new();

        public WorkflowStepViewModel(RestApiService apiService, int workflowId)
        {
            _apiService = apiService;
            WorkflowId = workflowId;
            LoadSteps();
        }

        private async void LoadSteps()
        {
            var list = await _apiService.GetWorkflowStepsAsync(WorkflowId);
            Steps = new ObservableCollection<WorkflowStepDto>(list ?? new List<WorkflowStepDto>());
        }

        [RelayCommand]
        private void Cancel(Window window)
        {
            window?.Close();
        }
    }

}
