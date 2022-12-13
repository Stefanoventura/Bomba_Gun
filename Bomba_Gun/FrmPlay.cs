using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bomba_Gun
{
    
    public partial class FrmPlay : Form
    {
        SoundPlayer soundPlayer;

        int velocidade = 5;

        int pontuacao = 0;

        Random rand = new Random();

        bool gameOver = false;

        public FrmPlay()
        {
            InitializeComponent();
            resetGame();
            soundPlayer = new SoundPlayer(Properties.Resources.tema_jogo);
            soundPlayer.Play();

            this.Cursor = new Cursor(GetType(), "Mira.ico");      
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void gameEngine(object sender, EventArgs e)
        {
            label1.Text = "    " + pontuacao.ToString();

            foreach (Control X in this.Controls)
            {
                if (X is PictureBox)
                {
                    X.Top -= velocidade;

                    if (X.Top + X.Height < 0)
                    {
                        X.Top = rand.Next(700, 1000);

                        X.Left = rand.Next(5, 500);
                    }

                    if (X.Tag == "Balao" && X.Top < -50)
                    {
                        tempoJogo.Stop();
                        soundPlayer.Stop();
                        FrmGameOver formularioCreditos = new FrmGameOver();
                        formularioCreditos.Show();
                        gameOver = true;
                    }
                }
            }

            if (pontuacao >= 10)
            {
                velocidade = 5;
            }

            if (pontuacao >= 20)
            {
                velocidade = 10;
            }

            if (pontuacao >= 35)
            {
                velocidade = 20;
            }
        }

        private void popBalao(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                var balao = (PictureBox)sender;

                balao.Top = rand.Next(700, 1000);

                balao.Left = rand.Next(5, 500);

                pontuacao++;
            }
        }

        private void FrmPlay_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Bomba_Click(object sender, EventArgs e)
        {
            if (gameOver == false)
            {
                bomba.Image = Properties.Resources.boom;

                soundPlayer.Stop();
                FrmGameOver formularioCreditos = new FrmGameOver();
                formularioCreditos.Show();

                tempoJogo.Stop();
                
                gameOver = true;
            }
        }

       private void resetGame()
        {
            foreach (Control X in this.Controls)
            {
                if (X is PictureBox)
                {
                    X.Top = rand.Next(700, 1000);

                    X.Left = rand.Next(5, 500);
                }
            }
      
            velocidade = 3;

            pontuacao = 0;

            gameOver = false;

            label1.Text = pontuacao.ToString();

            tempoJogo.Start();
        }
      
        private void keyisdown (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                resetGame();
            }
        }
    }
}

