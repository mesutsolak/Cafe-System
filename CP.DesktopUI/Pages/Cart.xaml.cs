using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CP.DesktopUI.Pages
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : UserControl
    {
        List<User> users = new List<User>();
        public Cart()
        {
            InitializeComponent();
            UserAdd();
            CartView.ItemsSource = users;
        }
        public void UserAdd()
        {
            for (int i = 1; i < 10; i++)
            {
                users.Add(new User
                {
                    Id = i,
                    FirstName = "Name" + i,
                    LastName = "Name" + i
                }); ;
            }
        }
        public class User
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        private void btnCartUpdate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           MessageBox.Show(Convert.ToInt32(((sender as PackIcon).Tag)).ToString());
        }

        private void btnCartTrash_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(Convert.ToInt32(((sender as PackIcon).Tag)).ToString());
        }

        private void CartView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
