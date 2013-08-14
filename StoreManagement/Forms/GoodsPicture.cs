using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoreManagement.Forms
{
    public partial class GoodsPicture : DataGridView
    {
        public GoodsPicture()
        {
            InitializeComponent();
        }

        public GoodsPicture(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
