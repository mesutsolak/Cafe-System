using CP.Mobile.MasterDetailPages.Menus;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CP.Mobile.ListContent
{
    public class MainPageModel: BindableObject
    {
        private ContentPage mainPage;

        public MainPageModel(ContentPage mainPage)
        {
            this.mainPage = mainPage;
            AddItems();
        }

        private void AddItems()
        {
            for (int i = 0; i < 30; i++)
                Items.Add(new Meal
                {
                    Id = i,
                    Name = "Yiyecek" + i ,
                    Image ="hamburger.jpg",
                    Category ="Kategoriler"+i,
                    Price="$10"+i
                }) ;
        }

        private ObservableCollection<Meal> _items = new ObservableCollection<Meal>();
        public ObservableCollection<Meal> Items
        {
            get
            {
                return _items;
            }
            set
            {
                if (_items != value)
                {
                    _items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        public Command ItemTappedCommand
        {
            get
            {
                return new Command((data) =>
                {
                    var _meals = (data as CP.Mobile.ListContent.Meal);
                    mainPage.Navigation.PushPopupAsync(new CP.Mobile.ListContent.CartModals.ProductDetails(_meals));
                });
            }
        }
    }
}

