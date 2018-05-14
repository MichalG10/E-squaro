using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_squaro
{
    public class TypeInterpreter
    {
        public string TypeToRuleConverter(Cell cell)
        {
            string rule = "unsupported";

            switch (cell.type)
            {
                case CellType.KLESS0:
                    rule = KLESS0Rule(cell);
                    break;
                case CellType.KLESS1:
                    rule = KLESS1Rule(cell);
                    break;
                case CellType.KLESS2:
                    rule = KLESS2Rule(cell);
                    break;
                case CellType.KLESS3:
                    rule = KLESS3Rule(cell);
                    break;
                case CellType.KLESS4:
                    rule = "";
                    break;
                case CellType.K1OVER1:
                    rule = K1OVER1Rule(cell);
                    break;
                case CellType.K2OVER2:
                    rule = K2OVER2Rule(cell);
                    break;
                case CellType.K3OVER3:
                    rule = K3OVER3Rule(cell);
                    break;
                case CellType.K4OVER4:
                    rule = K4OVER4Rule(cell);
                    break;
                case CellType.K0OVER2:
                    rule = K0OVER2Rule(cell);
                    break;
                case CellType.K0OVER3:
                    rule = K0OVER3Rule(cell);
                    break;
                case CellType.K0OVER4:
                    rule = K0OVER4Rule(cell);
                    break;
                case CellType.K1OVER2:
                    rule = K1OVER2Rule(cell);
                    break;
                case CellType.K1OVER3:
                    rule = K1OVER3Rule(cell);
                    break;
                case CellType.K1OVER4:
                    rule = K1OVER4Rule(cell);
                    break;
                case CellType.K2OVER3:
                    rule = K2OVER3Rule(cell);
                    break;
                case CellType.K2OVER4:
                    rule = K2OVER4Rule(cell);
                    break;
                case CellType.K3OVER4:
                    rule = K3OVER4Rule(cell);
                    break;
                default:
                    break;
            }

            return rule;
        }

        private string K3OVER4Rule(Cell cell)
        {
            string rule = "";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K2OVER4Rule(Cell cell)
        {
            string rule = "";
            rule += cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";

            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K2OVER3Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K1OVER4Rule(Cell cell)
        {
            string rule = "";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";

            rule += cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " -" + cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " -" + cell.NodeA.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeC.ToString() + " -" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " 0\n";
            rule += cell.NodeC.ToString() + " -" + cell.NodeA.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeC.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeD.ToString() + " -" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " 0\n";
            rule += cell.NodeD.ToString() + " -" + cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeD.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " 0\n";

            return rule;
        }

        private string K1OVER3Rule(Cell cell)
        {
            string rule = "";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K1OVER2Rule(Cell cell)
        {
            string rule = "";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K0OVER4Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";

            rule += cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K0OVER3Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " " + cell.NodeA.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " " + cell.NodeA.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeC.ToString() + " " + cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " 0\n";
            rule += "-" + cell.NodeC.ToString() + " " + cell.NodeA.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeC.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeD.ToString() + " " + cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " 0\n";
            rule += "-" + cell.NodeD.ToString() + " " + cell.NodeA.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeD.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " 0\n";

            return rule;
        }

        private string K0OVER2Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            rule += "-" + cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString()
                + " " + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K4OVER4Rule(Cell cell)
        {
            string rule = "";
            rule += cell.NodeA.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " 0\n";
            rule += cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K3OVER3Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString()
                + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K2OVER2Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeA.ToString() + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += cell.NodeB.ToString() + " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string K1OVER1Rule(Cell cell)
        {
            string rule = "";
            rule += cell.NodeA.ToString() + " " + cell.NodeB.ToString() +
                " " + cell.NodeC.ToString() + " " + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string KLESS0Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " 0\n";
            rule += "-" + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string KLESS1Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string KLESS2Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";
            rule += "-" + cell.NodeB.ToString() + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

        private string KLESS3Rule(Cell cell)
        {
            string rule = "";
            rule += "-" + cell.NodeA.ToString() + " -" + cell.NodeB.ToString() 
                + " -" + cell.NodeC.ToString() + " -" + cell.NodeD.ToString() + " 0\n";

            return rule;
        }

    }
}
