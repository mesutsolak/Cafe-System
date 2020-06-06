using CP.Mobile.ListContent.CartModals;
using CP.Mobile.MasterDetailPages.PopupMenu;
using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicList : ContentPage
    {
        MusicListService ms = new MusicListService();
        List<MusicListDTO> musics = new List<MusicListDTO>();
        public MusicViewModel ViewModel => MusicViewModel.Instance;
        public Xam.Plugin.PopupMenu Popup;
        public MusicList()
        {
            InitializeComponent();

            Popup = new Xam.Plugin.PopupMenu()
            {
                BindingContext = ViewModel
            };
            Popup.OnItemSelected += Popup_OnItemSelected; ;

            Popup.SetBinding(Xam.Plugin.PopupMenu.ItemsSourceProperty, "ListItems");


            MusicListLoad();

            Navigation.PopPopupAsync(true);

        }

        private async void Popup_OnItemSelected(string item)
        {
            switch (item)
            {
                case "Müzikleri Onayla":
                    await Navigation.PushPopupAsync(new QuestionModal("Onalama İşlemi", "Müzikler Onaylansın mı ?", () => { ConfirmAll(); }));
                    break;
                case "Müzik Ekle":
                    await Navigation.PushPopupAsync(new MusicAdd(() => { MusicListLoad(); }), true);
                    break;
                case "Müzikleri Sil":
                    await Navigation.PushPopupAsync(new QuestionModal("Silme İşlemi", "Müzikler Silinsin mi ?", () => { RemoveAll(); }));
                    break;
                default:
                    break;
            }
        }

        public void MusicListLoad()
        {
            ms.Url = "api/MusicList/All";
            musics = ms.GetAll();
            MusicListItems.ItemsSource = musics;
            MusicCount.Text = musics.Count.ToString();
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {

            ms.Url = "api/MusicList/MusicListFind/";
            var dto = ms.GetFind(ButtonId(sender));

            await Navigation.PushPopupAsync(new MusicUpdate(dto, () => { MusicListLoad(); }), true);

        }

        private async void btnRemove_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushPopupAsync(new QuestionModal("Silme İşlemi", "Müzik Silinsinmi", () => { Remove(sender); }));


        }

        private async void btnSuccess_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new QuestionModal("Onaylama İşlemi", "Müzik Onaylansın mı ?", () => { Confirm(sender); }), true);
        }

        public async void Confirm(object sender)
        {
            var _result = ms.IsConfirm(ButtonId(sender));

            await Navigation.PopPopupAsync(true);

            if (_result.Contains("Başarıyla"))
            {
                MusicListLoad();
                await Navigation.PushPopupAsync(new SuccessModal(_result));
            }
            else
            {
                await Navigation.PushPopupAsync(new ErrorModal(_result));
            }
        }

        public async void Remove(object sender)
        {
            ms.Url = "api/MusicList/Remove/";
            var _result = ms.Remove(ButtonId(sender));

            await Navigation.PopPopupAsync(true);

            if (_result.Contains("Başarıyla"))
            {
                MusicListLoad();
                await Navigation.PushPopupAsync(new SuccessModal(_result));
            }
            else
            {
                await Navigation.PushPopupAsync(new ErrorModal(_result));
            }
        }

        public async void RemoveAll()
        {
            ms.Url = "api/MusicList/IsRemoveAll/";
            var _result = ms.GetOperation(UserId());

            await Navigation.PopPopupAsync(true);

            if (_result.Contains("Başarıyla"))
            {
                MusicListLoad();
                await Navigation.PushPopupAsync(new SuccessModal(_result));
            }
            else
            {
                await Navigation.PushPopupAsync(new ErrorModal(_result));
            }

        }

        public async void ConfirmAll()
        {
            ms.Url = "api/MusicList/IsConfirmAll/";
            var _result = ms.GetOperation(UserId());

            await Navigation.PopPopupAsync(true);

            if (_result.Contains("Başarıyla"))
            {
                MusicListLoad();
                await Navigation.PushPopupAsync(new SuccessModal(_result));
            }
            else
            {
                await Navigation.PushPopupAsync(new ErrorModal(_result));
            }
        }

        public int ButtonId(object sender)
        {
            return int.Parse((sender as ImageButton).CommandParameter.ToString());
        }
        public int UserId()
        {
            return Preferences.Get("UserId", 0);
        }

        private void MusicMenu_Clicked(object sender, EventArgs e)
        {
            Popup?.ShowPopup(sender as View);
        }

        private async void MusicListItems_Refreshing(object sender, EventArgs e)
        {
            MusicListItems.IsRefreshing = true;

            MusicListLoad();


            await Task.Delay(1000);

            MusicListItems.IsRefreshing = false;
        }
    }
}