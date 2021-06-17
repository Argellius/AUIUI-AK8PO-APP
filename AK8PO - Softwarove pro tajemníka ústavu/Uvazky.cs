using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static AK8PO___Softwarove_pro_tajemníka_ústavu.Database_Tool;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{

    public class Uvazky
    {
        public double Hodina_Prednaska_CZ { get; set; }
        public double Hodina_Cviceni_CZ { get; set; }
        public double Hodina_Seminare_CZ { get; set; }

        public double Hodina_Prednaska_AJ { get; set; }
        public double Hodina_Cviceni_AJ { get; set; }
        public double Hodina_Seminare_AJ { get; set; }


        public Uvazky()
        {

        }

        public Uvazky(bool l)
        {
            Uvazky result;
            var ser = new XmlSerializer(typeof(Uvazky));
            using (var tr = new FileStream(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString() + @"\uvazky.xml", FileMode.Open))
            {
                result = (Uvazky)ser.Deserialize(tr);
            }

            this.Hodina_Prednaska_CZ = result.Hodina_Prednaska_CZ;
            this.Hodina_Cviceni_CZ = result.Hodina_Cviceni_CZ;
            this.Hodina_Seminare_CZ = result.Hodina_Seminare_CZ;

            this.Hodina_Cviceni_AJ = result.Hodina_Cviceni_AJ;
            this.Hodina_Prednaska_AJ = result.Hodina_Prednaska_AJ;
            this.Hodina_Seminare_AJ = result.Hodina_Seminare_AJ;

        }

        internal double getBody(Database_Tool.TypStitek typ, Database_Tool.TypJazyk jazyk, double hodin, double uvazek = 1, bool bez_AJ = false)
        {
            double body = 0;
            switch (typ)
            {
                case TypStitek.Prednaska:
                    switch (jazyk)
                    {
                        case TypJazyk.CZ:
                            body = Hodina_Prednaska_CZ * hodin * uvazek;
                            break;
                        case TypJazyk.ENG:
                            if (bez_AJ) break;
                            body = Hodina_Prednaska_AJ * hodin * uvazek;
                            break;
                        default:
                            break;
                    }
                    break;
                case TypStitek.Cviceni:
                    switch (jazyk)
                    {
                        case TypJazyk.CZ:
                            body = Hodina_Cviceni_CZ * hodin * uvazek;
                            break;
                        case TypJazyk.ENG:
                            if (bez_AJ) break;
                            body = Hodina_Cviceni_AJ * hodin * uvazek;
                            break;
                        default:
                            break;
                    }
                    break;
                case TypStitek.Seminar:
                    switch (jazyk)
                    {
                        case TypJazyk.CZ:
                            body = Hodina_Seminare_CZ * hodin * uvazek;
                            break;
                        case TypJazyk.ENG:
                            if (bez_AJ) break;
                            body = Hodina_Seminare_AJ * hodin * uvazek;
                            break;
                        default:
                            body = 0;
                            break;
                    }
                    break;
                default:
                    break;

            }

            return Math.Round(body, 2);
        }
    }
}
