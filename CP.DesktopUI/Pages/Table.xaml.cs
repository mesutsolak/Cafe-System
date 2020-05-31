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

namespace CP.DesktopUI.Pages
{
    /// <summary>
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table : UserControl
    {
        public Table()
        {
            InitializeComponent();
            GetTables();
        }

        private void btnTrashRemove_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Masayı silmek istiyor musunuz ?", "Silme İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(((sender as PackIcon).Tag));

                int _result = TableOperation.TableConfirmRemove(id);

                if (_result > 0)
                {
                    MessageBox.Show("Onay Başarıyla Silindi", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetTables();
                }
                else
                    MessageBox.Show("Onay Silme Başarısız", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnConfirmTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
         

            MessageBoxResult messageBoxResult = MessageBox.Show("Masayı onaylamak istiyor musunuz ?", "Onaylama İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(((sender as PackIcon).Tag));

                int _result = TableOperation.TableApproved(id);

                if (_result > 0)
                {
                    MessageBox.Show("Başarıyla Onaylandı", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Information);
                    GetTables();
                }
                else
                    MessageBox.Show("Onaylama Başarısız", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
        public void GetTables()
        {
            TableView.ItemsSource = TableOperation.GetAllWaitTable();
        }

        private void btnTableRefresh_Click(object sender, RoutedEventArgs e)
        {
            GetTables();
        }
    }
}
