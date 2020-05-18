using CP.ServiceLayer.Concrete;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Information : ContentPage
    {
        CompanyService cs = new CompanyService();
        public Information()
        {
            InitializeComponent();

            cs.Url = "api/Company/Get";

            var CompanyDTO = cs.GetFind();

            Header1.Text = CompanyDTO.Header1;
            //Header2.Text = CompanyDTO.Header2;
            Description1.Text = CompanyDTO.Description1;
            //Description2.Text = CompanyDTO.Description2;

            Navigation.PopPopupAsync(true);

        }
    }
}