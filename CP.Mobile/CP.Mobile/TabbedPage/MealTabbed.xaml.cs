using CP.Mobile.Tools.AlertModals;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.TabbedPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealTabbed : Xamarin.Forms.TabbedPage
    {
        public MealTabbed()
        {

            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            BarBackgroundColor = Color.FromHex("#eeeeee");
            BarTextColor = Color.Black;

        }

    }
}