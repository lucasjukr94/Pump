using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pump
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        private List<Seta> setas = new List<Seta>(); 
        private List<Seta> barras = new List<Seta>(); 
        private Random random = new Random();
        private int contador = 0;
        private int contabarra = 0;
        private int glow = 0;
        private int pontuacao = 0;
        private int clicado = 0;
        private int score = 0;
        private SolidBrush um = new SolidBrush(Color.Brown);
        private SolidBrush dois = new SolidBrush(Color.Brown);
        private SolidBrush tres = new SolidBrush(Color.Brown);
        private SolidBrush quatro = new SolidBrush(Color.Brown);
        private SolidBrush cinco = new SolidBrush(Color.Brown);
        private SolidBrush seis = new SolidBrush(Color.Brown);
        private SolidBrush meio = new SolidBrush(Color.Red);

        public Form1()
        {
            InitializeComponent();
            Width = 1200;
            Height = 700;
            DoubleBuffered = true;
            KeyPreview = true;
            CenterToScreen();
        }

        public void InitTimer()
        {
            timer.Interval = 1;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            contador++;
            contabarra++;
            glow++;
            label1.Text = pontuacao.ToString();
            label2.Text = score.ToString();
            if (contador%40 == 0)
            {
                contador = 0;
                int rand = random.Next(0, 7);
                switch (rand)
                {
                    case 1:
                        setas.Add(new Seta(50, 200, 50, 50, 1));
                        break;
                    case 2:
                        setas.Add(new Seta(50, 250, 50, 50, 1));
                        break;
                    case 3:
                        setas.Add(new Seta(50, 300, 50, 50, 1));
                        break;
                    case 4:
                        setas.Add(new Seta(1000, 200, 50, 50, -1));
                        break;
                    case 5:
                        setas.Add(new Seta(1000, 250, 50, 50, -1));
                        break;
                    case 6:
                        setas.Add(new Seta(1000, 300, 50, 50, -1));
                        break;
                }
            }

            if (contabarra%100 == 0)
            {
                barras.Add(new Seta(300, 400, 15, 15, 1));
                barras.Add(new Seta(700, 400, 15, 15, -1));
            }

            foreach (var p in setas)
            {
                if (p.direcao == 1)
                {
                    p.x+=3;
                }
                else
                {
                    p.x-=3;
                }
            }

            foreach (var p in barras)
            {
                if (p.direcao == 1)
                {
                    p.x+=3;
                }
                else
                {
                    p.x-=3;
                }
            }

            for (int i = 0; i < setas.Count; i++)
            {
                if (setas[i].direcao == 1)
                {
                    setas[i].x++;
                    if (setas[i].x > 450)
                    {
                        pontuacao = 0;
                        setas.RemoveAt(i);
                    }
                    try
                    {
                        if (acertou(setas[i]))
                        {
                            pontuacao++;
                            score += pontuacao + 100;
                            setas.RemoveAt(i);
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
                else
                {
                    setas[i].x--;
                    if (setas[i].x < 550)
                    {
                        pontuacao = 0;
                        setas.RemoveAt(i);
                    }
                    try
                    {
                        if (acertou(setas[i]))
                        {
                            pontuacao++;
                            score += pontuacao + 100;
                            setas.RemoveAt(i);
                        }
                    }
                    catch (Exception)
                    {
                        
                    }
                }
            }

            for (int i = 0; i < barras.Count-1; i++)
            {
                if (barras[i].direcao == 1)
                {
                    if (barras[i].x > barras[i + 1].x)
                    {
                        pontuacao = 0;
                        barras.RemoveAt(i);
                        barras.RemoveAt(i);
                    }
                    else
                    {
                        if (acertou(barras[i]))
                        {
                            pontuacao++;
                            score += pontuacao + 100;
                            barras.RemoveAt(i);
                            barras.RemoveAt(i);
                        }      
                    } 
                }
            }

            if (glow > 5)
            {
                um.Color = Color.Black;
                dois.Color = Color.Black;
                tres.Color = Color.Black;
                quatro.Color = Color.Black;
                cinco.Color = Color.Black;
                seis.Color = Color.Black;
                meio.Color = Color.Red;

                glow = 0;
                clicado = 0;
            }

            Invalidate();
        }

        private bool acertou(Seta seta)
        {
            if (clicado == 7 && seta.y == 200 && seta.direcao == 1 && seta.x > 390 && seta.x < 490)
            {
                return true;
            }
            if (clicado == 4 && seta.y == 250 && seta.direcao == 1 && seta.x > 390 && seta.x < 490)
            {
                return true;
            }
            if (clicado == 1 && seta.y == 300 && seta.direcao == 1 && seta.x > 390 && seta.x < 490)
            {
                return true;
            }
            if (clicado == 9 && seta.y == 200 && seta.direcao == -1 && seta.x < 640 && seta.x > 540)
            {
                return true;
            }
            if (clicado == 6 && seta.y == 250 && seta.direcao == -1 && seta.x < 640 && seta.x > 540)
            {
                return true;
            }
            if (clicado == 3 && seta.y == 300 && seta.direcao == -1 && seta.x < 640 && seta.x > 540)
            {
                return true;
            }
            if (clicado == 5 && seta.y == 400 && seta.x < 532 && seta.x > 482)
            {
                return true;
            }
            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
            label3.Text = "Combo";
            label4.Text = "Score";
            button1.Text = "Iniciar";
            button2.Text = "STOP";
            button2.Enabled = false;
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 10;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) return;
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                    clicado = 1;
                    um.Color = Color.Green;
                    break;
                case Keys.NumPad4:
                    clicado = 4;
                    dois.Color = Color.Green;
                    break;
                case Keys.NumPad7:
                    clicado = 7;
                    tres.Color = Color.Green;
                    break;
                case Keys.NumPad3:
                    clicado = 3;
                    quatro.Color = Color.Green;
                    break;
                case Keys.NumPad6:
                    clicado = 6;
                    cinco.Color = Color.Green;
                    break;
                case Keys.NumPad9:
                    clicado = 9;
                    seis.Color = Color.Green;
                    break;
                case Keys.NumPad5:
                    clicado = 5;
                    meio.Color = Color.Green;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(50, 200, 400, 50));
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(50, 250, 400, 50));
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(50, 300, 400, 50));

            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(600, 200, 400, 50));
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(600, 250, 400, 50));
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(600, 300, 400, 50));

            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(320, 400, 400, 15));

            e.Graphics.FillRectangle(tres, new Rectangle(400, 200, 50, 50));
            e.Graphics.FillRectangle(dois, new Rectangle(400, 250, 50, 50));
            e.Graphics.FillRectangle(um, new Rectangle(400, 300, 50, 50));

            e.Graphics.FillRectangle(seis, new Rectangle(600, 200, 50, 50));
            e.Graphics.FillRectangle(cinco, new Rectangle(600, 250, 50, 50));
            e.Graphics.FillRectangle(quatro, new Rectangle(600, 300, 50, 50));

            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(482,400,50,15));
            e.Graphics.FillRectangle(meio, new Rectangle(500, 400, 15, 15));

            foreach (var p in setas)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.DeepSkyBlue), new Rectangle(p.x, p.y, p.Width, p.Height));
            }

            foreach (var p in barras)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.DeepSkyBlue), new Rectangle(p.x, p.y, p.Width, p.Height));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            numericUpDown1.Enabled = false;
            button2.Enabled = true;
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                InitTimer();    
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
