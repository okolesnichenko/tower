/*6. Осада замка.
Замок представляет собой многоугольник, ограниченный стенами, имеет некоторое количество
запасов, задаваемое пользователем (вода, хлеб, мясо, пиво), набор защитников(лучники, мечники, кавалерия).

Противник имеет армию с задаваемыми параметрами(типы и количество бойцов каждого типа). 

Смоделировать процесс осады замка.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Tower
{
    class Tower
    {
        public int X;
        public int Y;
        public int life;
        public int attack;
        static Font font = new Font(FontFamily.GenericSansSerif, 5);
        static SolidBrush brush_enemy_tower = new SolidBrush(Color.Black);
        public Tower(int X, int Y, int life, int attack)
        {
            this.X = X;
            this.Y = Y;
            this.life = life;
            this.attack = attack;
        }
        public static void Draw_Tower(Graphics g, Bitmap bmp, Pen pen, SolidBrush brush, PictureBox pictureBox1, Tower[] tower)
        {
            Point point1 = new Point(300, 100);
            if (tower[5].life > 0)
            {
                string s = Convert.ToString(tower[5].attack) + " : " + Convert.ToString(tower[5].life);
                g.DrawString(s, font, brush_enemy_tower, 270, 120);
                g.DrawRectangle(pen, 290, 90, 20, 20);
                g.FillRectangle(brush, 290, 90, 20, 20);
            }
            else
            {
                string s = "Dead";
                g.DrawString(s, font, brush, 270, 120);
            }
            Point point2 = new Point(360, 200);
            if (tower[4].life > 0)
            {
                string s = Convert.ToString(tower[4].attack) + " : " + Convert.ToString(tower[4].life);
                g.DrawString(s, font, brush_enemy_tower, 310, 200);
                g.DrawRectangle(pen, 350, 190, 20, 20);
                g.FillRectangle(brush, 350, 190, 20, 20);
            }
            else
            {
                string s = "Dead";
                g.DrawString(s, font, brush, 310, 200);
            }
            Point point3 = new Point(300, 300);
            if (tower[3].life > 0)
            {
                string s = Convert.ToString(tower[3].attack) + " : " + Convert.ToString(tower[3].life);
                g.DrawString(s, font, brush_enemy_tower, 270, 270);
                g.DrawRectangle(pen, 290, 290, 20, 20);
                g.FillRectangle(brush, 290, 290, 20, 20);
            }
            else
            {
                string s = "Dead";
                g.DrawString(s, font, brush, 270, 270);
            }
            Point point4 = new Point(160, 300);
            if (tower[2].life > 0)
            {
                string s = Convert.ToString(tower[2].attack) + " : " + Convert.ToString(tower[2].life);
                g.DrawString(s, font, brush_enemy_tower, 160, 270);
                g.DrawRectangle(pen, 150, 290, 20, 20);
                g.FillRectangle(brush, 150, 290, 20, 20);
            }
            else
            {
                string s = "Dead";
                g.DrawString(s, font, brush, 160, 270);
            }
            Point point5 = new Point(100, 200);
            if (tower[1].life > 0)
            {
                string s = Convert.ToString(tower[1].attack) + " : " + Convert.ToString(tower[1].life);
                g.DrawString(s, font, brush_enemy_tower, 120, 200);
                g.DrawRectangle(pen, 90, 190, 20, 20);
                g.FillRectangle(brush, 90, 190, 20, 20);
            }
            else
            {
                string s = "Dead";
                g.DrawString(s, font, brush, 120, 200);
            }
            Point point6 = new Point(160, 100);
            if (tower[0].life > 0)
            {
                string s = Convert.ToString(tower[0].attack) + " : " + Convert.ToString(tower[0].life);
                g.DrawString(s, font, brush_enemy_tower, 160, 120);
                g.DrawRectangle(pen, 150, 90, 20, 20);
                g.FillRectangle(brush, 150, 90, 20, 20);
            }
            else
            {
                string s = "Dead";
                g.DrawString(s, font, brush, 160, 120);
            }
            Point point7 = new Point(300, 100);
            Point[] curvePoints =
             {
                 point1,
                 point2,
                 point3,
                 point4,
                 point5,
                 point6,
                 point7
             };
            g.DrawPolygon(pen, curvePoints);
            pictureBox1.Image = bmp;
        }
    }

    class Fighter
    {
        public double X=400;
        public double Y=60;
        public int life=10;
        public int attack=10;
        public SolidBrush color;
        public int count = 0;
        public int num = 0;
        static Font font = new Font(FontFamily.GenericSansSerif, 5);
        static SolidBrush brush_enemy_tower = new SolidBrush(Color.Black);
        public Fighter(double X, double Y, int life, int attack, SolidBrush color)
        {
            this.X = X;
            this.Y = Y;
            this.life = life;
            this.attack = attack;
            this.color = color;
        }
        public void DrawEnemy(Tower[] towers, Fighter[] fight, Graphics g, Bitmap bmp, PictureBox pictureBox1, Pen pen,ref bool check)
        {
            if (num < fight.Length)
            {
                if (fight[num].life > 0)
                {
                    switch (count)
                    {
                        case 0:
                            if (fight[num].X > 130)
                            {
                                g.DrawEllipse(pen, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                g.FillEllipse(fight[num].color, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                string s = Convert.ToString(fight[num].attack) + " : " + Convert.ToString(fight[num].life);
                                g.DrawString(s, font, brush_enemy_tower, (float)fight[num].X - 10, (float)fight[num].Y - 25);
                                fight[num].X--;
                                pictureBox1.Image = bmp;
                            }
                            else
                            {
                                Attack(fight[num], towers[count]); count++; fight[num].X = 130;
                            }
                            break;
                        case 1:
                            if (fight[num].Y != 190)
                            {
                                g.DrawEllipse(pen, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                g.FillEllipse(fight[num].color, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                string s = Convert.ToString(fight[num].attack) + " : " + Convert.ToString(fight[num].life);
                                g.DrawString(s, font, brush_enemy_tower, (float)fight[num].X - 15, (float)fight[num].Y - 25);
                                fight[num].X -= 0.6;
                                fight[num].Y++;
                                pictureBox1.Image = bmp;
                            }
                            else { Attack(fight[num], towers[count]); count++; }
                            break;
                        case 2:
                            if (fight[num].Y != 320)
                            {
                                g.DrawEllipse(pen, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                g.FillEllipse(fight[num].color, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                string s = Convert.ToString(fight[num].attack) + " : " + Convert.ToString(fight[num].life);
                                g.DrawString(s, font, brush_enemy_tower, (float)fight[num].X - 10, (float)fight[num].Y + 25);
                                fight[num].X += 0.6;
                                fight[num].Y++;
                                pictureBox1.Image = bmp;
                            }
                            else { Attack(fight[num], towers[count]); count++; }
                            break;
                        case 3:
                            if (fight[num].X < 310)
                            {
                                g.DrawEllipse(pen, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                g.FillEllipse(fight[num].color, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                string s = Convert.ToString(fight[num].attack) + " : " + Convert.ToString(fight[num].life);
                                g.DrawString(s, font, brush_enemy_tower, (float)fight[num].X - 10, (float)fight[num].Y + 25);
                                fight[num].X++;
                                pictureBox1.Image = bmp;
                            }
                            else { Attack(fight[num], towers[count]); ; count++; fight[num].X = 310; }
                            break;
                        case 4:
                            if (fight[num].Y != 190)
                            {
                                g.DrawEllipse(pen, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                g.FillEllipse(fight[num].color, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                string s = Convert.ToString(fight[num].attack) + " : " + Convert.ToString(fight[num].life);
                                g.DrawString(s, font, brush_enemy_tower, (float)fight[num].X, (float)fight[num].Y + 25);
                                fight[num].Y--;
                                fight[num].X += 0.6;
                                pictureBox1.Image = bmp;
                            }
                            else { Attack(fight[num], towers[count]); count++; }
                            break;
                        case 5:
                            if (fight[num].Y != 60)
                            {
                                g.DrawEllipse(pen, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                g.FillEllipse(fight[num].color, (float)fight[num].X, (float)fight[num].Y, 20, 20);
                                string s = Convert.ToString(fight[num].attack) + " : " + Convert.ToString(fight[num].life);
                                g.DrawString(s, font, brush_enemy_tower, (float)fight[num].X - 10, (float)fight[num].Y - 25);
                                fight[num].Y--;
                                fight[num].X -= 0.6;
                                pictureBox1.Image = bmp;
                            }
                            else { Attack(fight[num], towers[count]); count = 0; }
                            break;
                        default: break;
                    }
                }
                else
                {
                    count = 0;
                    num++;
                }
            }
            else
            {
                check = true;
            } 
        }
        public static void Attack(Fighter fight, Tower tower)
        {
            if (tower.life > 0)
            {
                Random rnd = new Random();
                if (rnd.Next(0, 2) != 1)
                    fight.life = fight.life - tower.attack;
                else
                    tower.life = tower.life - fight.attack;
            }
        }
    }

    class Archers : Fighter
    {
        SolidBrush Red = new SolidBrush(Color.Red);
        public Archers(double X, double Y,int life, int attack, SolidBrush color) : base(X, Y, life, attack, color)
            {
            this.color = Red;
            }
    }
    class Swordsmen : Fighter
    {
        SolidBrush Blue = new SolidBrush(Color.Blue);
        public Swordsmen(double X, double Y, int life, int attack, SolidBrush color) : base(X, Y, life, attack, color)
        {
            this.color = Blue;
        }
    }
    class Covalry : Fighter
    {
        SolidBrush Green = new SolidBrush(Color.Green);
        public Covalry(double X, double Y, int life, int attack, SolidBrush color): base(X, Y, life, attack, color)
            {
            this.color = Green;
            }
    }
}
