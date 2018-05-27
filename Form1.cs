using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace E_squaro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static List<List<int>> matryca_liczb = new List<List<int>>();
        private static List<List<bool>> matryca_polonczen = new List<List<bool>>();


        private static List<List<int[]>> matryca_esqaro = new List<List<int[]>>();
        private static List<List<bool>> matryca_esqaro_Node = new List<List<bool>>();
        private static int szerokosc_esqaro = 1;
        private static int szerokosc_tablicy = 1;
        private static bool stworzono_tablice = false;
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
            szerokosc_tablicy = liczba_kolumn;
            stworzono_tablice = true;
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
            numericUpDown1.Value = szerokosc_tablicy * 2 + 1 + 2;
            tworz_matryce_esqaro();
            for (int i = 0; i < matryca_liczb.Count + 2; i++)
            {
                for (int j = 0; j < matryca_liczb.Count + 2; j++)
                {
                    if ((i == 0 || j == 0 || i == szerokosc_tablicy + 1 || j == szerokosc_tablicy + 1) && i != j && j + i != szerokosc_tablicy + 1)
                    {
                        matryca_esqaro[1 + szerokosc_tablicy + i - j][i + j][0] = 0;
                        matryca_esqaro[1 + szerokosc_tablicy + i - j][i + j][1] = 1;
                    }
                }
            }
            for (int i = 0; i < matryca_liczb.Count + 1; i++)
            {
                for (int j = 0; j < matryca_liczb.Count + 1; j++)
                {
                    matryca_esqaro[1 + szerokosc_tablicy + i - j][1 + i + j][0] = 0;
                    matryca_esqaro[1 + szerokosc_tablicy + i - j][1 + i + j][1] = 2;
                }
            }
            for (int i = 0; i < matryca_liczb.Count; i++)
            {
                for (int j = 0; j < matryca_liczb.Count; j++)
                {
                    if (matryca_liczb[i][j] != -1)
                    {
                        matryca_esqaro[1 + szerokosc_tablicy + i - j][2 + i + j][0] = matryca_liczb[i][j];
                        matryca_esqaro[1 + szerokosc_tablicy + i - j][2 + i + j][1] = matryca_liczb[i][j];
                    }
                    else
                    {
                        matryca_esqaro[1 + szerokosc_tablicy + i - j][2 + i + j][0] = -3;
                        matryca_esqaro[1 + szerokosc_tablicy + i - j][2 + i + j][1] = 0;
                    }
                    matryca_esqaro_Node[1 + szerokosc_tablicy + i - j + 1][2 + i + j] = matryca_polonczen[i * 2 + 1][j * 2];
                    matryca_esqaro_Node[1 + szerokosc_tablicy + i - j][2 + i + j + 1] = matryca_polonczen[i * 2 + 1][j * 2 + 2];
                    matryca_esqaro_Node[1 + szerokosc_tablicy + i - j][2 + i + j] = matryca_polonczen[i * 2][j * 2 + 1];
                    matryca_esqaro_Node[1 + szerokosc_tablicy + i - j + 1][2 + i + j + 1] = matryca_polonczen[i * 2 + 2][j * 2 + 1];
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
                        if(matryca_esqaro[1 + szerokosc_tablicy + i - j][2 + i + j][0]>=0)
                            matryca_liczb[i][j] = matryca_esqaro[1 + szerokosc_tablicy + i - j][2 + i + j][0];
                        else
                            matryca_liczb[i][j] = -1;
                        matryca_polonczen[i * 2 + 1][j * 2] = matryca_esqaro_Node[1 + szerokosc_tablicy + i - j + 1][2 + i + j];
                        matryca_polonczen[i * 2 + 1][j * 2 + 2] = matryca_esqaro_Node[1 + szerokosc_tablicy + i - j][2 + i + j + 1];
                        matryca_polonczen[i * 2][j * 2 + 1] = matryca_esqaro_Node[1 + szerokosc_tablicy + i - j][2 + i + j];
                        matryca_polonczen[i * 2 + 2][j * 2 + 1] = matryca_esqaro_Node[1 + szerokosc_tablicy + i - j + 1][2 + i + j + 1];
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
            if (stworzono_esqaro)
            {
                for (int i = 0; i < matryca_esqaro.Count; i++)
                {
                    for (int j = 0; j < matryca_esqaro[i].Count; j++)
                    {
                        if (matryca_esqaro[i][j][0] < 0 || (matryca_esqaro[i][j][0] == 0 && matryca_esqaro[i][j][1] == 0))
                            myGraphics.DrawString("<=" + matryca_esqaro[i][j][0] * -1, font, mySolidBrush, 160 + 40 * i, 115 + 40 * j);
                        else
                            myGraphics.DrawString(matryca_esqaro[i][j][0].ToString() + '|' + matryca_esqaro[i][j][1], font, mySolidBrush, 160 + 40 * i, 115 + 40 * j);

                    }
                }
                for (int i = 0; i < matryca_esqaro_Node.Count; i++)
                {
                    for (int j = 0; j < matryca_esqaro_Node[i].Count; j++)
                    {
                        if (matryca_esqaro_Node[i][j])
                            myGraphics.FillEllipse(mySolidBrush, 150 + 40 * i, 100 + 40 * j, 10, 10);
                        else
                            myGraphics.DrawEllipse(myPen, 150 + 40 * i, 100 + 40 * j, 10, 10);
                    }
                }
                int x = (int)numericUpDown4.Value - 1;
                int y = (int)numericUpDown3.Value - 1;
                if (matryca_esqaro_Node[x][y])
                    myGraphics.FillEllipse(mySolidBrush, 50, 220, 10, 10);
                else
                    myGraphics.DrawEllipse(myPen, 50, 220, 10, 10);
                if (matryca_esqaro_Node[x + 1][y])
                    myGraphics.FillEllipse(mySolidBrush, 50 + 40, 220, 10, 10);
                else
                    myGraphics.DrawEllipse(myPen, 50 + 40, 220, 10, 10);
                if (matryca_esqaro_Node[x][y + 1])
                    myGraphics.FillEllipse(mySolidBrush, 50, 220 + 40, 10, 10);
                else
                    myGraphics.DrawEllipse(myPen, 50, 220 + 40, 10, 10);
                if (matryca_esqaro_Node[x + 1][y + 1])
                    myGraphics.FillEllipse(mySolidBrush, 50 + 40, 220 + 40, 10, 10);
                else
                    myGraphics.DrawEllipse(myPen, 50 + 40, 220 + 40, 10, 10);
                if (matryca_esqaro[x][y][0] < 0 || (matryca_esqaro[x][y][0]==0 && matryca_esqaro[x][y][1]==0))
                    myGraphics.DrawString("<=" + matryca_esqaro[x][y][0] * -1, font, mySolidBrush, 60, 235);
                else
                    myGraphics.DrawString(matryca_esqaro[x][y][0].ToString() + '|' + matryca_esqaro[x][y][1], font, mySolidBrush, 60, 235);
            }
            if (stworzono_tablice)
            {
                for (int i = 0; i < matryca_liczb.Count; i++)
                {
                    for (int j = 0; j < matryca_liczb.Count; j++)
                    {
                        if(matryca_liczb[i][j]>=0)
                            myGraphics.DrawString(matryca_liczb[i][j].ToString(), font, mySolidBrush, 790 + 40 * i, 115 + 40 * j);
                    }
                }
                for (int i = 0; i < matryca_liczb.Count + 1; i++)
                {
                    for (int j = 0; j < matryca_liczb.Count + 1; j++)
                    {
                        myGraphics.FillEllipse(mySolidBrush, 770 + 40 * i, 100 + 40 * j, 10, 10);
                    }
                }
                for (int i = 0; i < matryca_polonczen.Count; i++)
                {
                    for (int j = 0; j < matryca_polonczen.Count; j++)
                    {
                        if((i+j)%2==1)
                            if(matryca_polonczen[i][j])
                                if(i%2==1)
                                    myGraphics.DrawLine(myPen, 755 + 20 * i, 105 + 20 * j, 795 + 20 * i, 105 + 20 * j);
                                else
                                    myGraphics.DrawLine(myPen, 775 + 20 * i, 85 + 20 * j, 775 + 20 * i, 125 + 20 * j);
                    }
                }
                myGraphics.FillEllipse(mySolidBrush, 670, 270, 10, 10);
                myGraphics.FillEllipse(mySolidBrush, 670 + 40, 270, 10, 10);
                myGraphics.FillEllipse(mySolidBrush, 670, 270 + 40, 10, 10);
                myGraphics.FillEllipse(mySolidBrush, 670 + 40, 270 + 40, 10, 10);

                int x = (int)numericUpDown9.Value - 1;
                int y = (int)numericUpDown10.Value - 1;

                if (matryca_liczb[x][y] >= 0)
                    myGraphics.DrawString(matryca_liczb[x][y].ToString(), font, mySolidBrush, 690, 285);

                if (matryca_polonczen[x * 2 + 1][y * 2])
                    myGraphics.DrawLine(myPen, 675 , 275, 715, 275);
                if (matryca_polonczen[x * 2 + 1][y * 2 + 2])
                    myGraphics.DrawLine(myPen, 675, 315, 715, 315);
                if (matryca_polonczen[x * 2][y * 2 + 1])
                    myGraphics.DrawLine(myPen, 675, 275 , 675, 315);
                if (matryca_polonczen[x * 2 + 2][y * 2 + 1])
                    myGraphics.DrawLine(myPen, 715, 275, 715, 315);
            }
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
            if(stworzono_tablice)
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
            rysuj_matryce();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown9.Value > szerokosc_tablicy)
            {
                numericUpDown9.Value = szerokosc_tablicy;
            }
            rysuj_matryce();
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown10.Value > szerokosc_tablicy)
            {
                numericUpDown10.Value = szerokosc_tablicy;
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
            if(stworzono_tablice)
                do_esqaro();
            rysuj_matryce();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown9.Value - 1;
            int y = (int)numericUpDown10.Value - 1;
            if (stworzono_tablice)
                matryca_polonczen[1+x*2][y*2] = !matryca_polonczen[1 + x * 2][y * 2];
            rysuj_matryce();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown9.Value - 1;
            int y = (int)numericUpDown10.Value - 1;
            if (stworzono_tablice)
                matryca_polonczen[1 + x * 2][2 + y * 2] = !matryca_polonczen[1 + x * 2][2 + y * 2];
            rysuj_matryce();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown9.Value - 1;
            int y = (int)numericUpDown10.Value - 1;
            if (stworzono_tablice)
                matryca_polonczen[x * 2][1 + y * 2] = !matryca_polonczen[x * 2][1 + y * 2];
            rysuj_matryce();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int x = (int)numericUpDown9.Value - 1;
            int y = (int)numericUpDown10.Value - 1;
            if (stworzono_tablice)
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
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------Funkcje zwracające Tablice CellType-----------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------
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
                                tablica[i][j] = E_squaro.CellType.KLESS0;
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
            for (int i = 0; i < szerokosc_esqaro + 1; i++)
                for (int j = 0; j < szerokosc_esqaro + 1; j++)
                    matryca_esqaro_Node[i][j] = lista[szerokosc_esqaro*i+j];
        }
        
        //------------------------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------Przycisk Działania-----------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------------------------

        private void button14_Click(object sender, EventArgs e)
        {
            if (stworzono_tablice)
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

                OutputConverter OC = new OutputConverter(ESM, wynik);

                Z_Listy_Bool(OC.Convert());
                if (stworzono_esqaro)
                    Z_esqaro();
            }
            rysuj_matryce();
        }
    }
}
