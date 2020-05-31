using CP.BusinessLayer.Operations;
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
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {

        public Home()
        {
            InitializeComponent();
            Consumo consumo = new Consumo();
            DataContext = new ConsumoViewModel(consumo);
            txtCartCount.Text = CartOperation.GetAllWaitCart().Count.ToString();
            txtMusicCount.Text = MusicListOperation.GetAllWaitMusic().Count.ToString();
            txtTableCount.Text = TableOperation.GetAllWaitTable().Count.ToString();
        }
        internal class ConsumoViewModel
        {
            public List<Consumo> Consumo { get; private set; }

            public ConsumoViewModel(Consumo consumo)
            {
                Consumo = new List<Consumo>();
                Consumo.Add(consumo);
            }
        }

        internal class Consumo
        {
            public string Titulo { get; private set; }
            public int Porcentagem { get; private set; }

            public Consumo()
            {
                Titulo = "Toplam Doluluk Oranı";
                Porcentagem = CalcularPorcentagem();
            }

            public int CalcularPorcentagem()
            {
                int total = 0;


                total += CartOperation.GetAllWaitCart().Count;
                total += MusicListOperation.GetAllWaitMusic().Count;
                total += TableOperation.GetAllWaitTable().Count;


                return total > 100 ? 100 : total; //Calculo da porcentagem de consumo
            }
        }
    }
}
