using System;
using System.Collections.Generic;
using System.Text;

namespace CP.Mobile.MasterDetailPages.PopupMenu
{
    public class TablesViewModel
    {
        #region singleton
        public static TablesViewModel Instance => _instance ?? (_instance = new TablesViewModel());
        static TablesViewModel _instance;
        public TablesViewModel()
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
