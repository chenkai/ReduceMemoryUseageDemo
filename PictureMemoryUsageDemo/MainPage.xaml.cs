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
            LogRecordHelper.AddLogRecord("MainPage Init Before:",  DeviceStatus.ApplicationCurrentMemoryUsage.ToString()+" B");
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
            LogRecordHelper.AddLogRecord("MainPage Init After:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " B");
        }

        #region Action
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            LogRecordHelper.AddLogRecord("MainPage Load Before:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " B");
            if (_tripPicViewModel == null)
                _tripPicViewModel = new TripPictureViewModel();
            this.DataContext = _tripPicViewModel;
            LogRecordHelper.AddLogRecord("MainPage Load After:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " B");
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
            LogRecordHelper.AddLogRecord("Clear Before:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " B");
            if (e.NavigationMode == NavigationMode.Back)
            {
                ClearImageCache();
                _tripPicViewModel.TripPictureCol.Clear();
            }
            LogRecordHelper.AddLogRecord("Clear After:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " B");
        }

        protected override void OnRemovedFromJournal(JournalEntryRemovedEventArgs e)
        {
            ClearRegisterUIElementEvent();
            this.DataContext = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            base.OnRemovedFromJournal(e);
        }

        private void ClearImageCache()
        {
            if (_tripPicViewModel.TripPictureCol.Count > 0)
            {
                foreach(TripPictureInfo queryInfo in _tripPicViewModel.TripPictureCol)
                    queryInfo.TirpPictureSource.UriSource=null;
            }
        }

        private void ClearRegisterUIElementEvent()
        {
            this.ControlMemory_LB.SelectionChanged -= ControlMemory_LB_SelectionChanged;
        }

        private void ClearRegisterEvent()
        {
            this.ControlMemory_LB.SelectionChanged -= ControlMemory_LB_SelectionChanged;
        }

        ~MainPage()
        {
            LogRecordHelper.AddLogRecord("MainPage Destructor Excuted:", DeviceStatus.ApplicationCurrentMemoryUsage.ToString() + " B");
        }
        #endregion   
    }
}