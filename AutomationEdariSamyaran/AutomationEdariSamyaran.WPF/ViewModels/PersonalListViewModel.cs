using AutomationEdariSamyaran.WPF.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class PersonalListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Personal> personals = new();

        [ObservableProperty]
        private Personal selectedPersonal;

        public PersonalListViewModel()
        {
            // نمونه داده برای تست
            Personals.Add(new Personal { FullName = "علی رضایی", PersonalCode = "1001", IsActive = true });
            Personals.Add(new Personal { FullName = "سارا موسوی", PersonalCode = "1002", IsActive = true });
        }

        [RelayCommand]
        public void Add()
        {
            // اضافه کردن UserControl فرم جدید در CurrentView
           // var newForm = new PersonalFormView();
            // اگر لازم بود CurrentView = newForm; از MainViewModel استفاده شود
        }

        [RelayCommand]
        public void Edit()
        {
            //if (SelectedPersonal != null)
            //{
            //    // باز کردن فرم و پر کردن اطلاعات SelectedPersonal
            //    var editForm = new PersonalFormView();
            //    var vm = editForm.DataContext as PersonalFormViewModel;
            //    if (vm != null)
            //    {
            //        vm.CurrentPersonal = SelectedPersonal;
            //    }
            //    // CurrentView = editForm; در MainViewModel
            //}
        }

        [RelayCommand]
        public void Close()
        {
            // اگر داخل ContentControl هست، می‌توان CurrentView را null کرد
            // CurrentView = null; در MainViewModel
        }
    }
}
