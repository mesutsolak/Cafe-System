using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CP.Mobile.Tools.AlertModal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionModal : ContentPage
    {
        int _id;
        string _name;

        public QuestionModal(int id,string name)
        {
            _id = id;
            _name = name;
            InitializeComponent();
        }
    }
}