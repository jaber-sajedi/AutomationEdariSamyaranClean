using AutomationEdariSamyaran.WPF.Models;
using AutomationEdariSamyaran.WPF.Services;
using AutomationEdariSamyaran.WPF.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class PersonalListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PersonalDto> personals = new();

        [ObservableProperty]
        private PersonalDto selectedPersonal;

        private readonly RestApiService _apiService;
        public PersonalListViewModel()
        {
            _apiService = new RestApiService();
            _ = LoadPersonalsAsync();
        }

        [RelayCommand]
        public void Add()
        {
            
            var window = new PersonalFormView();
            window.ShowDialog();
        }


        [RelayCommand]
        public void Edit()
        {
            if (SelectedPersonal != null)
            {
                var vm = new PersonalViewModel(SelectedPersonal);
                var editForm = new PersonalFormView
                {
                    DataContext = vm
                };
                editForm.ShowDialog();
            }
        }

        [RelayCommand]
        public void Close()
        {
            // اگر داخل ContentControl هست، می‌توان CurrentView را null کرد
            // CurrentView = null; در MainViewModel
        }


        private async Task LoadPersonalsAsync()
        {
            var list = await _apiService.GetPersonalsAsync();
            if (list != null)
            {
                foreach (var p in list)
                    Personals.Add(p);
            }
        }
    }
}
