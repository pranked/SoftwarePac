using System.Linq;
using System.Text.RegularExpressions;

namespace SoftwarePac.Procurement.Engine
{
    public abstract class Step
    {
        public abstract void OnArgs(string[] args);

        /// <summary>
        /// Run this step
        /// </summary>
        /// <param name="engine">Parent engine object</param>
        public abstract void OnRun(Factory engine);
    }
}