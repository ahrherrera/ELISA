using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELISA.UI.Dialogs
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen(string text)
        {
            InitializeComponent();
            this.label1.Text = text;
        }
    }
}
