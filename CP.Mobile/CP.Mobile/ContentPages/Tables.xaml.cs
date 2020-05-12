using CP.Mobile.ListContent;
using CP.Mobile.Tools.AlertModals;
using DLToolkit.Forms.Controls;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tables : ContentPage
    {
        TablePageModal pageModel;
        public Tables()
        {
            InitializeComponent();
            FlowListView.Init();
            pageModel = new TablePageModal(this);
            BindingContext = pageModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           var _btn =  ((Button)sender);
            if (_btn.BackgroundColor == Color.Red)
            {
                await Navigation.PushPopupAsync(new ErrorModal("Masa Alınmış"), true);
            }
            else {
                await this.Navigation.PushPopupAsync(new QuestionModal("Masayı Seçiyormusun ?",_btn.CommandParameter.ToString(), () => { Success(); }));
            }
        }
        private async void Success()
        {
            await this.Navigation.PopPopupAsync(true);
            await this.Navigation.PushPopupAsync(new SuccessModal("Lütfen Bekleyin"), true);
        }
    }
}