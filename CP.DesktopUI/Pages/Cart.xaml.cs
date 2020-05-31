using CP.BusinessLayer.Operations;
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
using M = CP.Entities.Model;

namespace CP.DesktopUI.Pages
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : UserControl
    {
        public Cart()
        {
            InitializeComponent();
            GetCarts();
        }


        private void btnCartUpdate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Siparişi onaylamak istiyor musunuz ?", "Onaylama İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(((sender as PackIcon).Tag));

                int _result = CartOperation.CartApproved(id);

                if (_result > 0)
                {
                    MessageBox.Show("Başarıyla Onaylandı", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetCarts();
                }
                else
                    MessageBox.Show("Onaylama Başarısız", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnCartTrash_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Siparişi silmek istiyor musunuz ?", "Silme İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(((sender as PackIcon).Tag));

                int _result = CartOperation.CartConfirmRemove(id);

                if (_result > 0)
                {
                    MessageBox.Show("Onay Başarıyla Silindi", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetCarts();
                }
                else
                    MessageBox.Show("Onay Silme Başarısız", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CartView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void GetCarts()
        {
            CartView.ItemsSource = CartOperation.GetAllWaitCart();
        }

        private void btnOrderRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetCarts();
        }
    }
}
