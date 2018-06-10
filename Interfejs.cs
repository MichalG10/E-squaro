using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace E_squaro
{
    public partial class Interfejs : Form
    {
        public Interfejs()
        {
            InitializeComponent();
        }

        private static List<List<int>> matryca_liczb = new List<List<int>>();
        private static List<List<bool>> matryca_polonczen = new List<List<bool>>();
        private int przesuniencie_esqaro = 670;
        private int przesuniencie_Slither_Link = 50;

        private static List<List<int[]>> matryca_esqaro = new List<List<int[]>>();
        private static List<List<bool>> matryca_esqaro_Node = new List<List<bool>>();
        private static int szerokosc_esqaro = 1;
        private static int szerokosc_Slither_Link = 1;
        private static bool stworzono_Slither_Link = false;
        private static bool stworzono_esqaro = false;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
        private void tworz_matryce_liczb()
        {
            matryca_liczb.Clear();
            matryca_polonczen.Clear();
            int liczba_kolumn = (int)numericUpDown7.Value;
            for (int i = 0; i < liczba_kolumn; i++)
            {
                matryca_liczb.Add(new List<int>());
                for (int j = 0; j < liczba_kolumn; j++)
                {
                    matryca_liczb[i].Add(-1);
                }
            }
            for (int i = 0; i < liczba_kolumn * 2 + 1; i++)
            {
                matryca_polonczen.Add(new List<bool>());
                for (int j = 0; j < liczba_kolumn * 2 + 1; j++)
                {
                    matryca_polonczen[i].Add(false);
                }
            }
            szerokosc_Slither_Link = liczba_kolumn;
            stworzono_Slither_Link = true;
        }
        private void tworz_matryce_esqaro()
        {
            matryca_esqaro.Clear();
            matryca_esqaro_Node.Clear();
            int liczba_kolumn = (int)numericUpDown1.Value;
            for (int i = 0; i < liczba_kolumn; i++)
            {
                matryca_esqaro.Add(new List<int[]>());
                for (int j = 0; j < liczba_kolumn; j++)
                {
                    matryca_esqaro[i].Add(new int[2]);
                    matryca_esqaro[i][j][0] = 0;
                    matryca_esqaro[i][j][1] = 0;
                }
            }
            for (int i = 0; i < liczba_kolumn+1; i++)
            {
                matryca_esqaro_Node.Add(new List<bool>());
                for (int j = 0; j < liczba_kolumn + 1; j++)
                {
                    matryca_esqaro_Node[i].Add(false);
                }
            }
            szerokosc_esqaro = liczba_kolumn;
            stworzono_esqaro = true;
        }
        private void do_esqaro()
        {
            numericUpDown1.Value = szerokosc_Slither_Link * 2 + 1 + 2;
            tworz_matryce_esqaro();
            for (int i = 0; i < matryca_liczb.Count + 2; i++)
            {
                for (int j = 0; j < matryca_liczb.Count + 2; j++)
                {
                    if ((i == 0 || j == 0 || i == szerokosc_Slither_Link + 1 || j == szerokosc_Slither_Link + 1) && i != j && j + i != szerokosc_Slither_Link + 1)
                    {
                        matryca_esqaro[1 + szerokosc_Slither_Link + i - j][i + j][0] = 0;
                        matryca_esqaro[1 + szerokosc_Slither_Link + i - j][i + j][1] = 1;
                    }
                }
            }
            for (int i = 0; i < matryca_liczb.Count + 1; i++)
            {
                for (int j = 0; j < matryca_liczb.Count + 1; j++)
                {
                    matryca_esqaro[1 + szerokosc_Slither_Link + i - j][1 + i + j][0] = 0;
                    matryca_esqaro[1 + szerokosc_Slither_Link + i - j][1 + i + j][1] = 2;
                }
            }
            for (int i = 0; i < matryca_liczb.Count; i++)
            {
                for (int j = 0; j < matryca_liczb.Count; j++)
                {
                    if (matryca_liczb[i][j] != -1)
                    {
                        matryca_esqaro[1 + szerokosc_Slither_Link + i - j][2 + i + j][0] = matryca_liczb[i][j];
                        matryca_esqaro[1 + szerokosc_Slither_Link + i - j][2 + i + j][1] = matryca_liczb[i][j];
                    }
                    else
                    {
                        matryca_esqaro[1 + szerokosc_Slither_Link + i - j][2 + i + j][0] = -3;
                        matryca_esqaro[1 + szerokosc_Slither_Link + i - j][2 + i + j][1] = 0;
                    }
                    matryca_esqaro_Node[1 + szerokosc_Slither_Link + i - j + 1][2 + i + j] = matryca_polonczen[i * 2 + 1][j * 2];
                    matryca_esqaro_Node[1 + szerokosc_Slither_Link + i - j][2 + i + j + 1] = matryca_polonczen[i * 2 + 1][j * 2 + 2];
                    matryca_esqaro_Node[1 + szerokosc_Slither_Link + i - j][2 + i + j] = matryca_polonczen[i * 2][j * 2 + 1];
                    matryca_esqaro_Node[1 + szerokosc_Slither_Link + i - j + 1][2 + i + j + 1] = matryca_polonczen[i * 2 + 2][j * 2 + 1];
                }
            }
        }
        private void Z_esqaro()
        {
            if(szerokosc_esqaro>=5&& szerokosc_esqaro%2==1)
            {
                numericUpDown7.Value = (szerokosc_esqaro - 2) / 2;
                tworz_matryce_liczb();
                for (int i = 0; i < matryca_liczb.Count; i++)
                {
                    for (int j = 0; j < matryca_liczb.Count; j++)
                    {
                        if(matryca_esqaro[1 + szerokosc_Slither_Link + i - j][2 + i + j][0]>=0)
                            matryca_liczb[i][j] = matryca_esqaro[1 + szerokosc_Slither_Link + i - j][2 + i + j][0];
                        else
                            matryca_liczb[i][j] = -1;
                        matryca_polonczen[i * 2 + 1][j * 2] = matryca_esqaro_Node[1 + szerokosc_Slither_Link + i - j + 1][2 + i + j];
                        matryca_polonczen[i * 2 + 1][j * 2 + 2] = matryca_esqaro_Node[1 + szerokosc_Slither_Link + i - j][2 + i + j + 1];
                        matryca_polonczen[i * 2][j * 2 + 1] = matryca_esqaro_Node[1 + szerokosc_Slither_Link + i - j][2 + i + j];
                        matryca_polonczen[i * 2 + 2][j * 2 + 1] = matryca_esqaro_Node[1 + szerokosc_Slither_Link + i - j + 1][2 + i + j + 1];
                    }
                }
            }
        }
        private void rysuj_matryce()
        {
            Graphics myGraphics = base.CreateGraphics();
            Pen myPen = new Pen(Color.Black);
            SolidBrush mySolidBrush = new SolidBrush(Color.Black);

            Font font = new Font(FontFamily.GenericMonospace, 10);
            myGraphics.Clear(Color.White);
            if (stworzono_esqaro && checkBox1.Checked)
            {
                for (int i = 0; i < matryca_esqaro.Count; i++)
                {
                    for (int j = 0; j < matryca_esqaro[i].Count; j++)
                    {
                        if (matryca_esqaro[i][j][0] < 0 || (matryca_esqaro[i][j][0] == 0 && matryca_esqaro[i][j][1] == 0))
                            myGraphics.DrawString("<=" + matryca_esqaro[i][j][0] * -1, font, mySolidBrush, przesuniencie_esqaro+150 + 40 * i, 115 + 40 * j);
                        else
                            myGraphics.DrawString(matryca_esqaro[i][j][0].ToString() + '|' + matryca_esqaro[i][j][1], font, mySolidBrush, przesuniencie_esqaro + 150 + 40 * i,115 + 40 * j);

                    }
                }
                for (int i = 0; i < matryca_esqaro_Node.Count; i++)
                {
                    for (int j = 0; j < matryca_esqaro_Node[i].Count; j++)
                    {
                        if (matryca_esqaro_Node[i][j])
                            myGraphics.FillEllipse(mySolidBrush, przesuniencie_esqaro + 140 + 40 * i, 100 + 40 * j, 10, 10);
                        else
                            myGraphics.DrawEllipse(myPen, przesuniencie_esqaro + 140 + 40 * i, 100 + 40 * j, 10, 10);
                    }
                }
                int x = (int)numericUpDown4.Value - 1;
                int y = (int)numericUpDown3.Value - 1;
                if (matryca_esqaro_Node[x][y])
                    myGraphics.FillEllipse(mySolidBrush, przesuniencie_esqaro + 40, 220, 10, 10);
                else
                    myGraphics.DrawEllipse(myPen, przesuniencie_esqaro + 40, 220, 10, 10);
                if (matryca_esqaro_Node[x + 1][y])
                    myGraphics.FillEllipse(mySolidBrush, przesuniencie_esqaro + 40 + 40, 220, 10, 10);
                else
                    myGraphics.DrawEllipse(myPen, przesuniencie_esqaro + 40 + 40, 220, 10, 10);
                if (matryca_esqaro_Node[x][y + 1])
                    myGraphics.FillEllipse(mySolidBrush, przesuniencie_esqaro + 40, 220 + 40, 10, 10);
                else
                    myGraphics.DrawEllipse(myPen, przesuniencie_esqaro + 40, 220 + 40, 10, 10);
                if (matryca_esqaro_Node[x + 1][y + 1])
                    myGraphics.FillEllipse(mySolidBrush, przesuniencie_esqaro + 40 + 40, 220 + 40, 10, 10);
                else
                    myGraphics.DrawEllipse(myPen, przesuniencie_esqaro + 40 + 40, 220 + 40, 10, 10);
                if (matryca_esqaro[x][y][0] < 0 || (matryca_esqaro[x][y][0]==0 && matryca_esqaro[x][y][1]==0))
                    myGraphics.DrawString("<=" + matryca_esqaro[x][y][0] * -1, font, mySolidBrush, przesuniencie_esqaro + 50, 235);
                else
                    myGraphics.DrawString(matryca_esqaro[x][y][0].ToString() + '|' + matryca_esqaro[x][y][1], font, mySolidBrush, przesuniencie_esqaro + 50, 235);
            }
            if (stworzono_Slither_Link)
            {
                for (int i = 0; i < matryca_liczb.Count; i++)
                {
                    for (int j = 0; j < matryca_liczb.Count; j++)
                    {
                        if(matryca_liczb[i][j]>=0)
                            myGraphics.DrawString(matryca_liczb[i][j].ToString(), font, mySolidBrush, przesuniencie_Slither_Link+120 + 40 * i, 115 + 40 * j);
                    }
                }
                for (int i = 0; i < matryca_liczb.Count + 1; i++)
                {
                    for (int j = 0; j < matryca_liczb.Count + 1; j++)
                    {
                        myGraphics.FillEllipse(mySolidBrush, przesuniencie_Slither_Link + 100 + 40 * i, 100 + 40 * j, 10, 10);
                    }
                }
                for (int i = 0; i < matryca_polonczen.Count; i++)
                {
                    for (int j = 0; j < matryca_polonczen.Count; j++)
                    {
                        if((i+j)%2==1)
                            if(matryca_polonczen[i][j])
                                if(i%2==1)
                                    myGraphics.DrawLine(myPen, przesuniencie_Slither_Link + 85 + 20 * i, 105 + 20 * j, przesuniencie_Slither_Link + 125 + 20 * i, 105 + 20 * j);
                                else
                                    myGraphics.DrawLine(myPen, przesuniencie_Slither_Link + 105 + 20 * i, 85 + 20 * j, przesuniencie_Slither_Link + 105 + 20 * i, 125 + 20 * j);
                    }
                }
                myGraphics.FillEllipse(mySolidBrush, przesuniencie_Slither_Link, 270, 10, 10);
                myGraphics.FillEllipse(mySolidBrush, przesuniencie_Slither_Link+ 40, 270, 10, 10);
                myGraphics.FillEllipse(mySolidBrush, przesuniencie_Slither_Link, 270 + 40, 10, 10);
                myGraphics.FillEllipse(mySolidBrush, przesuniencie_Slither_Link+ 40, 270 + 40, 10, 10);

                int x = (int)numericUpDown9.Value - 1;
                int y = (int)numericUpDown10.Value - 1;

                if (matryca_liczb[x][y] >= 0)
                    myGraphics.DrawString(matryca_liczb[x][y].ToString(), font, mySolidBrush, przesuniencie_Slither_Link + 20, 285);

                if (matryca_polonczen[x * 2 + 1][y * 2])
                    myGraphics.DrawLine(myPen, przesuniencie_Slither_Link + 5 , 275, przesuniencie_Slither_Link + 45, 275);
                if (matryca_polonczen[x * 2 + 1][y * 2 + 2])
                    myGraphics.DrawLine(myPen, przesuniencie_Slither_Link + 5, 315, przesuniencie_Slither_Link + 45, 315);
                if (matryca_polonczen[x * 2][y * 2 + 1])
                    myGraphics.DrawLine(myPen, przesuniencie_Slither_Link + 5, 275 , przesuniencie_Slither_Link + 5, 315);
                if (matryca_polonczen[x * 2 + 2][y * 2 + 1])
                    myGraphics.DrawLine(myPen, przesuniencie_Slither_Link + 45, 275, przesuniencie_Slither_Link + 45, 315);
            }
        }
        private void przesuniecie()
        {

            przesuniencie_esqaro = 220 + szerokosc_Slither_Link * 40;

            label1.Location = new Point(przesuniencie_esqaro, label1.Location.Y);
            label6.Location = new Point(przesuniencie_esqaro + 186, label6.Location.Y);
            numericUpDown1.Location = new Point(przesuniencie_esqaro, numericUpDown1.Location.Y);
            button1.Location = new Point(przesuniencie_esqaro, button1.Location.Y);
            label3.Location = new Point(przesuniencie_esqaro, label3.Location.Y);
            numericUpDown4.Location = new Point(przesuniencie_esqaro, numericUpDown4.Location.Y);
            label8.Location = new Point(przesuniencie_esqaro, label8.Location.Y);
            numericUpDown3.Location = new Point(przesuniencie_esqaro, numericUpDown3.Location.Y);
            button2.Location = new Point(przesuniencie_esqaro, button2.Location.Y);
            button3.Location = new Point(przesuniencie_esqaro + 64, button3.Location.Y);
            button4.Location = new Point(przesuniencie_esqaro, button4.Location.Y);
            button5.Location = new Point(przesuniencie_esqaro + 64, button5.Location.Y);
            numericUpDown5.Location = new Point(przesuniencie_esqaro, numericUpDown5.Location.Y);
            numericUpDown6.Location = new Point(przesuniencie_esqaro + 64, numericUpDown6.Location.Y);
            button7.Location = new Point(przesuniencie_esqaro, button7.Location.Y);
            button12.Location = new Point(przesuniencie_esqaro, button12.Location.Y);
            Rozwiaz_ESquar0.Location = new Point(przesuniencie_esqaro, Rozwiaz_ESquar0.Location.Y);
        }
        private void reset_tablica()
        {
            numericUpDown9.Value = 1;
            numericUpDown10.Value = 1;
            numericUpDown11.Value = -1;
        }
        private void reset_esqaro()
        {
            numericUpDown4.Value = 1;
            numericUpDown3.Value = 1;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
        }
        private void set_tablice()
        {
            if(stworzono_Slither_Link)
            {
                int x = (int)numericUpDown9.Value - 1;
                int y = (int)numericUpDown10.Value - 1;
                matryca_liczb[x][y] = (int)numericUpDown11.Value;
            }
        }
        private void set_esqaro()
        {
            if(stworzono_esqaro)
            {
                int x = (int)numericUpDown4.Value - 1;
                int y = (int)numericUpDown3.Value - 1;
                matryca_esqaro[x][y][0] = (int)numericUpDown5.Value;
                matryca_esqaro[x][y][1] = (int)numericUpDown6.Value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            reset_esqaro();
            tworz_matryce_esqaro();
            rysuj_matryce();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown4.Value > szerokosc_esqaro)
            {
                numericUpDown4.Value = szerokosc_esqaro;
            }
            rysuj_matryce();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value > szerokosc_esqaro)
            {
                numericUpDown3.Value = szerokosc_esqaro;
            }
            rysuj_matryce();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown4.Value - 1;
            int y = (int)numericUpDown3.Value - 1;
            if (stworzono_esqaro)
                matryca_esqaro_Node[x][y] = !matryca_esqaro_Node[x][y];
            rysuj_matryce();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown4.Value - 1;
            int y = (int)numericUpDown3.Value - 1;
            if (stworzono_esqaro)
                matryca_esqaro_Node[x+1][y] = !matryca_esqaro_Node[x+1][y];
            rysuj_matryce();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown4.Value - 1;
            int y = (int)numericUpDown3.Value - 1;
            if (stworzono_esqaro)
                matryca_esqaro_Node[x][y+1] = !matryca_esqaro_Node[x][y+1];
            rysuj_matryce();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown4.Value - 1;
            int y = (int)numericUpDown3.Value - 1;
            if (stworzono_esqaro)
                matryca_esqaro_Node[x+1][y+1] = !matryca_esqaro_Node[x+1][y+1];
            rysuj_matryce();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown5.Value > numericUpDown6.Value)
                numericUpDown5.Value = numericUpDown6.Value;
            set_esqaro();
            rysuj_matryce();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown5.Value > numericUpDown6.Value)
                numericUpDown5.Value = numericUpDown6.Value;
            set_esqaro();
            rysuj_matryce();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            reset_tablica();
            tworz_matryce_liczb();
            przesuniecie();
            rysuj_matryce();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown9.Value > szerokosc_Slither_Link)
            {
                numericUpDown9.Value = szerokosc_Slither_Link;
            }
            rysuj_matryce();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown10.Value > szerokosc_Slither_Link)
            {
                numericUpDown10.Value = szerokosc_Slither_Link;
            }
            rysuj_matryce();
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            set_tablice();
            rysuj_matryce();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(stworzono_Slither_Link)
                do_esqaro();
            rysuj_matryce();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown9.Value - 1;
            int y = (int)numericUpDown10.Value - 1;
            if (stworzono_Slither_Link)
                matryca_polonczen[1+x*2][y*2] = !matryca_polonczen[1 + x * 2][y * 2];
            rysuj_matryce();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown9.Value - 1;
            int y = (int)numericUpDown10.Value - 1;
            if (stworzono_Slither_Link)
                matryca_polonczen[1 + x * 2][2 + y * 2] = !matryca_polonczen[1 + x * 2][2 + y * 2];
            rysuj_matryce();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown9.Value - 1;
            int y = (int)numericUpDown10.Value - 1;
            if (stworzono_Slither_Link)
                matryca_polonczen[x * 2][1 + y * 2] = !matryca_polonczen[x * 2][1 + y * 2];
            rysuj_matryce();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown9.Value - 1;
            int y = (int)numericUpDown10.Value - 1;
            if (stworzono_Slither_Link)
                matryca_polonczen[2 + x * 2][1 + y * 2] = !matryca_polonczen[2 + x * 2][1 + y * 2];
            rysuj_matryce();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (stworzono_esqaro)
                Z_esqaro();
            rysuj_matryce();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            rysuj_matryce();
        }
        private E_squaro.CellType[][] Zwroc_Tablice_CellType(int szerokosc)
        {
            E_squaro.CellType[][] tablica = new E_squaro.CellType[szerokosc][];
            for (int i = 0; i < szerokosc; i++)
            {
                tablica[i] = new E_squaro.CellType[szerokosc];
                for (int j = 0; j < szerokosc; j++)
                {
                    switch (matryca_esqaro[i][j][0])
                    {
                        case 0:
                            {
                                switch (matryca_esqaro[i][j][1])
                                {
                                    case 0:
                                        {
                                            tablica[i][j] = E_squaro.CellType.KLESS0;
                                            break;
                                        }
                                    case 1:
                                        {
                                            tablica[i][j] = E_squaro.CellType.KLESS1;
                                            break;
                                        }
                                    case 2:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K0OVER2;
                                            break;
                                        }
                                    case 3:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K0OVER3;
                                            break;
                                        }
                                    case 4:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K0OVER4;
                                            break;
                                        }
                                }
                                break;
                            }
                        case -1:
                            {
                                tablica[i][j] = E_squaro.CellType.KLESS1;
                                break;
                            }
                        case -2:
                            {
                                tablica[i][j] = E_squaro.CellType.KLESS2;
                                break;
                            }
                        case -3:
                            {
                                tablica[i][j] = E_squaro.CellType.KLESS3;
                                break;
                            }
                        case -4:
                            {
                                tablica[i][j] = E_squaro.CellType.KLESS4;
                                break;
                            }
                        case 1:
                            {
                                switch (matryca_esqaro[i][j][1])
                                {
                                    case 1:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K1OVER1;
                                            break;
                                        }
                                    case 2:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K1OVER2;
                                            break;
                                        }
                                    case 3:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K1OVER3;
                                            break;
                                        }
                                    case 4:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K1OVER4;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 2:
                            {
                                switch (matryca_esqaro[i][j][1])
                                {
                                    case 2:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K2OVER2;
                                            break;
                                        }
                                    case 3:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K2OVER3;
                                            break;
                                        }
                                    case 4:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K2OVER4;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 3:
                            {
                                switch (matryca_esqaro[i][j][1])
                                {
                                    case 3:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K3OVER3;
                                            break;
                                        }
                                    case 4:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K3OVER4;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 4:
                            {
                                switch (matryca_esqaro[i][j][1])
                                {
                                    case 4:
                                        {
                                            tablica[i][j] = E_squaro.CellType.K4OVER4;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                }
            }
            return tablica;
        }
        
        void Z_Listy_Bool(List<bool> lista)
        {
            int k = 0; ;
            for (int i = 0; i < szerokosc_esqaro + 1; i++)
                for (int j = 0; j < szerokosc_esqaro + 1; j++)
                {
                    matryca_esqaro_Node[i][j] = lista[k];
                    k++;
                }
        }
        
        private void Rozwiaz_Lamiglowke_Click(object sender, EventArgs e)
        {
            if (stworzono_Slither_Link)
            {
                do_esqaro();
                E_squaro.CellType[][] Tablica_CellType = Zwroc_Tablice_CellType(szerokosc_esqaro);
                ESquarMatrix ESM = new ESquarMatrix(szerokosc_esqaro,szerokosc_esqaro);
                RSatBuilder rsatBuilder = new RSatBuilder();
                for (int i = 0; i < szerokosc_esqaro; i++)
                    for (int j = 0; j < szerokosc_esqaro; j++)
                        ESM.AddCell(Tablica_CellType[i][j], i, j);

                rsatBuilder.GenerateInput(ESM.GetCellsList());

                rsatBuilder.RunRSatSolver();

                var wynik = rsatBuilder.GetInterpretedOutput();

                if (wynik != null)
                {
                    rsatBuilder.SaveOutput();

                    OutputConverter OC = new OutputConverter(ESM, wynik);

                    Z_Listy_Bool(OC.Convert());

                    Z_esqaro();
                }
                else MessageBox.Show("Problem jest nierozwiązywalny");
            }
            rysuj_matryce();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
            label6.Visible = !label6.Visible;
            numericUpDown1.Visible = !numericUpDown1.Visible;
            button1.Visible = !button1.Visible;
            label3.Visible = !label3.Visible;
            numericUpDown4.Visible = !numericUpDown4.Visible;
            label8.Visible = !label8.Visible;
            numericUpDown3.Visible = !numericUpDown3.Visible;
            button2.Visible = !button2.Visible;
            button3.Visible = !button3.Visible;
            button4.Visible = !button4.Visible;
            button5.Visible = !button5.Visible;
            numericUpDown5.Visible = !numericUpDown5.Visible;
            numericUpDown6.Visible = !numericUpDown6.Visible;
            button7.Visible = !button7.Visible;
            button12.Visible = !button12.Visible;
            Rozwiaz_ESquar0.Visible = !Rozwiaz_ESquar0.Visible;
            rysuj_matryce();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Rozwiaz_ESquar0_Click(object sender, EventArgs e)
        {
            if (stworzono_esqaro)
            {
                E_squaro.CellType[][] Tablica_CellType = Zwroc_Tablice_CellType(szerokosc_esqaro);
                ESquarMatrix ESM = new ESquarMatrix(szerokosc_esqaro, szerokosc_esqaro);
                RSatBuilder rsatBuilder = new RSatBuilder();
                for (int i = 0; i < szerokosc_esqaro; i++)
                    for (int j = 0; j < szerokosc_esqaro; j++)
                        ESM.AddCell(Tablica_CellType[i][j], i, j);

                rsatBuilder.GenerateInput(ESM.GetCellsList());

                rsatBuilder.RunRSatSolver();

                var wynik = rsatBuilder.GetInterpretedOutput();

                if (wynik != null)
                {
                    rsatBuilder.SaveOutput();

                    OutputConverter OC = new OutputConverter(ESM, wynik);

                    Z_Listy_Bool(OC.Convert());
                }
                else MessageBox.Show("Problem jest nierozwiązywalny");
            }
            rysuj_matryce();
        }
    }
}
