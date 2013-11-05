using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using PictureMemoryUsageDemo.Common;

namespace PictureMemoryUsageDemo.Views
{
    public partial class MemoryLogView : PhoneApplicationPage
    {
        public MemoryLogView()
        {
            InitializeComponent();
            this.Loaded += MemoryLogView_Loaded;
        }

        void MemoryLogView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LogRecord_LB.ItemsSource = LogRecordHelper._allLogRecordInfo;
        }
    }
}