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
using System.Windows.Controls;
using System.Xml.Linq;


namespace AutomationEdariSamyaran.WPF.ViewModels
{
  
    public partial class EditWorkflowStepViewModel : ObservableObject
    {
        private readonly RestApiService _apiService;

        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        private int _workflowId;

        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private int _order;

        [ObservableProperty]
        private int? _roleId;
        [ObservableProperty]
        private string? _roleName;

        public EditWorkflowStepViewModel(RestApiService apiService, WorkflowStepDto step)
        {
            _apiService = apiService;
            Id = step.Id;
            WorkflowId = step.Id;
            Name = step.Name ?? "";
            Order = step.Order;
            RoleId = step.Role.Id;
            RoleName=step.Role.Name;
        }

        [RelayCommand]
        public async Task SaveAsync()
        {
            var command = new CreateWorkflowStepCommand
            {
                WorkflowId = WorkflowId,
                Name = Name,
                Order = Order,
                RoleId = RoleId
            };

            if (Id > 0)
            {
                // TODO: اگر API ویرایش داریم، فراخوانی کن
                // await _apiService.UpdateWorkflowStepAsync(Id, command);
            }
            else
            {
                await _apiService.CreateWorkflowStepAsync(command);
            }
        }

        [RelayCommand]
        private void Cancel(Window window)
        {
            window?.Close();
        }
    }

}
