using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace KURS.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        private bool _useDarkMode;
        public bool UseDarkMode
        {
            get
            {
                return _useDarkMode;
            }
            set
            {
                SetProperty(ref _useDarkMode, value);
                if (_useDarkMode)
                {
                    UseLightMode = UseDeviceThemeSettings = false;
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                }

            }
        }

        private bool _useLightMode;
        public bool UseLightMode
        {
            get
            {
                return _useLightMode;
            }
            set
            {
                SetProperty(ref _useLightMode, value);
                if (_useLightMode)
                {
                    UseDarkMode = UseDeviceThemeSettings = false;
                    Application.Current.UserAppTheme = OSAppTheme.Light;
                }
            }
        }

        private bool _useDeviceThemeSettings = true;
        public bool UseDeviceThemeSettings
        {
            get
            {
                return _useDeviceThemeSettings;
            }
            set
            {
                SetProperty(ref _useDeviceThemeSettings, value);
                if (_useDeviceThemeSettings)
                {
                    Application.Current.UserAppTheme = OSAppTheme.Unspecified;
                }
            }
        }
    }
}
