using AutomationEdariSamyaran.WPF.Models;
using AutomationEdariSamyaran.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class RollUcViewModel: ObservableObject
    {
        [ObservableProperty]
        private List<RoleDto> _roles = new List<RoleDto>();
        [ObservableProperty]
        private RoleDto _selectedRole = new RoleDto();


        private readonly RestApiService _apiService;
        public RollUcViewModel(RestApiService apiService)
        {
            _apiService = apiService;
            _ = LoadRolesAsync();
        }


        private async Task LoadRolesAsync()
        {
            var list = await _apiService.GetRolesAsync();
            if (list != null)
            {
                foreach (var p in list)
                    Roles.Add(p);
            }
        }
    }
}
