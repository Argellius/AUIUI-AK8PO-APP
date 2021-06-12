using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AK8PO___Softwarove_pro_tajemníka_ústavu.Database_Tool;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{

    class Uvazky
    {
        public double Hodina_Prednaska_CZ { get; set; }
        public double Hodina_Cviceni_CZ { get; set; }
        public double Hodina_Seminare_CZ { get; set; }

        public double Hodina_Prednaska_AJ { get; set; }
        public double Hodina_Cviceni_AJ { get; set; }
        public double Hodina_Seminare_AJ { get; set; }

        public Uvazky()
        {
            this.Hodina_Prednaska_CZ = 1.8;
            this.Hodina_Cviceni_CZ = 1.2;
            this.Hodina_Seminare_CZ = 1.2;

            this.Hodina_Prednaska_AJ = 2.4;
            this.Hodina_Cviceni_AJ = 1.8;
            this.Hodina_Seminare_AJ = 1.8;


        }

        internal double getBody(Database_Tool.TypStitek typ, Database_Tool.TypJazyk jazyk, double hodin)
        {
            switch (typ)
            {
                case TypStitek.Prednaska:
                    switch (jazyk)
                    {
                        case TypJazyk.CZ:
                            return Hodina_Prednaska_CZ * hodin;
                        case TypJazyk.ENG:
                            return Hodina_Prednaska_AJ * hodin;
                        default:
                            return 0;
                    }
                case TypStitek.Cviceni:
                    switch (jazyk)
                    {
                        case TypJazyk.CZ:
                            return Hodina_Cviceni_CZ * hodin;
                        case TypJazyk.ENG:
                            return Hodina_Cviceni_AJ * hodin;
                        default:
                            return 0;
                    }

                case TypStitek.Seminar:
                    switch (jazyk)
                    {
                        case TypJazyk.CZ:
                            return Hodina_Seminare_CZ * hodin;
                        case TypJazyk.ENG:
                            return Hodina_Seminare_AJ * hodin;
                        default:
                            return 0;
                    }
                default:
                    return 0;


            }
        }
    }
}
