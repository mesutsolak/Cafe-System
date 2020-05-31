using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CP.DesktopUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string Url = "";
        void App_Startup(object sender, StartupEventArgs e)
        {

            if (Application.Current.Properties["UserName"] == null)
                Url = "LoginScreen.xaml";
            else
                Url = "Main.xaml";


            StartupUri = new Uri(Url, UriKind.Relative);
        }

    }
}
