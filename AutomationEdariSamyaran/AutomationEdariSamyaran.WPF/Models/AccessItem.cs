using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationEdariSamyaran.WPF.Models
{
    public class AccessItem
    {
        public int Id { get; set; }  // ✅ اضافه شد

        public string Name { get; set; } = string.Empty;

        public ObservableCollection<AccessItem> Children { get; set; } = new();

        public bool IsChecked { get; set; } // برای دسترسی‌ها (در آینده مفید است)
    }
}