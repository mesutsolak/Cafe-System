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
        public App()
        {
            if (Current.Properties["UserName"]==null)
            {
                this.StartupUri = new Uri("LoginScreen.xaml", UriKind.Relative);
            }
            else
            {
                this.StartupUri = new Uri("Main.xaml", UriKind.Relative);
            }
        }
    }
}
