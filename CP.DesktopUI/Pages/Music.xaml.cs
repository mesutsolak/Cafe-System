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
    /// Interaction logic for Music.xaml
    /// </summary>
    public partial class Music : UserControl
    {
        public Music()
        {
            InitializeComponent();
            MusicList();
        }

        private void btnMusicConfirm_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Müziği onaylamak istiyor musunuz ?", "Onaylama İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(((sender as PackIcon).Tag));

                int _result = MusicListOperation.MusicApproved(id);

                if (_result > 0)
                {
                    MessageBox.Show("Başarıyla Onaylandı", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Information);
                    MusicList();
                }
                else
                    MessageBox.Show("Onaylama Başarısız", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void btnMusicTrash_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Müziği silmek istiyor musunuz ?", "Silme İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                int id = Convert.ToInt32(((sender as PackIcon).Tag));

                int _result = MusicListOperation.MusicConfirmRemove(id);

                if (_result > 0)
                {
                    MessageBox.Show("Onay Başarıyla Silindi", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Information);
                    MusicList();
                }
                else
                    MessageBox.Show("Onay Silme Başarısız", "Sonuç", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void MusicList()
        {
            MusicView.ItemsSource = MusicListOperation.GetAllWaitMusic();
        }
    }
}
