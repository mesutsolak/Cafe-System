using CP.Mobile.ListContent.CartModals;
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
    public partial class UserInterface : ContentPage
    {
        UserService us = new UserService();
        CartService cs = new CartService();
        MusicListService ms = new MusicListService();

        User user;

        public UserInterface()
        {
            InitializeComponent();

            UserList();

            HistoryCartList();
            HistoryMusicList();

            Navigation.PopPopupAsync(true);
        }

        private void UserList()
        {
            us.Url = "api/User/Find/";
            var _user = us.GetFind(UserId());

            user = _user;

            FirstName.Text = _user.FirstName;
            LastName.Text = _user.LastName;
            Email.Text = _user.Email;
            UserName.Text = _user.Username;
            Password.Text = _user.Password;
            ProfilPhoto.Source = _user.ProfilPhoto;
            Gender.Text = _user.GenderId == 1 ? "Erkek" : "Kadın";
            BackPhoto.Source = _user.BackGround;
        }

        private async void btnUserInformationUpdate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new UserUpdate(user, () => { UserList(); }), true);
        }
        public int UserId()
        {
            return Preferences.Get("UserId", 0);
        }

        public void HistoryMusicList()
        {
            ms.Url = "api/MusicList/History/";
            MusicHistory.ItemsSource = ms.GetAllFilter(UserId());
        }
        public void HistoryCartList()
        {
            cs.Url = "api/Cart/History/";
            CartHistory.ItemsSource = cs.GetAllFilter(UserId());
        }
    }
}