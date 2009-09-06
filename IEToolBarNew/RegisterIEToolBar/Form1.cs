using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RegisterIEToolBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterHelper.RegisterBHO(typeof(IEToolBar.FilterToolBar));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterHelper.UnRegisterBHO(typeof(IEToolBar.FilterToolBar));
        }
    }
}