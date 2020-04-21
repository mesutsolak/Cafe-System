using CP.Mobile.ListContent;
using DLToolkit.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.Menus
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
    }
}