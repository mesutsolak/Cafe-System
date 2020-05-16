using System;
using System.Collections.Generic;
using System.Text;

namespace CP.Mobile.MasterDetailPages.PopupMenu
{
    public class DrinkViewModel
    {
        #region singleton
        public static DrinkViewModel Instance => _instance ?? (_instance = new DrinkViewModel());
        static DrinkViewModel _instance;
        DrinkViewModel()
        {
            ListItems.Add("Genel Durum");
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
