using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using AutomationEdariSamyaran.WPF.Views;

namespace AutomationEdariSamyaran.WPF.Common
{
    public static class AppMessage
    {

        public static async void CustomMessage(string resources, string messageType, MyColors colors)
        {

            CustomMessageBox.TxtBorderBrush = TextMessageColore(colors);
            CustomMessageBox.TextMessage = resources;
            CustomMessageBox.lblTextMessage = messageType;
            var window = new CustomMessageBox();
            // Dispatch the UI interaction to the UI thread
            await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
            {
                // Code that interacts with the UI element goes here
                var window = new CustomMessageBox();
                window.ShowDialog();
            });
        }




        public static async Task<bool> QuestionMeesage(string resources)
        {
            bool result = false;
            QuestionMeesageBox.TextMessage = resources;
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                var questionMeesageBox = new QuestionMeesageBox();
                questionMeesageBox.ShowDialog();
                result = QuestionMeesageBox.QuestionResult;
            });

            return result;
        }

        public static System.Windows.Media.SolidColorBrush TextMessageColore(MyColors colors)
        {
            System.Windows.Media.SolidColorBrush TxtMessageBorderBrush;
            switch (colors)
            {
                case MyColors.Red:
                    return new SolidColorBrush(Colors.Red);
                    break;
                case MyColors.LightYellow:
                    return new SolidColorBrush(Colors.Yellow);
                    break;
                case MyColors.GreenYellow:
                    return new SolidColorBrush(Colors.GreenYellow);
                    break;
            }

            return new SolidColorBrush(Colors.Yellow);
        }
    }






}
public enum MyColors
{
    Red,
    LightYellow,
    GreenYellow
}
 
