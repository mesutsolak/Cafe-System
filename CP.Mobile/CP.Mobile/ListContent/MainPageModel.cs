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
            for (int i = 0; i < 20; i++)
                Items.Add(string.Format("List Item at {0}", i));
        }

        private ObservableCollection<string> _items = new ObservableCollection<string>();
        public ObservableCollection<string> Items
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
                    mainPage.DisplayAlert("FlowListView", data + "", "Ok");
                });
            }
        }
    }
}

