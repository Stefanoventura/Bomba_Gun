using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Bomba_Gun
{
    public partial class Form1 : Form
    {
        Thread jogo;
        SoundPlayer soundPlayer;
        public Form1()
        {
            InitializeComponent();
            soundPlayer = new SoundPlayer(Properties.Resources.tema_jogo);
            soundPlayer.Play();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Close();
            soundPlayer.Stop();
            jogo = new Thread(abrirJogo);
            jogo.SetApartmentState(ApartmentState.STA);
            jogo.Start();
        }

        private void abrirJogo(object obj)
        {
            Application.Run(new FrmPlay());
        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            FrmCreditos formularioCreditos = new FrmCreditos();
            formularioCreditos.ShowDialog();
            soundPlayer.Play();
        }
    }
}
