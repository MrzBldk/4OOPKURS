using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using KURS.ViewModels;

namespace KURS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TechSupportPage : ContentPage
    {
        public TechSupportPage()
        {
            BindingContext = new TechSupportViewModel();
            InitializeComponent();
        }
    }
}