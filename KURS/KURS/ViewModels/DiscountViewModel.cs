using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Diagnostics;
using System.Linq;

namespace KURS.ViewModels
{
    class DiscountViewModel: BaseViewModel
    {
        private string loc;
        public string Loc
        {
            get => loc;
            set
            {
                SetProperty(ref loc, value);
                Img = ImageSource.FromFile(value + ".jpg");
            }
        }
        private ImageSource img;
        public ImageSource Img
        {
            get => img;
            set => SetProperty(ref img, value);
        }

        public DiscountViewModel()
        {
            GeoCommand = new Command(GeoCommandExecuted);
        }
        public Command GeoCommand { get; }
        public async void GeoCommandExecuted()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location != null)
                {
                    var placemarks = await Geocoding.GetPlacemarksAsync(location.Latitude, location.Longitude);

                    var placemark = placemarks?.FirstOrDefault();
                    if (placemark != null)
                    {
                        Loc = placemark.Locality;
                        return;
                    }
                }
                await Shell.Current.DisplayAlert("", "Unable to get current Location", "OK");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                Debug.WriteLine(fnsEx.Message);
                await Shell.Current.DisplayAlert("", "Unable to get current Location", "OK");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                Debug.WriteLine(fneEx.Message);
                await Shell.Current.DisplayAlert("", "Unable to get current Location", "OK");
            }
            catch (PermissionException pEx)
            {
                Debug.WriteLine(pEx.Message);
                await Shell.Current.DisplayAlert("", "Unable to get current Location", "OK");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("", "Unable to get current Location", "OK");
            }
        }
    }
}
