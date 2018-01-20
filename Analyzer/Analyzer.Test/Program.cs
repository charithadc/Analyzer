using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analyzer.Data.CSQL;

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
            //new DAOImpl().TestDB();
            DAOImpl impl = new DAOImpl();
            //new DAOImpl().TruncateTable(TableNames.T_Price);
            //impl.TruncateTable(TableNames.T_Price);
            // impl.SetRange(TableNames.T_Price, 2010, 2, 2015, 3);
            impl.PopulateFromExcel(TableNames.All, 2009, 1, 2017, 3);
            //impl.ReadPrice();
        }
    }
}
