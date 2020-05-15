using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CP.Mobile.MasterDetailPages.PopupMenu
{
    public class CartViewModel
    {
        #region singleton
        public static CartViewModel Instance => _instance ?? (_instance = new CartViewModel());
        static CartViewModel _instance;
        CartViewModel()
        {
            ListItems.Add("Genel Durum");
            ListItems.Add("Ürünleri Kaldır");
            ListItems.Add("Ürünleri Onayla");
        }
        #endregion

        #region fields
        List<string> _listItems = new List<string>();
        #endregion

        #region properties
        public List<string> ListItems
        {
            get { return _listItems; }
            set { _listItems = value; }
        }
        #endregion
    }
}
