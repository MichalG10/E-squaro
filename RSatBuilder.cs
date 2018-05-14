using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_squaro
{

    class RSatBuilder
    {
        private string InputFilename;
        private string OutputFilename;
        private string RsatDir;

        /* Hold result of solving */
        private String RSatOutput;

        /* Hold input string */
        private String RSatInput;

        /* Convert Cells to Clauses */
        TypeInterpreter typeInterpreter;

        public RSatBuilder()
        {
            RsatDir = "../../RSat/rsat";
            InputFilename = "input.cnf";
            OutputFilename = "output.cnf";

            RSatInput = "";

            typeInterpreter = new TypeInterpreter();
        }

        public void SetInputFilename(string filename)
        {
            InputFilename = filename + ".cnf";
        }

        public void GenerateInput(List<Cell> cells)
        {
            String RuleStream = "";
            foreach(Cell cell in cells)
            {
                RuleStream += typeInterpreter.TypeToRuleConverter(cell);
            }

            int NumberOfVariables = CountVariables(RuleStream);
            int NumberOfClauses = RuleStream.Split('\n').Count() - 1;
            CreateHeader(NumberOfVariables, NumberOfClauses);

            RSatInput += RuleStream;
            Console.WriteLine(RSatInput);
            SaveInput();
        }

        public void CreateHeader(int variables, int clauses)
        {
            RSatInput += ("c " + InputFilename + "\n");
            RSatInput += "c\n";
            RSatInput += "p cnf " + variables.ToString() + " " + clauses.ToString() + "\n";
            Console.WriteLine(RSatInput);
        }

        public void RunRSatSolver()
        {
            Process RSatSolver = new Process();
            RSatSolver.StartInfo.FileName = RsatDir;

            /* Add arguments */
            string args = "../../RSat/" + InputFilename + " -s";
            RSatSolver.StartInfo.Arguments = args;
            RSatSolver.StartInfo.UseShellExecute = false;
            RSatSolver.StartInfo.CreateNoWindow = true;
            RSatSolver.StartInfo.RedirectStandardOutput = true;
            RSatSolver.Start();

            RSatOutput = RSatSolver.StandardOutput.ReadToEnd();
            Console.WriteLine(RSatOutput);
        }

        public void InterpretOutput()
        {
            // TODO
        }

        public void SaveOutput()
        {
            File.WriteAllText(OutputFilename, RSatOutput);
        }

        public void SaveInput()
        {
            string inputPath = "../../RSat/" + InputFilename;
            File.WriteAllText(inputPath, RSatInput);
        }

        private int CountVariables(String SatInput)
        {
            String TemporaryString = SatInput;
            Regex regex = new Regex(@"[1-9][0-9]*");
            var matches = regex.Matches(TemporaryString).Cast<Match>().Select(m => m.Value).Distinct().ToList();

            return matches.Distinct().Count();
        }

    }
}
