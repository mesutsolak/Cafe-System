using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.Tools.AlertModals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoaderModal : PopupPage
    {
        public LoaderModal()
        {
            InitializeComponent();
        }
      
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }

    }
}