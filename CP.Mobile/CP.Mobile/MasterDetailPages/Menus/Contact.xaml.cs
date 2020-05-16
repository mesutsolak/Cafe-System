using CP.Mobile.MasterDetailPages.PopupMenu;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contact : ContentPage
    {
        public CartViewModel ViewModel => CartViewModel.Instance;
        public Xam.Plugin.PopupMenu Popup;


        public Contact()
        {
                InitializeComponent();

                Popup = new Xam.Plugin.PopupMenu()
                {
                    BindingContext = ViewModel
                };
                Popup.OnItemSelected += Popup_OnItemSelected;

                Popup.SetBinding(Xam.Plugin.PopupMenu.ItemsSourceProperty, "ListItems");

            Navigation.PopPopupAsync(true);

        }

        private void Popup_OnItemSelected(string item)
        {
            
        }   

        void ShowPopup_Clicked(object sender, EventArgs e)
        {
            Popup?.ShowPopup(sender as View);
        }
    }
}