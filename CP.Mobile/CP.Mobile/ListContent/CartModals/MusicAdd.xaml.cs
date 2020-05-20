using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.ListContent.CartModals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicAdd : PopupPage
    {
        MusicListService musicList = new MusicListService();
        Action _action;
        public MusicAdd(Action action)
        {
            _action = action;
            InitializeComponent();
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            musicList.Url = "api/MusicList/Add";
            var result = musicList.Add(new MusicListDTO
            {
                MusicName = EntMusicName.Text,
                UserId = Preferences.Get("UserId",0),
                ArtistName = EntArtistName.Text,
                ConfirmId = 2,
                IsComplete = false
            });

            await Navigation.PopPopupAsync(true);

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
    }
}