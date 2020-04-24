using CP.Mobile.Tools.AlertModals;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CP.Mobile.ListContent
{
    public class TablePageModal:BindableObject
    {
        private ContentPage _mainPage;

        public TablePageModal(ContentPage mainPage)
        {
            this._mainPage = mainPage;
            AddItems();
        }

        private void AddItems()
        {
            for (int i = 0; i < 30; i++)
                Items.Add(new Button { 
                    Text=i.ToString(),
                    TextColor=Color.White,
                    BackgroundColor=Color.Green,
                    FontSize=30,
                    FontAttributes=FontAttributes.Bold
                });
        }

        private ObservableCollection<Button> _items = new ObservableCollection<Button>();
        public ObservableCollection<Button> Items
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
                    var _button = (data as Button);
                    _mainPage.Navigation.PushPopupAsync(new QuestionModal("Masayı Seçiyormusun ?",_button.Text,()=> { Success(); }));
                });
            }
        }
        private async void Success()
        {
           await _mainPage.Navigation.PopPopupAsync(true);
           await _mainPage.Navigation.PushPopupAsync(new SuccessModal("Lütfen Bekleyin"),true);
        }
    }
}
