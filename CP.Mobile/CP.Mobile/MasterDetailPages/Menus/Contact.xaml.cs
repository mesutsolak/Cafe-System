using CP.Mobile.MasterDetailPages.PopupMenu;
using CP.ServiceLayer.Concrete;
using CP.ServiceLayer.DTO;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Plugin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.MasterDetailPages.Menus
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Contact : ContentPage
    {
        ContactService cs = new ContactService();

        ContactDTO contact;

        public Contact()
        {
            InitializeComponent();

            cs.Url = "api/Contact/Get";
            contact = cs.GetFind();

            Description.Text = contact.Description;
            lblPhone.Text = contact.Phone;
            lblEmail.Text = contact.Email;
            lblFax.Text = contact.Fax;
            lblAdress.Text = contact.Address;
            lblTwitter.Text = contact.Twitter;
            lblFacebook.Text = contact.Facebook;



            Navigation.PopPopupAsync(true);

        }
    }
}