using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using System.Net.NetworkInformation;
using Windows.ApplicationModel.ExtendedExecution;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;




//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Interfacev2wcs
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class Scenario1_Main : Page
    {
        double Lat,Lon;
        string kolorystyka;
        [Windows.Foundation.Metadata.ContractVersion(typeof(Windows.Foundation.UniversalApiContract), 65536)]
        [Windows.Foundation.Metadata.WebHostHidden]
        [Windows.Foundation.Metadata.ContractVersion(typeof(Windows.Foundation.UniversalApiContract), 65536)]
        [Windows.Foundation.Metadata.DualApiPartition(version = 167772160)]
        [Windows.Foundation.Metadata.MarshalingBehavior(Windows.Foundation.Metadata.MarshalingType.Agile)]
        [Windows.Foundation.Metadata.Muse(Version = 100859904)]
        [Windows.Foundation.Metadata.Threading(Windows.Foundation.Metadata.ThreadingModel.Both)]
        [Windows.Foundation.Metadata.Activatable(65536, "Windows.Foundation.UniversalApiContract")]

        public sealed class ContractVersionAttribute : Attribute { }

        public LandmarksViewModel ViewModel { get; set; }
        public Scenario1_Main()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            SetLandMarkLocations();

            this.ViewModel = new LandmarksViewModel();
        }

        bool net = NetworkInterface.GetIsNetworkAvailable();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
             kolorystyka = e.Parameter.ToString();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (net == true)
            {
                polaczenie.Text = "Jest";
            }
            else
            {
                polaczenie.Text = "Nie ma";
            }

          if (kolorystyka == "CC")
          {
              MainGrid.Background = new SolidColorBrush(Windows.UI.Colors.Black);
              Ustawienia.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
              wroc.Background = new SolidColorBrush(Windows.UI.Colors.DarkRed);
              Czastb.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
              Time.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
              Bateria.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);
              Bateriatb.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
              polaczenie.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
              Polaczenie_tb.Foreground =  new SolidColorBrush(Windows.UI.Colors.DarkRed);
              Border_Pogoda.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);
              skad_tb.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
              dokad_tb.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
              skad.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);
              skad_tb.Foreground = new SolidColorBrush(Windows.UI.Colors.DarkRed);
              dokad.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);
            }

        }

        private void Ustawienia_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Scenario2_Settings));
        }

        public async void AddSpaceNeedleIcon()
        {
            var access = await Geolocator.RequestAccessAsync();

            var MyLandmarks = new List<MapElement>();


            BasicGeoposition snPosition = new BasicGeoposition { Latitude = Lat, Longitude = Lon };
            Geopoint snPoint = new Geopoint(snPosition);

            var spaceNeedleIcon = new MapIcon
            {
                Location = snPoint,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Title = "Twój dron"
            };
            spaceNeedleIcon.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/indeks123.jpg"));
            spaceNeedleIcon.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;
            //MyLandmarks.Add(spaceNeedleIcon);

            var LandmarksLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = MyLandmarks
            };

           // myMap.Layers.Add(LandmarksLayer);

        }

        private void myMap_Loaded(object sender, RoutedEventArgs e)
        {
            BasicGeoposition snPosition = new BasicGeoposition { Latitude = Lat, Longitude = Lon };
            Geopoint snPoint = new Geopoint(snPosition);


            myMap.Center = snPoint;
            myMap.ZoomLevel = 16;

        }

        public IList<MapElement> LandmarkOverlays { get; set; }


           private void SetLandMarkLocations()
                 {
            LandmarkOverlays = new List<MapElement>();

            var SeattleSpaceNeedleIcon = new MapIcon
            {
                Location = new Geopoint(new BasicGeoposition
                { Latitude = Lat, Longitude = Lon }),
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/indeks123.jpg")),
                ZIndex = 0,
                Title = "Twój dron"
            };

            LandmarkOverlays.Add(SeattleSpaceNeedleIcon);
        }
    

         public class LandmarksViewModel
         {
           

            public LandmarksViewModel()
            {
                var MyElements = new List<MapElement>();

                var LandmarksLayer = new MapElementsLayer
                {
                    ZIndex = 1,
                    MapElements = MyElements
                };

            }
           
        }

        private void wroc_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


    }
}
