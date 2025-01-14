﻿using CP.Entities.Model;
using CP.Mobile.IntermediateModels;
using CP.Mobile.ListContent;
using CP.Mobile.MasterDetailPages.PopupMenu;
using CP.Mobile.MasterDetailPages.PopupMenuContent;
using CP.Mobile.Tools.AlertModals;
using CP.ServiceLayer.Concrete;
using DLToolkit.Forms.Controls;
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
    public partial class Tables : ContentPage
    {
        TableService ts = new TableService();
        TablePageModal pageModel;

        public TablesViewModel ViewModel => TablesViewModel.Instance;
        public Xam.Plugin.PopupMenu Popup;

        public Tables()
        {
            InitializeComponent();
            FlowListView.Init();
            TableLoad();

            Popup = new Xam.Plugin.PopupMenu()
            {
                BindingContext = ViewModel
            };
            Popup.OnItemSelected += Popup_OnItemSelected; ;

            Popup.SetBinding(Xam.Plugin.PopupMenu.ItemsSourceProperty, "ListItems");


            Navigation.PopPopupAsync(true);
        }

        private void TableLoad()
        {
            pageModel = new TablePageModal(this);
            BindingContext = pageModel;
        }

        private void Popup_OnItemSelected(string item)
        {
            switch (item)
            {
                case "Genel Durum":
                    Navigation.PushPopupAsync(new TableGeneral(), true);
                    break;
                case "Bilgiler":
                    Navigation.PushPopupAsync(new TableInformations(), true);
                    break;
                default:
                    break;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var _btn = ((Button)sender);
            if (_btn.BackgroundColor == Color.Red)
            {
                await Navigation.PushPopupAsync(new ErrorModal("Masa Alınmış"), true);
            }
            else if (_btn.BackgroundColor == Color.Orange)
            {
                await Navigation.PushPopupAsync(new ErrorModal("İstek olarak eklenmiş"), true);
            }
            else
            {
                await Navigation.PushPopupAsync(new QuestionModal("Seçme İşlemi", "Masayı Seçiyormusun ?", () => { Success(int.Parse(_btn.CommandParameter.ToString())); }));
            }
        }
        private async void Success(int id)
        {
            await this.Navigation.PopPopupAsync(true);
            ts.Url = "api/Table/IsConfirm/";
            var result = ts.IsConfirm(id, Preferences.Get("UserId",0));

            if (result.Contains("Başarıyla"))
            {
                TableLoad();
                await this.Navigation.PushPopupAsync(new SuccessModal(result), true);
            }
            else
            {
                await this.Navigation.PushPopupAsync(new ErrorModal(result), true);
            }
        }

        private void TablesGeneral_Clicked(object sender, EventArgs e)
        {
            Popup?.ShowPopup(sender as View);
        }

        private async void TblList_Refreshing(object sender, EventArgs e)
        {
            TblList.IsRefreshing = true;

            TableLoad();


            await Task.Delay(1000);

            TblList.IsRefreshing = false;
        }
    }
}