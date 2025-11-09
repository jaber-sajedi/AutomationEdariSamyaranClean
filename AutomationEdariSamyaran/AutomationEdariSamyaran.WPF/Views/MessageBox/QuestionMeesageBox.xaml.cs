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
using System.Windows.Shapes;

namespace AutomationEdariSamyaran.WPF.Views
{
    /// <summary>
    /// Interaction logic for QuestionMeesageBox.xaml
    /// </summary>
    public partial class QuestionMeesageBox : Window
    {
        public static string? TextMessage;
        public static bool QuestionResult;
        public QuestionMeesageBox()
        {
            InitializeComponent();
        }

        private void QuestionMeesageBox_OnLoaded(object sender, RoutedEventArgs e)
        {
            txtMessage.Text = TextMessage;
            
        }


        private void TxtOk_OnClick(object sender, RoutedEventArgs e)
        {
            QuestionResult = true;
            this.Close();
        }

        private void TxtCancel_OnClick(object sender, RoutedEventArgs e)
        {
            QuestionResult = false;
            this.Close();
        }

        private void QuestionMeesageBox_OnClosed(object? sender, EventArgs e)
        {
            QuestionResult = false;
            this.Close();
        }
    }
}
