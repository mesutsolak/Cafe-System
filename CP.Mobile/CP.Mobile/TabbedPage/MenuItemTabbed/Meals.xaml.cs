using CP.Mobile.ListContent;
using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.TabbedPage.MenuItemTabbed
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Meals : ContentPage
    {
        ProductService productService = new ProductService();

        MainPageModel pageModel;
        public Meals()
        {
            InitializeComponent();
            FlowListView.Init();
            pageModel = new MainPageModel(this);
            BindingContext = pageModel;
        }

        private async void btnCart_Clicked(object sender, EventArgs e)
        {
            try                        
            {
                var _id = ((ImageButton)sender).CommandParameter.ToString();
            productService.Url = "api/Product/";
                ProductDTO p = productService.GetFind(int.Parse(_id));
                //new QuestionModal()
                await DisplayAlert(p.Name,p.ProductDetail,"kapat");
            }
            catch (Exception ex)
            {

                throw;
            }
           

        }
    }
}