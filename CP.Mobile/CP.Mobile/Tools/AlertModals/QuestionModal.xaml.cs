using Rg.Plugins.Popup.Extensions;
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
    public partial class QuestionModal : Rg.Plugins.Popup.Pages.PopupPage
    {

        bool _status;

        public QuestionModal(string Title,string Description)
        {
            InitializeComponent();
            lblTitle.Text = Title;
            lblDescription.Text = Description;
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(); 
        }

        private async void btnOk_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}