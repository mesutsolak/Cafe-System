using CP.DesktopUI.Pages;
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
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            FirstLast.Text = "Hoşgeldin " + Application.Current.Properties["Name"] as string;
            MenuListView.SelectedIndex = 0;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Hesabınızdan çıkmak istiyor musunuz ?", "Çıkış İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                LoginScreen login = new LoginScreen();
                login.Show();
                this.Close();
                //Application.Current.Shutdown();
            }
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {

            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
        public void PageOpen(string PageName)
        {
            UIElement uIElement = new UIElement();
            switch (PageName)
            {
                case "Music":
                    uIElement = new Music();
                    break;
                case "Table":
                    uIElement = new Pages.Table();
                    break;
                case "Cart":
                    uIElement = new Cart();
                    break;
                case "Home":
                    uIElement = new Home();
                    break;
                default:
                    break;
            }
            StpGrid.Children.Clear();
            StpGrid.Children.Add(uIElement);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PageOpen((e.AddedItems[0] as ListViewItem).Name);
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Uygulamadan çıkmak istiyor musunuz ?", "Çıkış İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }
    }
}
