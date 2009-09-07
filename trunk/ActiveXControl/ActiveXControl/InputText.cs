using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ActiveXControl
{
    [Guid("9D0CA446-0293-43d2-B033-8BDF8D9619ED")]
    public partial class InputText : UserControl,IObjectSafety
    {
        public InputText()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.txtInput.Text);
        }

        #region IObjectSafety Members

        public void GetInterfacceSafyOptions(int riid, out int pdwSupportedOptions, out int pdwEnabledOptions)
        {
            pdwSupportedOptions = 1;
            pdwEnabledOptions = 2;
        }

        public void SetInterfaceSafetyOptions(int riid, int dwOptionsSetMask, int dwEnabledOptions)
        {
            //throw new NotImplementedException();
        }

        #endregion
        public void HelloWorld()
        {
            MessageBox.Show("Hello World");
        }
        public string GetHelloWorld()
        {
            return "Hello World" + this.txtInput.Text;
        }
    }
}
