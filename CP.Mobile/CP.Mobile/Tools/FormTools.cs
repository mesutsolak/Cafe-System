using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CP.Mobile.Tools
{
    public class FormTools
    {
        public static void FormClear(StackLayout Stl)
        {
            foreach (var item in Stl.Children)
            {
                if (item.GetType() == typeof(Entry))
                {
                    (item as Entry).Text = string.Empty;
                }
            }
        }
    }
}
