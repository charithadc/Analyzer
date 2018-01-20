using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analyzer.Data.CSQL;
using Analyzer.Data.CSQL.EntityFramework;
using Analyzer.Business.MatricCalc;

namespace Analyzer.Business
{
    public class Manager
    {
        public void PopulateFromExcel()
        {
            DAOImpl impl = new DAOImpl();
            impl.PopulateFromExcel(TableNames.All, 2009, 1, 2017, 3);
        }

        public StackDatedDataRepo[] GetPrice()
        {
            DAOImpl impl = new DAOImpl();
            List<T_Price> priceLst =  impl.GetPriceFromDB();
            return GetDataRepoByPrice(priceLst);
        }
        public StackDatedDataRepo[] GetEPS()
        {
            DAOImpl impl = new DAOImpl();
            List<T_EPS> epsLst = impl.GetEPSFromDB();
            return GetDataRepoByEPS(epsLst);
        }

        public StackDatedDataRepo[] GetEPSAudited()
        {
            DAOImpl impl = new DAOImpl();
            List<T_EPS_Audited> epsAuditedLst = impl.GetEPSAuditedFromDB();
            return GetDataRepoByEPSAudited(epsAuditedLst);
        }

        private StackDatedDataRepo[] GetDataRepoByPrice(List<T_Price> dbLst)
        {
            StackDatedDataRepo[] repoArr = new StackDatedDataRepo[dbLst.Count];
            for (int i = 0; i < dbLst.Count; i++)
            {
                StackDatedDataRepo datedRepo = new StackDatedDataRepo();
                datedRepo.Year = dbLst[i].Year;
                datedRepo.Quarter = dbLst[i].Quarter;

                datedRepo.COCR = dbLst[i].COCR;
                
                datedRepo.PARQ = dbLst[i].PARQ;
                
                datedRepo.LALU = dbLst[i].LALU;
                
                datedRepo.REXP = dbLst[i].REXP;
                
                datedRepo.CCS = dbLst[i].CCS;
                
                datedRepo.KDL = dbLst[i].KDL;
                
                datedRepo.SOY = dbLst[i].SOY;
                
                datedRepo.HHL = dbLst[i].HHL;
                
                datedRepo.SEYB = dbLst[i].SEYB;
                
                datedRepo.CDB = dbLst[i].CDB;
                
                datedRepo.LFIN = dbLst[i].LFIN;
                
                datedRepo.LWL = dbLst[i].LWL;
                
                datedRepo.CIND = dbLst[i].CIND;
                
                datedRepo.DIPD = dbLst[i].DIPD;
                
                datedRepo.LOLC = dbLst[i].LOLC;
                
                datedRepo.NDB = dbLst[i].NDB;
                
                datedRepo.ACL = dbLst[i].ACL;
                
                datedRepo.SAMP = dbLst[i].SAMP;
                
                datedRepo.TPL = dbLst[i].TPL;
                
                datedRepo.CFIN = dbLst[i].CFIN;
                
                datedRepo.RCL = dbLst[i].RCL;
                
                datedRepo.DIMO = dbLst[i].DIMO;
                
                datedRepo.BLI = dbLst[i].BLI;
                
                datedRepo.REG = dbLst[i].REG;
                
                datedRepo.ALUF = dbLst[i].ALUF;
                
                datedRepo.ARPI = dbLst[i].ARPI;
                
                datedRepo.HDFC = dbLst[i].HDFC;
                
                datedRepo.COLO = dbLst[i].COLO;
                
                datedRepo.VFIN = dbLst[i].VFIN;
                
                datedRepo.PMB = dbLst[i].PMB;
                
                datedRepo.CRL = dbLst[i].CRL;
                
                datedRepo.TJL = dbLst[i].TJL;
                
                datedRepo.GRAN = dbLst[i].GRAN;
                
                datedRepo.TAFL = dbLst[i].TAFL;
                
                datedRepo.UML = dbLst[i].UML;
                
                datedRepo.HAYL = dbLst[i].HAYL;
                
                datedRepo.AAIC = dbLst[i].AAIC;
                
                datedRepo.HNB = dbLst[i].HNB;
                
                datedRepo.BRWN = dbLst[i].BRWN;
                
                datedRepo.CIC = dbLst[i].CIC;
                
                datedRepo.DIST = dbLst[i].DIST;
                
                datedRepo.LION = dbLst[i].LION;
                
                datedRepo.LGL = dbLst[i].LGL;
                
                datedRepo.NTB = dbLst[i].NTB;
                
                datedRepo.DFCC = dbLst[i].DFCC;
                
                datedRepo.SUN = dbLst[i].SUN;
                
                datedRepo.LLUB = dbLst[i].LLUB;
                
                datedRepo.TYRE = dbLst[i].TYRE;
                
                datedRepo.ASIR = dbLst[i].ASIR;
                
                datedRepo.CARG = dbLst[i].CARG;
                
                datedRepo.LHCL = dbLst[i].LHCL;
                
                datedRepo.BFL = dbLst[i].BFL;
                
                datedRepo.NEST = dbLst[i].NEST;
                
                datedRepo.GUAR = dbLst[i].GUAR;
                
                datedRepo.CTC = dbLst[i].CTC;
                
                datedRepo.KAPI = dbLst[i].KAPI;
                
                datedRepo.JKH = dbLst[i].JKH;
                
                datedRepo.LIOC = dbLst[i].LIOC;
                
                datedRepo.CLND = dbLst[i].CLND;
                
                datedRepo.AHUN = dbLst[i].AHUN;
                
                datedRepo.TKYO = dbLst[i].TKYO;
                
                datedRepo.SPEN = dbLst[i].SPEN;
                
                datedRepo.COMB = dbLst[i].COMB;
                
                datedRepo.MELS = dbLst[i].MELS;
                
                datedRepo.SLTL = dbLst[i].SLTL;
                
                datedRepo.CTHR = dbLst[i].CTHR;
                
                datedRepo.CARS = dbLst[i].CARS;
                
                datedRepo.CINS = dbLst[i].CINS;
                
                datedRepo.AEL = dbLst[i].AEL;
                
                datedRepo.BUKI = dbLst[i].BUKI;
                
                datedRepo.AHPL = dbLst[i].AHPL;
                
                datedRepo.SINS = dbLst[i].SINS;
            }
            return repoArr;
        }

        private StackDatedDataRepo[] GetDataRepoByEPS(List<T_EPS> dbLst)
        {
            StackDatedDataRepo[] repoArr = new StackDatedDataRepo[dbLst.Count];
            for (int i = 0; i < dbLst.Count; i++)
            {
                StackDatedDataRepo datedRepo = new StackDatedDataRepo();
                datedRepo.Year = dbLst[i].Year;
                datedRepo.Quarter = dbLst[i].Quarter;

                datedRepo.COCR = dbLst[i].COCR;

                datedRepo.PARQ = dbLst[i].PARQ;

                datedRepo.LALU = dbLst[i].LALU;

                datedRepo.REXP = dbLst[i].REXP;

                datedRepo.CCS = dbLst[i].CCS;

                datedRepo.KDL = dbLst[i].KDL;

                datedRepo.SOY = dbLst[i].SOY;

                datedRepo.HHL = dbLst[i].HHL;

                datedRepo.SEYB = dbLst[i].SEYB;

                datedRepo.CDB = dbLst[i].CDB;

                datedRepo.LFIN = dbLst[i].LFIN;

                datedRepo.LWL = dbLst[i].LWL;

                datedRepo.CIND = dbLst[i].CIND;

                datedRepo.DIPD = dbLst[i].DIPD;

                datedRepo.LOLC = dbLst[i].LOLC;

                datedRepo.NDB = dbLst[i].NDB;

                datedRepo.ACL = dbLst[i].ACL;

                datedRepo.SAMP = dbLst[i].SAMP;

                datedRepo.TPL = dbLst[i].TPL;

                datedRepo.CFIN = dbLst[i].CFIN;

                datedRepo.RCL = dbLst[i].RCL;

                datedRepo.DIMO = dbLst[i].DIMO;

                datedRepo.BLI = dbLst[i].BLI;

                datedRepo.REG = dbLst[i].REG;

                datedRepo.ALUF = dbLst[i].ALUF;

                datedRepo.ARPI = dbLst[i].ARPI;

                datedRepo.HDFC = dbLst[i].HDFC;

                datedRepo.COLO = dbLst[i].COLO;

                datedRepo.VFIN = dbLst[i].VFIN;

                datedRepo.PMB = dbLst[i].PMB;

                datedRepo.CRL = dbLst[i].CRL;

                datedRepo.TJL = dbLst[i].TJL;

                datedRepo.GRAN = dbLst[i].GRAN;

                datedRepo.TAFL = dbLst[i].TAFL;

                datedRepo.UML = dbLst[i].UML;

                datedRepo.HAYL = dbLst[i].HAYL;

                datedRepo.AAIC = dbLst[i].AAIC;

                datedRepo.HNB = dbLst[i].HNB;

                datedRepo.BRWN = dbLst[i].BRWN;

                datedRepo.CIC = dbLst[i].CIC;

                datedRepo.DIST = dbLst[i].DIST;

                datedRepo.LION = dbLst[i].LION;

                datedRepo.LGL = dbLst[i].LGL;

                datedRepo.NTB = dbLst[i].NTB;

                datedRepo.DFCC = dbLst[i].DFCC;

                datedRepo.SUN = dbLst[i].SUN;

                datedRepo.LLUB = dbLst[i].LLUB;

                datedRepo.TYRE = dbLst[i].TYRE;

                datedRepo.ASIR = dbLst[i].ASIR;

                datedRepo.CARG = dbLst[i].CARG;

                datedRepo.LHCL = dbLst[i].LHCL;

                datedRepo.BFL = dbLst[i].BFL;

                datedRepo.NEST = dbLst[i].NEST;

                datedRepo.GUAR = dbLst[i].GUAR;

                datedRepo.CTC = dbLst[i].CTC;

                datedRepo.KAPI = dbLst[i].KAPI;

                datedRepo.JKH = dbLst[i].JKH;

                datedRepo.LIOC = dbLst[i].LIOC;

                datedRepo.CLND = dbLst[i].CLND;

                datedRepo.AHUN = dbLst[i].AHUN;

                datedRepo.TKYO = dbLst[i].TKYO;

                datedRepo.SPEN = dbLst[i].SPEN;

                datedRepo.COMB = dbLst[i].COMB;

                datedRepo.MELS = dbLst[i].MELS;

                datedRepo.SLTL = dbLst[i].SLTL;

                datedRepo.CTHR = dbLst[i].CTHR;

                datedRepo.CARS = dbLst[i].CARS;

                datedRepo.CINS = dbLst[i].CINS;

                datedRepo.AEL = dbLst[i].AEL;

                datedRepo.BUKI = dbLst[i].BUKI;

                datedRepo.AHPL = dbLst[i].AHPL;

                datedRepo.SINS = dbLst[i].SINS;
            }
            return repoArr;
        }

        private StackDatedDataRepo[] GetDataRepoByEPSAudited(List<T_EPS_Audited> dbLst)
        {
            StackDatedDataRepo[] repoArr = new StackDatedDataRepo[dbLst.Count];
            for (int i = 0; i < dbLst.Count; i++)
            {
                StackDatedDataRepo datedRepo = new StackDatedDataRepo();
                datedRepo.Year = dbLst[i].Year;
                datedRepo.Quarter = dbLst[i].Quarter;

                datedRepo.COCR = dbLst[i].COCR;

                datedRepo.PARQ = dbLst[i].PARQ;

                datedRepo.LALU = dbLst[i].LALU;

                datedRepo.REXP = dbLst[i].REXP;

                datedRepo.CCS = dbLst[i].CCS;

                datedRepo.KDL = dbLst[i].KDL;

                datedRepo.SOY = dbLst[i].SOY;

                datedRepo.HHL = dbLst[i].HHL;

                datedRepo.SEYB = dbLst[i].SEYB;

                datedRepo.CDB = dbLst[i].CDB;

                datedRepo.LFIN = dbLst[i].LFIN;

                datedRepo.LWL = dbLst[i].LWL;

                datedRepo.CIND = dbLst[i].CIND;

                datedRepo.DIPD = dbLst[i].DIPD;

                datedRepo.LOLC = dbLst[i].LOLC;

                datedRepo.NDB = dbLst[i].NDB;

                datedRepo.ACL = dbLst[i].ACL;

                datedRepo.SAMP = dbLst[i].SAMP;

                datedRepo.TPL = dbLst[i].TPL;

                datedRepo.CFIN = dbLst[i].CFIN;

                datedRepo.RCL = dbLst[i].RCL;

                datedRepo.DIMO = dbLst[i].DIMO;

                datedRepo.BLI = dbLst[i].BLI;

                datedRepo.REG = dbLst[i].REG;

                datedRepo.ALUF = dbLst[i].ALUF;

                datedRepo.ARPI = dbLst[i].ARPI;

                datedRepo.HDFC = dbLst[i].HDFC;

                datedRepo.COLO = dbLst[i].COLO;

                datedRepo.VFIN = dbLst[i].VFIN;

                datedRepo.PMB = dbLst[i].PMB;

                datedRepo.CRL = dbLst[i].CRL;

                datedRepo.TJL = dbLst[i].TJL;

                datedRepo.GRAN = dbLst[i].GRAN;

                datedRepo.TAFL = dbLst[i].TAFL;

                datedRepo.UML = dbLst[i].UML;

                datedRepo.HAYL = dbLst[i].HAYL;

                datedRepo.AAIC = dbLst[i].AAIC;

                datedRepo.HNB = dbLst[i].HNB;

                datedRepo.BRWN = dbLst[i].BRWN;

                datedRepo.CIC = dbLst[i].CIC;

                datedRepo.DIST = dbLst[i].DIST;

                datedRepo.LION = dbLst[i].LION;

                datedRepo.LGL = dbLst[i].LGL;

                datedRepo.NTB = dbLst[i].NTB;

                datedRepo.DFCC = dbLst[i].DFCC;

                datedRepo.SUN = dbLst[i].SUN;

                datedRepo.LLUB = dbLst[i].LLUB;

                datedRepo.TYRE = dbLst[i].TYRE;

                datedRepo.ASIR = dbLst[i].ASIR;

                datedRepo.CARG = dbLst[i].CARG;

                datedRepo.LHCL = dbLst[i].LHCL;

                datedRepo.BFL = dbLst[i].BFL;

                datedRepo.NEST = dbLst[i].NEST;

                datedRepo.GUAR = dbLst[i].GUAR;

                datedRepo.CTC = dbLst[i].CTC;

                datedRepo.KAPI = dbLst[i].KAPI;

                datedRepo.JKH = dbLst[i].JKH;

                datedRepo.LIOC = dbLst[i].LIOC;

                datedRepo.CLND = dbLst[i].CLND;

                datedRepo.AHUN = dbLst[i].AHUN;

                datedRepo.TKYO = dbLst[i].TKYO;

                datedRepo.SPEN = dbLst[i].SPEN;

                datedRepo.COMB = dbLst[i].COMB;

                datedRepo.MELS = dbLst[i].MELS;

                datedRepo.SLTL = dbLst[i].SLTL;

                datedRepo.CTHR = dbLst[i].CTHR;

                datedRepo.CARS = dbLst[i].CARS;

                datedRepo.CINS = dbLst[i].CINS;

                datedRepo.AEL = dbLst[i].AEL;

                datedRepo.BUKI = dbLst[i].BUKI;

                datedRepo.AHPL = dbLst[i].AHPL;

                datedRepo.SINS = dbLst[i].SINS;
            }
            return repoArr;
        }
    }
}
