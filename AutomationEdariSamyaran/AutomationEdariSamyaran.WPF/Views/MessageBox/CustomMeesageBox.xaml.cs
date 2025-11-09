using System;
using System.Collections.Generic;
using System.Drawing;
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
using Color = System.Windows.Media.Color;

namespace AutomationEdariSamyaran.WPF.Views
{
    /// <summary>
    /// Interaction logic for CustomMeesageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public static string TextMessage;
        public static string lblTextMessage;
        public static SolidColorBrush TxtBorderBrush;
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        private void CustomMeesageBox_OnLoaded(object sender, RoutedEventArgs e)
        {

            
                TxtMessage.Text = TextMessage;
                lblMessage.Content = lblTextMessage;
                TxtMessage.BorderBrush = TxtBorderBrush;
           

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
