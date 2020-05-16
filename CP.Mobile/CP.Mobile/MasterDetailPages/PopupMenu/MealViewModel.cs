using System;
using System.Collections.Generic;
using System.Text;

namespace CP.Mobile.MasterDetailPages.PopupMenu
{
    public class MealViewModel
    {
        #region singleton
        public static MealViewModel Instance => _instance ?? (_instance = new MealViewModel());
        static MealViewModel _instance;
        MealViewModel()
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
