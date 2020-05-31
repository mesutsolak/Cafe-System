using CP.BusinessLayer.Operations;
using CP.ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CP.DesktopUI
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var _result = await UserOperations.Login(new LoginControl
            {
                UserName = txtUserName.Text,
                Password = txtPassword.Password
            });

            MessageBox.Show(_result.Split(',')[0], "Sonuç", MessageBoxButton.OK, MessageBoxImage.Information);
            if (_result.StartsWith("Başarıyla"))
            {
                Application.Current.Properties["UserName"] = txtUserName.Text;
                Application.Current.Properties["Name"] = UserOperations.UserFirstAndLast(txtUserName.Text);
                Main main = new Main();
                main.Show();
                this.Close();
            }
        }
    }
}
