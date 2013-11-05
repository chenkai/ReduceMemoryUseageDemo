using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;
using PictureMemoryUsageDemo.EntityModels;

namespace PictureMemoryUsageDemo.ViewModels
{
    public class TripPictureViewModel:INotifyPropertyChanged
    {
        #region Property
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<TripPictureInfo> _tripPictureCol = new ObservableCollection<TripPictureInfo>();
        public ObservableCollection<TripPictureInfo> TripPictureCol
        {
            get { return _tripPictureCol; }
            set
            {
                _tripPictureCol = value;
                BindProertyChangedEventHandler("TripPictureCol");
            }
        }
        #endregion

        public TripPictureViewModel()
        {
            LoadTripAddressPictureData();
        }

        #region Action

        public void BindProertyChangedEventHandler(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return;

            PropertyChangedEventHandler eventHandler = this.PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LoadTripAddressPictureData()
        {
            string pictureHealderStr = "/Images/670(";
            string pictureFooterStr = ").jpg";
            for (int count = 0; count < 20; count++)
                _tripPictureCol.Add(new TripPictureInfo() {  CityName="乌克兰", StatusCode=(count+1).ToString(), TripPictureUrl=pictureHealderStr+(count+1).ToString()+pictureFooterStr});
        }
        #endregion

    }
}
