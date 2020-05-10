using CP.Mobile.ContentPages;
using CP.Mobile.MasterDetailPages.Menus;
using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            FlowListView.Init();
            MainPage = new NavigationPage(new SplashPage());
            //MainPage = new Cart();
           

         
        }
        protected override void OnStart()
        {
            base.OnStart();
        }
        protected override void OnSleep()
        {
            base.OnSleep();
        }
        protected override void OnResume()
        {
            base.OnResume();    
        }
    }
}