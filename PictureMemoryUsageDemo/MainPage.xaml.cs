using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PictureMemoryUsageDemo.Resources;

using PictureMemoryUsageDemo.ViewModels;
using PictureMemoryUsageDemo.EntityModels;
using PictureMemoryUsageDemo.Common;
using Microsoft.Phone.Info;

namespace PictureMemoryUsageDemo
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Property
        TripPictureViewModel _tripPicViewModel = null;
        #endregion

        public MainPage()
        {
            LogRecordHelper.AddLogRecord("MainPage Init Before:",  DeviceStatus.ApplicationCurrentMemoryUsage.ToString()+" KB");
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            LogRecordHelper.AddLogRecord("MainPage Init After:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " KB");
        }

        #region Action
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LogRecordHelper.AddLogRecord("MainPage Load Before:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " KB");
            if (_tripPicViewModel == null)
                _tripPicViewModel = new TripPictureViewModel();
            this.DataContext = _tripPicViewModel;
            LogRecordHelper.AddLogRecord("MainPage Load After:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " KB");
        }

        private void ControlMemory_LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                TripPictureInfo tripPicInfo = this.ControlMemory_LB.SelectedItem as TripPictureInfo;
                if (tripPicInfo == null)
                    return;

                this.ControlMemory_LB.SelectedIndex = -1;
                this.NavigationService.Navigate(new Uri("/SinglePictureView.xaml?Url="+tripPicInfo.TripPictureUrl,UriKind.RelativeOrAbsolute));
            }
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/MemoryLogView.xaml",UriKind.RelativeOrAbsolute));
        }

        private void AddPictureRecord_AP_Click(object sender, EventArgs e)
        {
            if (_tripPicViewModel != null)
                _tripPicViewModel.LoadTripAddressPictureData();
        }
        #endregion

        #region Control Memory Useage

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
 
            }          
        }

        private void ClearImageCache()
        {
 
        }

        private void ClearRegisterEvent()
        {
            this.ControlMemory_LB.SelectionChanged -= ControlMemory_LB_SelectionChanged;
        }

        ~MainPage()
        {
            LogRecordHelper.AddLogRecord("MainPage Destructor Excuted:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " KB");
        }
        #endregion

     

     



    }
}