using System;
using System.Collections.Generic;
using System.Text;

namespace CP.Mobile.Tools.AlertModals.ModalClass
{
    public class Question
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Action Action { get; set; }
    }
}
