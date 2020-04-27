using CP.Mobile.Tools;
using CP.ServiceLayer.Firebase;
using Firebase.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage3 : ContentPage
    {
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper("cafe-project-bfd17.appspot.com");

   
    MediaFile file;

        public TestPage3()
        {
            InitializeComponent();

        }

      

        protected async override void OnAppearing()
        {

            base.OnAppearing();

        }

        private async void BtnPick_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null)
                    return;
                imgChoosed.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void BtnUpload_Clicked(object sender, EventArgs e)
        {
            var result = Path.GetFileName(file.Path).Split('.');
            //son .dan sonrası alınmalı
            //await firebaseStorageHelper.UploadFile(file.GetStream(), Guid.NewGuid()+txtFileName.Text+"."+result[result.Length-1]);
        }
     

        private async void BtnDownload_Clicked(object sender, EventArgs e)
        {
            string path = await firebaseStorageHelper.GetFile(txtFileName.Text);
            if (path != null)
            {
                lblPath.Text = path;
                await DisplayAlert("Success", path, "OK");

                FileUpload24.Source = path;

            }
        }
        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            await firebaseStorageHelper.DeleteFile(txtFileName.Text);
            lblPath.Text = string.Empty;
            await DisplayAlert("Success", "Deleted", "OK");
        }
    }
}