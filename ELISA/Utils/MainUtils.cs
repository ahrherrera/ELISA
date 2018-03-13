using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELISA.Utils
{
    public class MainUtils
    {

        public static List<String> abc()
        {
            List<String> abc = new List<string>();
            abc.Add("A");
            abc.Add("B");
            abc.Add("C");
            abc.Add("D");
            abc.Add("E");
            abc.Add("F");
            abc.Add("G");
            abc.Add("H");
            return abc;
        }

        public enum Controles
        {
            ControlesIgM_CPA,
            ControlesIgM_CPB,
            ControlesIgM_C,
            ControlesIgM_CRP,
            ControlesIgM_CRN,
            ControlesEI_CMin,
            ControlesEI_CPlus

        }

        public enum Test
        {
            //IgM
            IgMDengue,
            IgMZika,
            IgMZikaBei,
            ChinkungunyaCDCCNDR,
            ChinkungunyaCNDR,
            //IgG
            SalivaCIET,
            SalivaCIETRep,
            //EI
            ELISAINHMonoChik,
            ELISAINHHiperChik,
            ELISAINHEnsa,
            ELISAINHRM,
            ELISAINHZika,
            //BOB
            ZikaBOB,
            ZikaBOBCohAnual,
            ZikaBOBCohAnualDup,
            ZikaBOBCohAnualSero,
            //1D
            ELISA1DCohAnual,
            ELISA1DCohAnualDup,
            ELISA1DCohAnualChik,
            ELISA1DCohAnualChikDup,
            ELISA1DSeroChik,
            ELISA1DSeroChikDup,
            Zika1DCohAnual,
            Zika1DCohAnualDup,
            //RM
            RMCohAnual,
            RMCohAnualDup,
            ELISARMCohAnualChik,
            ELISARMCohAnualChikDup,
            ELISARMSeroChik,
            ELISARMSeroChikDup,
            ZIKARMCohAnual,
            ZIKARMCohAnualDup,
            //Rotavirus
            Rotavirus
        }
    }
}
