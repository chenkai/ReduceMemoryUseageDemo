using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace PictureMemoryUsageDemo.Views
{
    public partial class StartPage : PhoneApplicationPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void StartToTrip_BT_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void LogRecord_AP_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/MemoryLogView.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}