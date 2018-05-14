using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_squaro
{
    public enum CellType
    {
        KLESS0 = 0, KLESS1 = 1, KLESS2 = 2, KLESS3 = 3, KLESS4 = 4,
        K1OVER1 = 5, K2OVER2 = 6, K3OVER3 = 7, K4OVER4 = 8,
        K0OVER2 = 9, K0OVER3 = 10, K0OVER4 = 11,
        K1OVER2 = 12, K1OVER3 = 13, K1OVER4 = 14,
        K2OVER3 = 15, K2OVER4 = 16,
        K3OVER4 = 17
    }

    /*  K - type cell
     *  
     *  (a) - - - (b)
     *   |         |
     *   |         |
     *  (c) - - - (d)
     */

    public class Cell
    {
        public CellType type;

        public int column;
        public int row;

        public int NodeA;
        public int NodeB;
        public int NodeC;
        public int NodeD;

        public Cell(CellType type)
        {
            this.type = type;
        }

        public void SetColumn(int column) { this.column = column; }
        public void SetRow(int row) { this.row = row; }

        public void SetNodeA(int node_a) { this.NodeA = node_a; }
        public void SetNodeB(int node_b) { this.NodeB = node_b; }
        public void SetNodeC(int node_c) { this.NodeC = node_c; }
        public void SetNodeD(int node_d) { this.NodeD = node_d; }
    }
}
