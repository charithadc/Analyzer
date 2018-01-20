using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Business.MatricCalc
{
    public class StackDataRepo
    {
        //first is row and second is column
        //latest data is in earliyar rows
        double?[,] DataArr;

        public int StartYear { get; private set; }
        public int StartQuarter { get; private set; }
        public int EndYear { get; private set; }
        public int EndQuarter { get; private set; }

        public StackDataRepo(int startYear, int startQuarter, int endYear, int endQuarter)
        {
            int noOfQuarters = GetNoOfQuarters( startYear,startQuarter,endYear,endQuarter);
            DataArr = new double?[noOfQuarters, 72];
            InitArray();
            this.StartYear = startYear;
            this.StartQuarter = startQuarter;
            this.EndYear = endYear;
            this.EndQuarter = endQuarter;
        }

        public StackDataRepo GetEmptyDataRepo()
        {
            StackDataRepo repo = new StackDataRepo(StartYear, StartQuarter, EndYear, EndQuarter);
            return repo;
        }

        public StackDataRepo(StackDatedDataRepo[] stackRepo)
        {
            int noOfQuarters = GetNoOfQuarters(stackRepo[stackRepo.Length-1].Year, stackRepo[stackRepo.Length - 1].Quarter, stackRepo[0].Year, stackRepo[0].Quarter);
            DataArr = new double?[noOfQuarters, 72];
            InitArray();
            PopulateArr(stackRepo);
            this.StartYear = stackRepo[stackRepo.Length - 1].Year;
            this.StartQuarter = stackRepo[stackRepo.Length - 1].Quarter;
            this.EndYear = stackRepo[0].Year;
            this.EndQuarter = stackRepo[0].Quarter;
        }

        private void PopulateArr(StackDatedDataRepo[] stackRepo)
        {
            for (int i = 0; i < stackRepo.Length; i++)
            {
                int j = 0;
                DataArr[i, j] = stackRepo[i].COCR;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].PARQ;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].LALU;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].REXP;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CCS;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].KDL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].SOY;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].HHL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].SEYB;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CDB;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].LFIN;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].LWL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CIND;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].DIPD;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].LOLC;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].NDB;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].ACL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].SAMP;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].TPL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CFIN;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].RCL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].DIMO;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].BLI;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].REG;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].ALUF;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].ARPI;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].HDFC;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].COLO;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].VFIN;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].PMB;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CRL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].TJL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].GRAN;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].TAFL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].UML;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].HAYL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].AAIC;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].HNB;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].BRWN;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CIC;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].DIST;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].LION;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].LGL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].NTB;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].DFCC;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].SUN;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].LLUB;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].TYRE;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].ASIR;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CARG;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].LHCL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].BFL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].NEST;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].GUAR;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CTC;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].KAPI;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].JKH;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].LIOC;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CLND;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].AHUN;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].TKYO;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].SPEN;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].COMB;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].MELS;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].SLTL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CTHR;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CARS;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].CINS;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].AEL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].BUKI;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].AHPL;
                j = j + 1;
                DataArr[i, j] = stackRepo[i].SINS;
            }
        }

        private void GetStackDatedDataArr()
        {
            StackDatedDataRepo[] stackRepo = new StackDatedDataRepo[DataArr.GetLength(0)];
            int CurrentYear = EndYear;
            int CurrentQuarter = EndQuarter;
            for (int i = 0; i < stackRepo.Length; i++)
            {
                StackDatedDataRepo repo = new StackDatedDataRepo();
                repo.Year = CurrentYear;
                repo.Quarter = CurrentQuarter;
                if(CurrentQuarter == 1)
                {
                    CurrentQuarter = 4;
                    CurrentYear--;
                }
                else
                {
                    CurrentQuarter--;
                }
                int j = 0;
                repo.COCR = DataArr[i, j];
                j = j + 1;
                repo.PARQ = DataArr[i, j];
                j = j + 1;
                repo.LALU = DataArr[i, j];
                j = j + 1;
                repo.REXP = DataArr[i, j];
                j = j + 1;
                repo.CCS = DataArr[i, j];
                j = j + 1;
                repo.KDL = DataArr[i, j];
                j = j + 1;
                repo.SOY = DataArr[i, j];
                j = j + 1;
                repo.HHL = DataArr[i, j];
                j = j + 1;
                repo.SEYB = DataArr[i, j];
                j = j + 1;
                repo.CDB = DataArr[i, j];
                j = j + 1;
                repo.LFIN = DataArr[i, j];
                j = j + 1;
                repo.LWL = DataArr[i, j];
                j = j + 1;
                repo.CIND = DataArr[i, j];
                j = j + 1;
                repo.DIPD = DataArr[i, j];
                j = j + 1;
                repo.LOLC = DataArr[i, j];
                j = j + 1;
                repo.NDB = DataArr[i, j];
                j = j + 1;
                repo.ACL = DataArr[i, j];
                j = j + 1;
                repo.SAMP = DataArr[i, j];
                j = j + 1;
                repo.TPL = DataArr[i, j];
                j = j + 1;
                repo.CFIN = DataArr[i, j];
                j = j + 1;
                repo.RCL = DataArr[i, j];
                j = j + 1;
                repo.DIMO = DataArr[i, j];
                j = j + 1;
                repo.BLI = DataArr[i, j];
                j = j + 1;
                repo.REG = DataArr[i, j];
                j = j + 1;
                repo.ALUF = DataArr[i, j];
                j = j + 1;
                repo.ARPI = DataArr[i, j];
                j = j + 1;
                repo.HDFC = DataArr[i, j];
                j = j + 1;
                repo.COLO = DataArr[i, j];
                j = j + 1;
                repo.VFIN = DataArr[i, j];
                j = j + 1;
                repo.PMB = DataArr[i, j];
                j = j + 1;
                repo.CRL = DataArr[i, j];
                j = j + 1;
                repo.TJL = DataArr[i, j];
                j = j + 1;
                repo.GRAN = DataArr[i, j];
                j = j + 1;
                repo.TAFL = DataArr[i, j];
                j = j + 1;
                repo.UML = DataArr[i, j];
                j = j + 1;
                repo.HAYL = DataArr[i, j];
                j = j + 1;
                repo.AAIC = DataArr[i, j];
                j = j + 1;
                repo.HNB = DataArr[i, j];
                j = j + 1;
                repo.BRWN = DataArr[i, j];
                j = j + 1;
                repo.CIC = DataArr[i, j];
                j = j + 1;
                repo.DIST = DataArr[i, j];
                j = j + 1;
                repo.LION = DataArr[i, j];
                j = j + 1;
                repo.LGL = DataArr[i, j];
                j = j + 1;
                repo.NTB = DataArr[i, j];
                j = j + 1;
                repo.DFCC = DataArr[i, j];
                j = j + 1;
                repo.SUN = DataArr[i, j];
                j = j + 1;
                repo.LLUB = DataArr[i, j];
                j = j + 1;
                repo.TYRE = DataArr[i, j];
                j = j + 1;
                repo.ASIR = DataArr[i, j];
                j = j + 1;
                repo.CARG = DataArr[i, j];
                j = j + 1;
                repo.LHCL = DataArr[i, j];
                j = j + 1;
                repo.BFL = DataArr[i, j];
                j = j + 1;
                repo.NEST = DataArr[i, j];
                j = j + 1;
                repo.GUAR = DataArr[i, j];
                j = j + 1;
                repo.CTC = DataArr[i, j];
                j = j + 1;
                repo.KAPI = DataArr[i, j];
                j = j + 1;
                repo.JKH = DataArr[i, j];
                j = j + 1;
                repo.LIOC = DataArr[i, j];
                j = j + 1;
                repo.CLND = DataArr[i, j];
                j = j + 1;
                repo.AHUN = DataArr[i, j];
                j = j + 1;
                repo.TKYO = DataArr[i, j];
                j = j + 1;
                repo.SPEN = DataArr[i, j];
                j = j + 1;
                repo.COMB = DataArr[i, j];
                j = j + 1;
                repo.MELS = DataArr[i, j];
                j = j + 1;
                repo.SLTL = DataArr[i, j];
                j = j + 1;
                repo.CTHR = DataArr[i, j];
                j = j + 1;
                repo.CARS = DataArr[i, j];
                j = j + 1;
                repo.CINS = DataArr[i, j];
                j = j + 1;
                repo.AEL = DataArr[i, j];
                j = j + 1;
                repo.BUKI = DataArr[i, j];
                j = j + 1;
                repo.AHPL = DataArr[i, j];
                j = j + 1;
                repo.SINS = DataArr[i, j];
            }
        }

        private void InitArray()
        {
            for (int i = 0; i < DataArr.GetLength(0); i++)
            {
                for (int j = 0; j < DataArr.GetLength(1); j++)
                {
                    DataArr[i, j] = null;
                }
            }
        }

        public int GetNoOfQuarters(int startYear, int startQuarter, int endYear, int endQuarter)
        {
            int noOfYrs = endYear - startYear;
            int difQuarters = endQuarter - startQuarter;
            int noOfQuarters = (noOfYrs * 4) + difQuarters+1;
            return noOfQuarters;
        }

    }
}
