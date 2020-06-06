using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CP.ServiceLayer.Concrete;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using CP.Mobile.Tools.AlertModals;
using CP.Mobile.ValidatorEntities;
using CP.Mobile.Tools;

namespace CP.Mobile.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentAdd : PopupPage
    {

        CommentViewModel CWM = new CommentViewModel();
        CommentService cs = new CommentService();


        int _productId = 0;
        Action _action;
        public CommentAdd(int ProductId, Action action)
        {
            BindingContext = CWM;
            _productId = ProductId;
            _action = action;
            InitializeComponent();
        }

        private async void btnCommentAdd_Clicked(object sender, EventArgs e)
        {
            if (CWM.ModelResult())
            {
                await Navigation.PushPopupAsync(new LoaderModal());

                cs.Url = "api/Comment/Add";
                string result = cs.Add(new ServiceLayer.DTO.CommentDTO
                {
                    UserId = Preferences.Get("UserId", 0),
                    ProductId = _productId,
                    Description = txtComment.EntryText
                });

                await Navigation.PopAllPopupAsync(true);

                if (result.Contains("Başarıyla"))
                {
                    _action.Invoke();
                    await Navigation.PushPopupAsync(new SuccessModal(result));
                }
                else
                {
                    await Navigation.PushPopupAsync(new ErrorModal(result));
                }
            }
            else
            {
                await Navigation.PushPopupAsync(new ErrorModal("Lütfen eksiksiz doldurun"), true);
            }

        }

        private async void btnCommentClose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }

        private async void ClosePassword_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }

        private void btnCommentClear_Clicked(object sender, EventArgs e)
        {
            FormTools.FormClear(CommentStl);
            CWM.ErrorClear();
        }
    }
}