using CP.Mobile.IntermediateModels;
using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.Concrete;
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
        TableService tableService = new TableService();
        public Color _Color;
        private ContentPage _mainPage;

        public TablePageModal(ContentPage mainPage)
        {
            this._mainPage = mainPage;
            AddItems();
        }

        private void AddItems()
        {

            tableService.Url = "api/Table/GetAll/";
            var _ts = tableService.GetAll();

            foreach (var tableDTO in _ts)
            {
                switch (tableDTO.ConfirmId)
                {
                    case 1:
                        _Color = Color.Green;
                        break;
                    case 2:
                        _Color = Color.Red;
                        break;
                    case 3:
                        _Color = Color.Orange;
                        break;
                    default:
                        break;
                }
                Items.Add(new TableModel
                {
                    Id = tableDTO.Id,
                    Color = _Color,
                    Number = tableDTO.Number.Value
                });
            }

        }

        private ObservableCollection<TableModel> _items = new ObservableCollection<TableModel>();
        public ObservableCollection<TableModel> Items
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
