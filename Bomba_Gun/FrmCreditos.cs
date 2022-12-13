using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomba_Gun
{

    public partial class FrmCreditos : Form
    {

        public FrmCreditos()
        {
            InitializeComponent();
            axWindowsMediaPlayer1.uiMode = "none";
        }

        private void FrmCreditos_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "creditos.avi";
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
