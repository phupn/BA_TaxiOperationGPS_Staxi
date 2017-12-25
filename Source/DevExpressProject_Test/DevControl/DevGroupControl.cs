using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpressProject_Test
{
    public partial class DevGroupControl : DevExpress.XtraEditors.GroupControl
    {
        public DevGroupControl()
        {
            InitializeComponent();
        }

        public DevGroupControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
