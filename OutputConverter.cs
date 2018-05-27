using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_squaro
{
    public class OutputConverter
    {
        public ESquarMatrix es;
        public List<int> list = new List<int>();

        public OutputConverter(ESquarMatrix ess, List<String> lis_str) { 
            es = ess;
            foreach(var s in lis_str)
            {
                int pom = Int32.Parse(s);
                list.Add(pom);
            }
        }

        public List<bool> Convert()
        {
            List<bool> list_bool = new List<bool>();
            List<int> lis_in = new List<int>();
            int col = es.cols;
            int row = es.rows;
            
            for(int i=0; i<row; i++)
            {
                for(int j=0; j<col; j++)
                {
                    Cell cell=es.GetCell(j,i);
                    if(i==row-1 && j==0) {
                        int a = cell.NodeA;
                        int b = cell.NodeB;
                        int c = cell.NodeC;
                        int d = cell.NodeD;
                        lis_in.Add(a);
                        lis_in.Add(b);
                        lis_in.Add(c);
                        lis_in.Add(d);
                    }
                    else if (i == row - 1 && j != 0)
                    {
                        int b = cell.NodeB;
                        int d = cell.NodeD;
                        lis_in.Add(b);
                        lis_in.Add(d);
                    }
                    else if (j == 0)
                    {
                        int a = cell.NodeA;
                        int b = cell.NodeB;
                        lis_in.Add(a);
                        lis_in.Add(b);
                    }
                    else
                    {
                        int b = cell.NodeB;
                        lis_in.Add(b);
                    }
                }
            }

            int pom = 0;
            bool pom_bo = false;
            for (int i = 0; i < lis_in.Count(); i++)
            {
                    pom_bo = false;
                    foreach(var p in list)
                    {
                        if (p == lis_in[i]) { pom_bo = true; }
                        
                    }
                    list_bool.Add(pom_bo);
            }

            return list_bool;
        }
    }
}
