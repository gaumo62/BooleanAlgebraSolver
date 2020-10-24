using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanAlgebraSolver
{
    class QMSolver
    {
        private int variables;
        private List<int> minterms = new List<int>();
        private List<int> dontcares = new List<int>();
        public QMSolver(int var, List<int> mint, List<int> dc)
        {
            this.variables = var;
            this.minterms = mint;
            this.dontcares = dc;
        }

        public void solve()
        {

        }
    }
}
