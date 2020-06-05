using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Plugins.FluentValidation;
using Xamarin.Plugins.UnobtrusiveFluentValidation;

namespace CP.Mobile.Tools
{
    public class FormTools
    {
        public static void FormClear(StackLayout Stl = null, AbstractValidationViewModel abstractValidation = null)
        {
            if (Stl != null)
            {
                foreach (var item in Stl.Children)
                {
                    if (item.GetType() == typeof(Entry))
                    {
                        (item as Entry).Text = string.Empty;
                    }
                    else if (item.GetType() == typeof(ValidatableEntryControl))
                    {
                        (item as ValidatableEntryControl).EntryText = string.Empty;
                       
                    }
                }
            }
        }
    }
}
