using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class SearchDialogViewModel<T> : ObservableObject
    {
        private readonly Func<string, Task<IEnumerable<T>>> _searchFunc;

        public SearchDialogViewModel(Func<string, Task<IEnumerable<T>>> searchFunc)
        {
            _searchFunc = searchFunc ?? throw new ArgumentNullException(nameof(searchFunc));
        }

        // -------------------------------
        // Properties
        // -------------------------------

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private IEnumerable<T> results;

        [ObservableProperty]
        private T selectedItem;

        // -------------------------------
        // Commands
        // -------------------------------

        [RelayCommand]
        private async Task SearchAsync()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Results = Array.Empty<T>();
                return;
            }

            try
            {
                Results = await _searchFunc(SearchText);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Search failed: {ex.Message}");
            }
        }

        [RelayCommand]
        private void Confirm()
        {
            CloseAction?.Invoke(true);
        }

        [RelayCommand]
        private void Cancel()
        {
            CloseAction?.Invoke(false);
        }

        public Action<bool?>? CloseAction { get; set; }
    }
}
