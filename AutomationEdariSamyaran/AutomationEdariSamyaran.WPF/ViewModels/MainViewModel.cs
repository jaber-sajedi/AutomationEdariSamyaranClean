using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string selectedAction;

        [ObservableProperty]
        private UserControl currentView;

        public MainViewModel()
        {
            CurrentView = new Views.PersonalListView();
        }
     

        // این متد Command اصلی است
        [RelayCommand]
        public void SelectAction(string action)
        {
            SelectedAction = action;

            switch (action)
            {
                case "New":
                    CurrentView = new Views.PersonalListView();
                    break;

                // برای مثال می‌توان بقیه دکمه‌ها را هم اضافه کرد
                // case "Save":
                //     CurrentView = new Views.SaveView();
                //     break;
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
    }
}
