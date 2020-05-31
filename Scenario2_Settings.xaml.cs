using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Interfacev2wcs
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class Scenario2_Settings : Page
    {
        string zmienionykolor="";
        public Scenario2_Settings()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }
        private void CC_Click(object sender, RoutedEventArgs e)
        {
            zmienionykolor = "CC";
            SettingsGrid.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);
            Border.Background = new SolidColorBrush(Windows.UI.Colors.Black);
            Kolorystyka.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            Kolorystyka.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            UstApp.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            UstApp.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            DronUst.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            DronUst.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            CC.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            CC.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            SB.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            SB.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            Jasna.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            Jasna.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            Ciemna.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            Ciemna.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            Strona.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            Strona.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            tbust.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            wroc.Foreground = new SolidColorBrush(Windows.UI.Colors.Black);
            wroc.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
            opcje.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
        }
        private void wroc_Click(object sender, RoutedEventArgs e)
        {
             this.Frame.Navigate(typeof(Scenario1_Main),zmienionykolor);
        }

        private void Kolorystyka_Click(object sender, RoutedEventArgs e)
        {
            CC.Visibility = Visibility.Visible;
            SB.Visibility = Visibility.Visible;
            Jasna.Visibility = Visibility.Visible;
            Ciemna.Visibility = Visibility.Visible;
        }


    }
}
