using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormTest.Common.Resize
{
    public class ResizeControlRecord
    {
        public Control[] AllControls { set; get; }

        public Control[] WidthControls { set; get; }

        public Control[] HeightControls { set; get; }

    }
}
