using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.PopupMenuContent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableGeneral : PopupPage
    {
        List<TableDTO> _tables = new List<TableDTO>();
        TableService ts = new TableService();
        public TableGeneral()
        {
            InitializeComponent();
            TableAll();
            TableEmpty();
            TableWait();
            TableFill();

        }

        private async void btnClose_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync(true);
        }
        public void TableAll()
        {
            ts.Url = "api/Table/GetAll";
            _tables = ts.GetAll();
            TableCount.Text = _tables.Count.ToString();
        }
        public void TableEmpty()
        {
            EmptyTable.Text = _tables.Where(x => x.ConfirmId == 2).ToList().Count.ToString();
        }
        public void TableWait()
        {
            WaitTable.Text = _tables.Where(x => x.ConfirmId == 3).ToList().Count.ToString();
        }
        public void TableFill()
        {
            FullTable.Text = _tables.Where(x => x.ConfirmId == 1).ToList().Count().ToString();
        }
    }
}