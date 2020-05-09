using Rg.Plugins.Popup.Extensions;
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
    public partial class QuestionModal : Rg.Plugins.Popup.Pages.PopupPage
    {

        bool _status;
        public Action _action;

        public QuestionModal(string Title,string Description,Action action=null)
        {
            InitializeComponent();
            lblTitle.Text = Title;
            lblDescription.Text = Description;
            _action = action;
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }

        private  void btnOk_Clicked(object sender, EventArgs e)
        {
            if (!(_action == null))
            {
                _action.Invoke();
            }
        }
    }
}