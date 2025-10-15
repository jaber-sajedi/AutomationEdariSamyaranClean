using AutomationEdariSamyaran.WPF.Models;
using AutomationEdariSamyaran.WPF.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.ViewModels
{
    public partial class AccessTreeViewModel : ObservableObject
    {
        private readonly RestApiService _api;

        [ObservableProperty]
        private ObservableCollection<AccessItem> accessItems = new();

        public AccessTreeViewModel()
        {
            // 🔹 آدرس API را با https و مسیر درست تنظیم کن
            _api = new RestApiService("https://localhost:7132/api/");
           // _ = LoadDataAsync();
        }

        //private async Task LoadDataAsync()
        //{
        //    try
        //    {
        //        AccessItems.Clear();

        //        // 🔹 گرفتن لیست Workflowها
        //        var workflows = await _api.GetAsync<List<WorkflowDto>>("Workflow/list");

        //        if (workflows == null)
        //            return;

        //        foreach (var wf in workflows)
        //        {
        //            var workflowItem = new AccessItem
        //            {
        //                Name = wf.Name ?? "بدون نام",
        //                Id = wf.Id
        //            };

        //            // 🔹 دریافت Stepهای مربوط به هر Workflow
        //            var steps = await _api.GetAsync<List<WorkflowStepDto>>($"WorkflowStep/get-by-workflow/{wf.Id}");

        //            if (steps != null)
        //            {
        //                foreach (var step in steps)
        //                {
        //                    workflowItem.Children.Add(new AccessItem
        //                    {
        //                        Name = step.Name ?? "مرحله بدون نام",
        //                        Id = step.Id
        //                    });
        //                }
        //            }

        //            AccessItems.Add(workflowItem);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"❌ خطا در بارگذاری داده‌ها: {ex.Message}");
        //    }
        //}

        [RelayCommand]
        private void SavePermissions()
        {
            // ✅ در آینده اینجا دسترسی‌های انتخاب‌شده را به API ارسال خواهیم کرد
            System.Diagnostics.Debug.WriteLine("Permissions saved (simulation).");
        }
    }

    // 🔹 مدل‌های ساده برای نگهداری داده‌های Workflow و Step
 
}
