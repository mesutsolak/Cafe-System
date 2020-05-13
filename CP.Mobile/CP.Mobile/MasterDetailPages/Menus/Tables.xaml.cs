using CP.Mobile.ListContent;
using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.Concrete;
using DLToolkit.Forms.Controls;
using Rg.Plugins.Popup.Extensions;
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
    public partial class Tables : ContentPage
    {
        TableService ts = new TableService();
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
            var _btn = ((Button)sender);
            if (_btn.BackgroundColor == Color.Red)
            {
                await Navigation.PushPopupAsync(new ErrorModal("Masa Alınmış"), true);
            }
            else
            {
                await this.Navigation.PushPopupAsync(new QuestionModal("Masayı Seçiyormusun ?", _btn.CommandParameter.ToString(), () => { Success(int.Parse(_btn.CommandParameter.ToString())); }));
            }
        }
        private async void Success(int id)
        {
            await this.Navigation.PopPopupAsync(true);
            ts.Url = "api/Table/IsRequest/";
            //var result = ts.IsUse(id);

            //if (result.Contains("Oluşturuldu"))
            //{
            //    await this.Navigation.PushPopupAsync(new SuccessModal("Masa İsteği Oluşturuldu Lütfen Bekleyin."), true);
            //}
            //else
            //{
            //    await this.Navigation.PushPopupAsync(new ErrorModal(result), true);
            //}
        }
    }
}