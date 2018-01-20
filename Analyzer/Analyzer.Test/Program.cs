using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analyzer.Business;

namespace Analyzer.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            EnterData();
        }

        static void EnterData()
        {
            Manager mgr = new Manager();
            mgr.PopulateFromExcel();
        }
    }
}
