using System;
using System.Diagnostics;

namespace SoftwarePac.Procurement.Engine.Steps
{
    internal class Exec : Step
    {
        private string[] args;
        public override void OnArgs(string[] args)
        {
            this.args = args;
        }

        public override void OnRun(Factory eng)
        {
            var opt = new OptionSet
            {
                {"v|verb=", "verbage", v => Console.WriteLine(v)},
            };
            var extra = opt.Parse(args);
            var info = new ProcessStartInfo { FileName = extra[0].Replace("/", "\\") };
            var p = eng.StartProcess(info);
            p.WaitForExit();
        }
    }
}