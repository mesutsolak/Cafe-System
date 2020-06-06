using System;
using System.Collections.Generic;
using System.Text;

namespace CP.Mobile.MasterDetailPages.PopupMenu
{

    public class OrderViewModel
    {
        public static OrderViewModel Instance => _instance ?? (_instance = new OrderViewModel());
        static OrderViewModel _instance;
        public OrderViewModel()
        {
            ListItems.Add("Genel Durum");
        }
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
