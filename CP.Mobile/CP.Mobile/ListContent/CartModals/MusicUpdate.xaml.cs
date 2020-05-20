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
    public partial class MusicUpdate : PopupPage
    {
        MusicListService ms = new MusicListService();
        public MusicListDTO musicList;
        Action _action;
        public MusicUpdate(MusicListDTO musicListDTO, Action action)
        {

            InitializeComponent();
            musicList = musicListDTO;
            BindingContext = musicListDTO;
            _action = action;
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            ms.Url = "api/MusicList/Put";
            string _result = ms.Update(new MusicListDTO
            {
                Id = musicList.Id,
                ArtistName = EntArtistNames.Text,
                UserId = Preferences.Get("UserId", 0),
                MusicName = EntMusicNames.Text,
                ConfirmId = musicList.ConfirmId,
                IsComplete = musicList.IsComplete
            }); ; ;

            await Navigation.PopPopupAsync(true);


            if (_result.Contains("Başarıyla"))
            {
                _action.Invoke();
                await Navigation.PushPopupAsync(new SuccessModal(_result));
            }
            else
            {
                await Navigation.PushPopupAsync(new ErrorModal(_result));
            }
        }

        private async void btnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }
    }
}