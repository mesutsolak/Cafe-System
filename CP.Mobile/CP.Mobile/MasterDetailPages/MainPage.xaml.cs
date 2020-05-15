using CP.Mobile.ContentPages;
using CP.Mobile.MasterDetailPages.Menus;
using CP.Mobile.TabbedPage;
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
            try
            {
                InitializeComponent();
                NavigationPage.SetHasNavigationBar(this, false);
                menuList = new List<MasterPageItem>();

                // Adding menu items to menuList and you can define title ,page and icon  
                menuList.Add(new MasterPageItem()
                {
                    Title = "Anasayfa",
                    Icon = "profile.png",
                    TargetType = typeof(Home)
                });
                menuList.Add(new MasterPageItem()
                {
                    Title = "Masalar",
                    Icon = "table.png",
                    TargetType = typeof(Tables)
                });
                menuList.Add(new MasterPageItem()
                {
                    Title = "Yiyecekler",
                    Icon = "eat.png",
                    TargetType = typeof(MealTabbed)
                });
                menuList.Add(new MasterPageItem()
                {
                    Title = "İçecekler",
                    Icon = "drink.png",
                    TargetType = typeof(DrinkTabbed)
                });
                menuList.Add(new MasterPageItem()
                {
                    Title = "Sepet",
                    Icon = "cart.png",
                    TargetType = typeof(Cart)
                });
                menuList.Add(new MasterPageItem()
                {
                    Title = "Siparişlerim",
                    Icon = "order.png",
                    TargetType = typeof(Order)
                });
                menuList.Add(new MasterPageItem()
                {
                    Title = "Müzik Listesi",
                    Icon = "music.png",
                    TargetType = typeof(MusicList)

                });
                menuList.Add(new MasterPageItem()
                {
                    Title = "Hesabım",
                    Icon = "user.png",
                    TargetType = typeof(UserInterface)
                });
                menuList.Add(new MasterPageItem()
                {
                    Title = "Hakkımızda",
                    Icon = "information.png",
                    TargetType = typeof(Information)
                });
                menuList.Add(new MasterPageItem()
                {
                    Title = "İletişim",
                    Icon = "contact.png",
                    TargetType = typeof(Contact)
                });
               
               

                FirstAndLast.Text = Preferences.Get("FirstAndLast", "");


                // Setting our list to be ItemSource for ListView in MainPage.xaml  
                navigationDrawerList.ItemsSource = menuList;
                navigationDrawerList.SelectedItem = menuList[0];

                // Initial navigation, this can be used for our home page  
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));
                IsPresented = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }
        // Event for Menu Item selection, here we are going to handle navigation based  
        // on user selection in menu ListView  
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (MasterPageItem)e.SelectedItem;

            Type page = item.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }

    }
}