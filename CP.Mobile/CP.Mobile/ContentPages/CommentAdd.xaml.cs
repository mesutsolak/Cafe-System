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

namespace CP.Mobile.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentAdd : PopupPage
    {
        CommentService cs = new CommentService();


        int _productId = 0;
        Action _action;
        public CommentAdd(int ProductId, Action action)
        {
            _productId = ProductId;
            _action = action;
            InitializeComponent();
        }

        private async void btnCommentAdd_Clicked(object sender, EventArgs e)
        {
            cs.Url = "api/Comment/Add";
            string result = cs.Add(new ServiceLayer.DTO.CommentDTO
            {
                UserId = Preferences.Get("UserId", 0),
                ProductId = _productId,
                Description = txtComment.Text
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

        private async void btnCommentClose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }
    }
}