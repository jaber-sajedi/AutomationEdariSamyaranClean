using AutomationEdariSamyaran.WPF.Models;
using AutomationEdariSamyaran.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class EditWorkflowViewModel : ObservableObject
    {
        private readonly RestApiService _apiService;

        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _description = string.Empty;

        public EditWorkflowViewModel(RestApiService apiService, WorkflowDto workflow)
        {
            _apiService = apiService;
            Id = workflow.Id;
            Name = workflow.Name ?? "";
            Description = workflow.Description ?? "";
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            var command = new CreateWorkflowCommand
            {
                Name = Name,
                Description = Description
            };

            if (Id > 0)
            {
                // TODO: اگر API ویرایش داریم، فراخوانی کن
                // await _apiService.UpdateWorkflowAsync(Id, command);
            }
            else
            {
                await _apiService.CreateWorkflowAsync(command);
            }
        }

        [RelayCommand]
        private void Cancel(Window window)
        {
            window?.Close();
        }
    }

}
