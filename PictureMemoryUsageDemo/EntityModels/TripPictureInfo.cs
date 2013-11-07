using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Imaging;

namespace PictureMemoryUsageDemo.EntityModels
{
    public class TripPictureInfo
    {
        public string CityName { get; set; }
        public string StatusCode { get; set; }
        public string TripPictureUrl { get; set; }

        private BitmapImage _tirpPictureSource = new BitmapImage() { CreateOptions = BitmapCreateOptions.BackgroundCreation 
                                                                                    | BitmapCreateOptions.IgnoreImageCache 
                                                                                    | BitmapCreateOptions.DelayCreation };
        public BitmapImage TirpPictureSource
        {
            get 
            {
                _tirpPictureSource.UriSource = new Uri(TripPictureUrl,UriKind.RelativeOrAbsolute);
                return _tirpPictureSource;
            }
        }
    }
}
