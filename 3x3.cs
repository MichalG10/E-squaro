using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Windows;


namespace E_squaro
{
    class _3x3
    {
        List<CellType> list = new List<CellType>(new CellType[] { CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0,
        CellType.KLESS0,CellType.KLESS0,CellType.KLESS0, CellType.KLESS1, CellType.K0OVER2, CellType.KLESS1, CellType.KLESS0,CellType.KLESS0,CellType.KLESS0,
        CellType.KLESS0, CellType.KLESS0, CellType.KLESS1, CellType.K0OVER2, CellType.KLESS3, CellType.K0OVER2, CellType.KLESS1, CellType.KLESS0, CellType.KLESS0,
        CellType.KLESS0, CellType.KLESS1, CellType.K0OVER2, CellType.KLESS3, CellType.K0OVER2, CellType.KLESS3, CellType.K0OVER2, CellType.KLESS1, CellType.KLESS0,
        CellType.KLESS0, CellType.K0OVER2, CellType.KLESS3, CellType.K0OVER2, CellType.KLESS3, CellType.K0OVER2, CellType.KLESS3, CellType.K0OVER2, CellType.KLESS0,
        CellType.KLESS0, CellType.KLESS1, CellType.K0OVER2, CellType.KLESS3, CellType.K0OVER2, CellType.KLESS3, CellType.K0OVER2, CellType.KLESS1, CellType.KLESS0,
        CellType.KLESS0, CellType.KLESS0, CellType.KLESS1, CellType.K0OVER2, CellType.KLESS3, CellType.K0OVER2, CellType.KLESS1, CellType.KLESS0, CellType.KLESS0,
        CellType.KLESS0,CellType.KLESS0,CellType.KLESS0, CellType.KLESS1, CellType.K0OVER2, CellType.KLESS1, CellType.KLESS0,CellType.KLESS0,CellType.KLESS0,
        CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0, CellType.KLESS0,});

        ESquarMatrix esm;

        public _3x3(CellType[,] ct)
        {
            ESquarMatrix esm = new ESquarMatrix(9, 9);
            this.Fill(esm, ct);
        }

        public ESquarMatrix Fill(ESquarMatrix es, CellType[,] ct)
        {
            int i = 0, j = 0, z = 0 ;

            try
            {
                for (i = 0; i < 9; i++)
                {
                    for (j = 0; j < 9; j++)
                    {
                        if (z == 12) { es.AddCell(ct[0, 0], i, j); }
                        else if (z == 20) { es.AddCell(ct[0, 1], i, j); }
                        else if (z == 22) { es.AddCell(ct[0, 2], i, j); }
                        else if (z == 26) { es.AddCell(ct[1, 0], i, j); }
                        else if (z == 28) { es.AddCell(ct[1, 1], i, j); }
                        else if (z == 30) { es.AddCell(ct[1, 2], i, j); }
                        else if (z == 34) { es.AddCell(ct[2, 0], i, j); }
                        else if (z == 36) { es.AddCell(ct[2, 1], i, j); }
                        else if (z == 42) { es.AddCell(ct[2, 2], i, j); }
                        else { es.AddCell(list[z], i, j); }
                    }
                    j = 0;
                }
            }
            catch (Exception ex) { }
            return es;
        }
    }
}
