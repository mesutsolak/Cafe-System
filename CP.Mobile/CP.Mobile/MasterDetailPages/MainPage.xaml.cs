using CP.Mobile.MasterDetailPages.Menus;
using CP.Mobile.Tools.AlertModals;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            menuList = new List<MasterPageItem>();

            // Adding menu items to menuList and you can define title ,page and icon  
            menuList.Add(new MasterPageItem()
            {
                Title = "Anasayfa",
                Icon = "profile.png",
                TargetType = typeof(TestPage1)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Yiyecekler",
                Icon = "eat.png",
                TargetType = typeof(Meals)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "İçecekler",
                Icon = "drink.png",
                TargetType = typeof(TestPage1)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Sepet",
                Icon = "cart.png",
                TargetType = typeof(TestPage3)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Siparişlerim",
                Icon = "order.png",
                TargetType = typeof(TestPage3)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Hakkımızda",
                Icon = "information.png",
                TargetType = typeof(TestPage2)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "İletişim",
                Icon = "contact.png",
                TargetType = typeof(TestPage3)
            });
            menuList.Add(new MasterPageItem()
            {
                Title = "Sipariş Geçmişim",
                Icon = "clock.png",
                TargetType = typeof(TestPage3)
            });

            

            // Setting our list to be ItemSource for ListView in MainPage.xaml  
            navigationDrawerList.ItemsSource = menuList;
            navigationDrawerList.SelectedItem = menuList[0];

            // Initial navigation, this can be used for our home page  
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(TestPage1)));
            IsPresented = false;

        }
        // Event for Menu Item selection, here we are going to handle navigation based  
        // on user selection in menu ListView  
        private async void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;
           
                Type page = item.TargetType;
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
  
        }
       
    }
}