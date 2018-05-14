using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_squaro
{
    enum Direction
    {
        UP = 0,
        LEFT = 1,
        RIGHT = 2,
        DOWN = 3
    }

    class ESquarMatrix
    {
        private List<Cell> cells;

        private int cols;
        private int rows;

        private int NodeCounter;

        public ESquarMatrix(int cols, int rows)
        {
            this.cols = cols;
            this.rows = rows;

            cells = new List<Cell>(cols * rows);

            NodeCounter = 1;
        }

        public List<Cell> GetCellsList()
        {
            return cells;
        }

        public int AddCell(CellType cellType, int col, int row)
        {
            if ((col < 0 || col > cols) || (row < 1 || row > rows))
                return -1;

            Cell cell = new Cell(cellType);
            cell.SetColumn(col);
            cell.SetRow(row);
            cell.SetNodeA(-1);
            cell.SetNodeB(-1);
            cell.SetNodeC(-1);
            cell.SetNodeD(-1);

            cell = CheckNeighbourhood(cell);
            cell = FillEmptyNodes(cell);
            cells.Add(cell);

            return 0;
        }

        private Cell GetCell(int col, int row)
        {
            return cells.Where(c => c.column == col).Where(c => c.row == row).SingleOrDefault();
        }

        private Cell CheckNeighbourhood(Cell original)
        {
            Cell CenterCell = original;
            Cell NeighCell;

            // check left cell
            NeighCell = GetCell(CenterCell.column - 1, CenterCell.row);
            if (NeighCell != null)
            {
                CenterCell.SetNodeA(NeighCell.NodeB);
                CenterCell.SetNodeC(NeighCell.NodeD);
            }

            // check right cell
            NeighCell = GetCell(CenterCell.column + 1, CenterCell.row);
            if (NeighCell != null)
            {
                CenterCell.SetNodeB(NeighCell.NodeA);
                CenterCell.SetNodeD(NeighCell.NodeC);
            }

            // check up cell
            NeighCell = GetCell(CenterCell.column, CenterCell.row - 1);
            if (NeighCell != null)
            {
                CenterCell.SetNodeA(NeighCell.NodeC);
                CenterCell.SetNodeB(NeighCell.NodeD);
            }

            // check down cell
            NeighCell = GetCell(CenterCell.column, CenterCell.row + 1);
            if (NeighCell != null)
            {
                CenterCell.SetNodeC(NeighCell.NodeA);
                CenterCell.SetNodeD(NeighCell.NodeB);
            }

            return CenterCell;
        }

        private Cell FillEmptyNodes(Cell original)
        {
            Cell CenterCell = original;
            if (CenterCell.NodeA == -1) CenterCell.NodeA = NodeCounter++;
            if (CenterCell.NodeB == -1) CenterCell.NodeB = NodeCounter++;
            if (CenterCell.NodeC == -1) CenterCell.NodeC = NodeCounter++;
            if (CenterCell.NodeD == -1) CenterCell.NodeD = NodeCounter++;
            return CenterCell;
        }

    }
}
