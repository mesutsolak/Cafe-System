using CP.Mobile.MasterDetailPages.Menus;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CP.Mobile.ListContent
{
    public class MainPageModel : BindableObject
    {
        ProductService productService = new ProductService();

        private ContentPage mainPage;

        public MainPageModel(ContentPage mainPage)
        {
            this.mainPage = mainPage;
            AddItems();

        }

        private void AddItems()
        {
            productService.Url = "api/Product/ProductAll";

            var _ListProduct = productService.GetAll();

            foreach (var item in _ListProduct)
            {
                Items.Add(item);
            }
        }

        private ObservableCollection<ProductDTO> _items = new ObservableCollection<ProductDTO>();
        public ObservableCollection<ProductDTO> Items
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
                    var _product = (data as ProductDTO);
                    mainPage.Navigation.PushPopupAsync(new CP.Mobile.ListContent.CartModals.ProductDetails(_product));
                });
            }
        }
    }
}

