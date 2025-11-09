using AutomationEdariSamyaran.WPF.Services;
using AutomationEdariSamyaran.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutomationEdariSamyaran.WPF.Views.Workflow
{
    /// <summary>
    /// Interaction logic for RollUCView.xaml
    /// </summary>
    public partial class RollUcView : UserControl
    {

        public RollUcView(RestApiService apiService)
        {
            InitializeComponent();
            DataContext = new RollUcViewModel(new RestApiService());
        }
    }
}
