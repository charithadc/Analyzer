using Analyzer.Data.CSQL.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analyzer.Data.Excel;

namespace Analyzer.Data.CSQL
{
    public class DAOImpl
    {
        //add this to top of the DBContext each time generate it
        //using SqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices;

        public void TruncateTable(TableNames tableNames)
        {
            using (var db = new AnalyzerDBContext())
            {
                switch (tableNames)
                {
                    case TableNames.T_EPS:
                        db.Database.ExecuteSqlCommand("TRUNCATE TABLE [AnalyzerDB].[dbo].[T_EPS]");
                        break;
                    case TableNames.T_EPS_Audited:
                        db.Database.ExecuteSqlCommand("TRUNCATE TABLE [AnalyzerDB].[dbo].[T_EPS_Audited]");
                        break;
                    case TableNames.T_Price:
                        db.Database.ExecuteSqlCommand("TRUNCATE TABLE [AnalyzerDB].[dbo].[T_Price]");
                        break;
                    case TableNames.All:
                        db.Database.ExecuteSqlCommand("TRUNCATE TABLE [AnalyzerDB].[dbo].[T_Price]");
                        db.Database.ExecuteSqlCommand("TRUNCATE TABLE [AnalyzerDB].[dbo].[T_EPS]");
                        db.Database.ExecuteSqlCommand("TRUNCATE TABLE [AnalyzerDB].[dbo].[T_EPS_Audited]");
                        break;
                }
            }
        }

        public void SetRange(TableNames tableNames, int startYear, int startQuarter, int endYear, int endQuarter)
        {

            switch (tableNames)
            {
                case TableNames.T_EPS:
                    SetRangeForEPS(startYear, startQuarter, endYear, endQuarter);
                    break;
                case TableNames.T_EPS_Audited:
                    SetRangeForEPSAudited(startYear, startQuarter, endYear, endQuarter);
                    break;
                case TableNames.T_Price:
                    SetRangeForPrice(startYear, startQuarter, endYear, endQuarter);
                    break;
                case TableNames.All:

                    break;
            }

        }

        private void SetRangeForPrice(int startYear, int startQuarter, int endYear, int endQuarter)
        {
            using (var db = new AnalyzerDBContext())
            {
                bool firstTime = true;
                for (int i = startYear; i <= endYear; i++)
                {
                    for (int j = 1; j <= 4; j++)
                    {

                        if (firstTime)
                        {
                            firstTime = false;
                            j = startQuarter;
                        }
                        var priceItem = new T_Price
                        {
                            Year = i,
                            Quarter = j,
                        };
                        db.T_Price.Add(priceItem);
                        if (i == endYear && j == endQuarter)
                        {
                            break;
                        }
                    }

                }
                db.SaveChanges();
            }
        }

        private void SetRangeForEPS(int startYear, int startQuarter, int endYear, int endQuarter)
        {
            using (var db = new AnalyzerDBContext())
            {
                bool firstTime = true;
                for (int i = startYear; i <= endYear; i++)
                {
                    for (int j = 1; j <= 4; j++)
                    {

                        if (firstTime)
                        {
                            firstTime = false;
                            j = startQuarter;
                        }
                        var epsItem = new T_EPS
                        {
                            Year = i,
                            Quarter = j,
                        };
                        db.T_EPS.Add(epsItem);
                        if (i == endYear && j == endQuarter)
                        {
                            break;
                        }
                    }

                }
                db.SaveChanges();
            }
        }

        private void SetRangeForEPSAudited(int startYear, int startQuarter, int endYear, int endQuarter)
        {
            using (var db = new AnalyzerDBContext())
            {
                bool firstTime = true;
                for (int i = startYear; i <= endYear; i++)
                {
                    for (int j = 1; j <= 4; j++)
                    {

                        if (firstTime)
                        {
                            firstTime = false;
                            j = startQuarter;
                        }
                        var epsAuditedItem = new T_EPS_Audited
                        {
                            Year = i,
                            Quarter = j,
                        };
                        db.T_EPS_Audited.Add(epsAuditedItem);
                        if (i == endYear && j == endQuarter)
                        {
                            break;
                        }
                    }

                }
                db.SaveChanges();
            }
        }

        public void TestDB()
        {
            using (var db = new AnalyzerDBContext())
            {

                //Create and save a new Student

                //Console.Write("Enter a name for a new Student: ");
                //var firstName = Console.ReadLine();

                var priceItem = new T_Price
                {
                    Year = 2016,
                    Quarter = 1,
                   // COCR = 1.55,
                    //PARQ = 1.03m,
                    //LALU = 1.45m

                };

                db.T_Price.Add(priceItem);
                db.SaveChanges();

                var query = from b in db.T_Price
                            select b;

                Console.WriteLine("All student in the database:");

                foreach (var item in query)
                {
                    Console.WriteLine(item.COCR);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }

        public void PopulateFromExcel(TableNames tableNames, int startYear, int startQuarter, int endYear, int endQuarter)
        {
            if (tableNames == TableNames.All)
            {
                this.PopulateFromExcel(TableNames.T_EPS, startYear, startQuarter, endYear, endQuarter);
                this.PopulateFromExcel(TableNames.T_EPS_Audited, startYear, startQuarter, endYear, endQuarter);
                this.PopulateFromExcel(TableNames.T_Price, startYear, startQuarter, endYear, endQuarter);
                return;
            }
            TruncateTable(tableNames);
            SetRange(tableNames, startYear, startQuarter, endYear, endQuarter);
            switch (tableNames)
            {
                case TableNames.T_EPS:
                    UpdateEPSFromExcel();
                    break;
                case TableNames.T_EPS_Audited:
                    UpdateEPSAuditedFromExcel();
                    break;
                case TableNames.T_Price:
                    UpdatePriceFromExcel();
                    break;
            }
        }

        public void UpdatePriceFromExcel()
        {
            string path = @"C:\Projects\Analyzer\trunk\Analyzer\TestFiles\original - Copy.xlsx";
            if (File.Exists(path))
            {
                CExcelFile excelObject = new CExcelFile(path);
                excelObject.Open();
                if (excelObject.IsExcelOpen)
                {
                    try
                    {
                        //double x = excelObject.Worksheet.Cells[9, 4].Value;
                        
                        using (var db = new AnalyzerDBContext())
                        {
                            var query = from b in db.T_Price
                                        orderby b.Year descending, b.Quarter descending
                                        select b;
                            List<T_Price> pirceLst = query.ToList();
                            int i = 4;
                            foreach (var item in pirceLst)
                            {
                                int j = 9;
                                item.COCR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.PARQ = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LALU = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.REXP = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CCS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.KDL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SOY = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HHL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SEYB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CDB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LFIN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LWL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CIND = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DIPD = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LOLC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.NDB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ACL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SAMP = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TPL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CFIN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.RCL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DIMO = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BLI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.REG = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ALUF = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ARPI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HDFC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.COLO = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.VFIN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.PMB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CRL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TJL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.GRAN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TAFL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.UML = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HAYL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AAIC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HNB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BRWN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CIC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DIST = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LION = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LGL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.NTB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DFCC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SUN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LLUB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TYRE = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ASIR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CARG = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LHCL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BFL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.NEST = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.GUAR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CTC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.KAPI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.JKH= excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LIOC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CLND = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AHUN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TKYO = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SPEN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.COMB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.MELS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SLTL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CTHR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CARS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CINS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AEL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BUKI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AHPL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SINS = excelObject.Worksheet.Cells[j, i].Value;
                                

                                Console.WriteLine(string.Format("{0}-{1} Price Completed",item.Year,item.Quarter));
                                i++;
                            }
                            db.SaveChanges();
                        }
                        excelObject.Close();
                    }
                    catch (Exception ee)
                    {
                        excelObject.Close();
                    }
                }
                ;
            }
        }

        public void UpdateEPSFromExcel()
        {
            string path = @"C:\Projects\Analyzer\trunk\Analyzer\TestFiles\original - Copy.xlsx";
            if (File.Exists(path))
            {
                CExcelFile excelObject = new CExcelFile(path);
                excelObject.Open();
                if (excelObject.IsExcelOpen)
                {
                    try
                    {
                        //double x = excelObject.Worksheet.Cells[9, 4].Value;

                        using (var db = new AnalyzerDBContext())
                        {
                            var query = from b in db.T_EPS
                                        orderby b.Year descending, b.Quarter descending
                                        select b;
                            List<T_EPS> pirceLst = query.ToList();
                            int i = 4;
                            foreach (var item in pirceLst)
                            {
                                int j = 2;
                                item.COCR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.PARQ = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LALU = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.REXP = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CCS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.KDL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SOY = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HHL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SEYB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CDB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LFIN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LWL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CIND = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DIPD = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LOLC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.NDB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ACL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SAMP = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TPL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CFIN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.RCL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DIMO = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BLI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.REG = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ALUF = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ARPI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HDFC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.COLO = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.VFIN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.PMB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CRL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TJL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.GRAN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TAFL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.UML = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HAYL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AAIC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HNB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BRWN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CIC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DIST = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LION = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LGL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.NTB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DFCC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SUN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LLUB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TYRE = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ASIR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CARG = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LHCL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BFL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.NEST = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.GUAR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CTC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.KAPI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.JKH = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LIOC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CLND = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AHUN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TKYO = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SPEN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.COMB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.MELS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SLTL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CTHR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CARS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CINS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AEL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BUKI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AHPL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SINS = excelObject.Worksheet.Cells[j, i].Value;


                                Console.WriteLine(string.Format("{0}-{1} EPS Completed", item.Year, item.Quarter));
                                i++;
                            }
                            db.SaveChanges();
                        }
                        excelObject.Close();
                    }
                    catch (Exception ee)
                    {
                        excelObject.Close();
                    }
                }
                ;
            }
        }

        public void UpdateEPSAuditedFromExcel()
        {
            string path = @"C:\Projects\Analyzer\trunk\Analyzer\TestFiles\original - Copy.xlsx";
            if (File.Exists(path))
            {
                CExcelFile excelObject = new CExcelFile(path);
                excelObject.Open();
                if (excelObject.IsExcelOpen)
                {
                    try
                    {
                        //double x = excelObject.Worksheet.Cells[9, 4].Value;

                        using (var db = new AnalyzerDBContext())
                        {
                            var query = from b in db.T_EPS_Audited
                                        orderby b.Year descending, b.Quarter descending
                                        select b;
                            List<T_EPS_Audited> pirceLst = query.ToList();
                            int i = 4;
                            foreach (var item in pirceLst)
                            {
                                int j = 3;
                                item.COCR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.PARQ = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LALU = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.REXP = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CCS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.KDL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SOY = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HHL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SEYB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CDB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LFIN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LWL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CIND = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DIPD = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LOLC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.NDB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ACL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SAMP = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TPL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CFIN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.RCL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DIMO = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BLI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.REG = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ALUF = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ARPI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HDFC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.COLO = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.VFIN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.PMB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CRL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TJL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.GRAN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TAFL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.UML = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HAYL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AAIC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.HNB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BRWN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CIC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DIST = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LION = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LGL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.NTB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.DFCC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SUN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LLUB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TYRE = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.ASIR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CARG = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LHCL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BFL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.NEST = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.GUAR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CTC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.KAPI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.JKH = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.LIOC = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CLND = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AHUN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.TKYO = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SPEN = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.COMB = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.MELS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SLTL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CTHR = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CARS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.CINS = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AEL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.BUKI = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.AHPL = excelObject.Worksheet.Cells[j, i].Value;
                                j = j + 14;
                                item.SINS = excelObject.Worksheet.Cells[j, i].Value;


                                Console.WriteLine(string.Format("{0}-{1} EPS Audited Completed", item.Year, item.Quarter));
                                i++;
                            }
                            db.SaveChanges();
                        }
                        excelObject.Close();
                    }
                    catch (Exception ee)
                    {
                        excelObject.Close();
                    }
                }
                ;
            }
        }
    }

    public enum TableNames { T_Price, T_EPS, T_EPS_Audited, All }
}
