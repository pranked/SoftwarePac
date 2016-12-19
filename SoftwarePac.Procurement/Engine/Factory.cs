using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using SoftwarePac.Procurement.Engine.Steps;

namespace SoftwarePac.Procurement.Engine
{
    public class Factory
    {
        private List<Software> software;
        private Queue<Step> steps;
        private static Regex regex = new Regex(@"[\'\""](.+?)[\'\""]|([^ ]+)");

        private static Dictionary<string, Type> Actions = new Dictionary<string, Type>
        {
            {"exec", typeof(Exec)}
        };

        public Factory(List<Software> software)
        {
            this.software = software;
            steps = new Queue<Step>();
        }

        public void Install()
        {
            prep();
            while (steps.Count > 0)
            {
                steps.Dequeue().OnRun(this);
            }
        }

        private void prep()
        {
            foreach (var sf in software)
            {
                foreach (var sfStep in sf.Steps)
                {
                    var i = sfStep.IndexOf(" ");
                    var command = sfStep.Substring(0, i);
                    var args = regex.Matches(sfStep.Substring(i + 1))
                        .Cast<Match>()
                        .Select(m => m.Groups[1].Value == "" ? m.Groups[2].Value : m.Groups[1].Value).ToArray();
                    steps.Enqueue(ToStep(command, args));
                }
            }
        }

        private static Step ToStep(string command, string[] args)
        {
            Step step = null;
            if (Actions.ContainsKey(command))
                step = (Step)Activator.CreateInstance(Actions[command]);
            if (step == null)
                return null;
            if (args.Length > 0)
                step.OnArgs(args);
            return step;
        }

        public Process StartProcess(ProcessStartInfo inf)
        {
            var p = Process.Start(inf);
            return p;
        }
    }
}