using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KURS.Models;
namespace KURS
{
    public partial class App : Application
    {
        public static User User { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
