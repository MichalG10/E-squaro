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

        public bool GenerateInput(List<Cell> cells)
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
            SaveInput();

            return true;
        }

        private void CreateHeader(int variables, int clauses)
        {
            RSatInput += ("c " + InputFilename + "\n");
            RSatInput += "c\n";
            RSatInput += "p cnf " + variables.ToString() + " " + clauses.ToString() + "\n";
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
        }

        public List<string> GetInterpretedOutput()
        {
            string RSatOutputLine = RSatOutput.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)[1];

            /* Return null when RunRSatSolver have not been used */
            if (RSatOutput.Length <= 1)
                return null;

            Regex MatchResult = new Regex("(UN)?SATISFIABLE");
            var match = MatchResult.Matches(RSatOutput).Cast<Match>().FirstOrDefault();

            /* Problem is unsatisfiable, any point match solution */
            if (match.Value == "UNSATISFIABLE" || match == null)
                return null;

            Regex regex = new Regex(@"(-)?[1-9][0-9]*");
            var TruePoints = regex.Matches(RSatOutputLine).Cast<Match>().Select(m => m.Value).Distinct().ToList();
            TruePoints.RemoveAll(o => o.Contains("-"));

            return TruePoints;
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
