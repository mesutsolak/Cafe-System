using System;
using System.Collections.Generic;
using System.Text;

namespace CP.Mobile.MasterDetailPages.PopupMenu
{
    public class MusicViewModel
    {
        #region singleton
        public static MusicViewModel Instance => _instance ?? (_instance = new MusicViewModel());
        static MusicViewModel _instance;
        MusicViewModel()
        {
            ListItems.Add("Müzik Ekle");
            ListItems.Add("Müzikleri Sil");
            ListItems.Add("Müzikleri Onayla");
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
