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
    public partial class MenuTabbed : Xamarin.Forms.TabbedPage
    {
        public MenuTabbed()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            BarBackgroundColor = Color.FromHex("#eeeeee");
            BarTextColor = Color.Black;
        }
     
    }
}