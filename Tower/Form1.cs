using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tower
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Pen pen;
        SolidBrush brush;
        SolidBrush Red;
        SolidBrush Blue;
        SolidBrush Green;
        static SolidBrush color = new SolidBrush(Color.Black);
        public static int n;
        bool check = false;
        Tower[] towers = new Tower[6];
        Fighter[] fight;
        Archers[] arch;
        Swordsmen[] sword;
        Covalry[] coval;
        Fighter fighter = new Fighter(400, 30, 1, 1, color);
        int Life = 1;
        int Attack = 1;

        public int i = 0;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            Init_Tower();
            Init();
            Tower.Draw_Tower(g, bmp, pen, brush, pictureBox1, towers);
        }
        public void Init()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pen = new Pen(Color.Black, 2);
            brush = new SolidBrush(Color.Gray);
            Red = new SolidBrush(Color.Red);
            Blue = new SolidBrush(Color.Blue);
            Green = new SolidBrush(Color.Green);

        }
        private void Init_Tower()
        {
            towers[0] = new Tower(160, 100, Life, Attack);
            towers[1] = new Tower(100, 200, Life, Attack);
            towers[2] = new Tower(160, 100, Life, Attack);
            towers[3] = new Tower(300, 300, Life, Attack);
            towers[4] = new Tower(360, 200, Life, Attack);
            towers[5] = new Tower(300, 100, Life, Attack);
        }
        private void Init_Fighter()
        {
            n = (int)numericUpDown1.Value + (int)numericUpDown2.Value + (int)numericUpDown3.Value;
            fight = new Fighter[n];
            int rec = 0;
            int a;
            a = (int)numericUpDown1.Value;
            arch = new Archers[a];
            for (int i = 0; i < a; i++)
            {
                arch[i] = new Archers(400, 60, 15, 5,Red);
                fight[rec] = arch[i];
                rec++;
            }
            int b;
            b = (int)numericUpDown2.Value;
            sword = new Swordsmen[b];
            for (int i = 0; i < b; i++)
            {
                sword[i] = new Swordsmen(400, 60, 10, 10, Blue);
                fight[rec] = sword[i];
                rec++;
            }

            int c;
            c = (int)numericUpDown3.Value;
            coval = new Covalry[c];
            for (int i = 0; i < c; i++)
            {
                coval[i] = new Covalry(400, 60, 3, 15, Green);
                fight[rec] = coval[i];
                rec++;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (check == false)
            {
                g.Clear(Color.White);
                Tower.Draw_Tower(g, bmp, pen, brush, pictureBox1, towers);
                fighter.DrawEnemy(towers, fight, g, bmp, pictureBox1, pen, ref check);
            }
            else
            {
                timer1.Stop();
                timer1.Dispose();
            }      
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Life= (int)numericWater.Value + (int)numericBread.Value;
            Attack = ((int)numericBeer.Value + (int)numericMeat.Value)/2;
            Init_Tower();
            Init_Fighter();            
            timer1.Start();
            Dis();
        }
        private void Dis()
        {
            numericBeer.Enabled = false;
            numericBread.Enabled = false;
            numericMeat.Enabled = false;
            numericWater.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
  
        }
    }
}


