using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using System.Windows.Media.Imaging;

namespace PictureMemoryUsageDemo
{
    public partial class SinglePictureView : PhoneApplicationPage
    {
        public SinglePictureView()
        {
            InitializeComponent();
        }

        #region Action
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string url = this.NavigationContext.QueryString["Url"].ToString();
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            this.SinglePic_IM.Source=bitmapImage;
        }
        #endregion
    }
}