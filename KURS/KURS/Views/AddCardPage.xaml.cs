using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

using KURS.Models;
using KURS.ViewModels;

namespace KURS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCardPage : ContentPage
    {
        public Card Card { get; set; }

        public AddCardPage()
        {
            InitializeComponent();
            BindingContext = new AddCardViewModel();
        }
        public void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                NumbLabel.Text = result.Text;
            });
        }
    }
}