using CP.Mobile.ListContent;
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
            var _id = ((ImageButton)sender).CommandParameter.ToString();
            await DisplayAlert("Geldi", _id,"close");
        }
    }
}