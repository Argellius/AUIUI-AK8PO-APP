using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AK8PO___Softwarove_pro_tajemníka_ústavu.Database_Tool;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    public partial class Form_PocetStudentuSkupina : MetroFramework.Forms.MetroForm
    {
        Database_Tool DB_Data;
        private int IdSkupina;
        private int pocetStudent;
        private string zkratkaSkupina;
        private Form_Seznam_Skupin parent;

        public Form_PocetStudentuSkupina()
        {
            this.DB_Data = new Database_Tool();
            InitializeComponent();

        }

        public void Init(int IdPredmet, Form_Seznam_Skupin parent)
        {
            this.parent = parent;
            DataTable dataTable = new DataTable();

            dataTable = this.DB_Data.getSkupina(IdPredmet.ToString());

            this.IdSkupina = Convert.ToInt32(dataTable.Rows[0]["Id"]);
            this.pocetStudent = Convert.ToInt32(dataTable.Rows[0]["Pocet_Student"]);
            this.zkratkaSkupina = dataTable.Rows[0]["Zkratka"].ToString();

            this.InitPolicka();

        }

        private void InitPolicka()
        {
            this.textBox1.Text = zkratkaSkupina.ToString();
            this.textBox2.Text = pocetStudent.ToString();
        }



        private void button_potvrdit_Click(object sender, EventArgs e)
        {
            try
            {
                int pocetStudentuNew = Convert.ToInt32(textBox2.Text);
                DB_Data.setSkupinaZmenaStudent(this.IdSkupina.ToString(), pocetStudentuNew);
                MessageBox.Show("Počet studentů u skupiny změněn");
                UpravaPocetStudentuUStitku(pocetStudentuNew);
                parent.Form_Seznam_Skupin_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba při změně studentů u skupiny: " + ex.Message);
            }


        }

        private void UpravaPocetStudentuUStitku(int pocetStudentuNew)
        {
            DataTable dt_Predmet = this.DB_Data.getPredmetDleSkupiny(this.IdSkupina);
            DataTable dt_Skupina = this.DB_Data.getSkupina(this.IdSkupina.ToString());
            foreach (DataRow dr in dt_Predmet.Rows)
            {
                DataTable dt_PracovniStitky = new DataTable();
                dt_PracovniStitky = DB_Data.getPracovniStitkyDlePredmetu(Convert.ToInt32(dr.ItemArray[0]));

                if (this.pocetStudent > pocetStudentuNew) //ÚBYTEK STUDENTŮ!!
                {
                    int ubytek = this.pocetStudent - pocetStudentuNew;
                    //foreach (DataRow row in dt_PracovniStitky.Rows)
                    //{
                    //    if (Convert.ToInt32(row.ItemArray[3]) == (int)TypStitek.Prednaska)
                    //        this.DB_Data.updateStitekStudent(Convert.ToInt32(row.ItemArray[0]), pocetStudentuNew);

                    for (int i = dt_PracovniStitky.Rows.Count - 1; i != 0; i--)
                    {
                        if (Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[3]) == (int)TypStitek.Prednaska)
                            this.DB_Data.updateStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[0]), pocetStudentuNew);

                        if (Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[4]) <= ubytek)
                        {
                            DB_Data.setPracovniStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[0]), 0);
                            ubytek -= Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[4]);
                        }
                        else
                        {
                            DB_Data.setPracovniStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[0]), Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[4]) - ubytek);
                            break;
                        }
                    }
                    //                    }

                }
                else //NÁRŮSTEK STUDENTŮ - provede se normálně vygenerování štítků pomocí počet studentůnew a velikost třídy, existující cvičení se updatnou a další se přidají
                {
                    if (pocetStudentuNew % Convert.ToInt32(dt_Predmet.Rows[0]["Velikost_Tridy"]) == 0)
                    {
                        int pocetStitku = pocetStudentuNew / Convert.ToInt32(dt_Predmet.Rows[0]["Velikost_Tridy"]);
                        //pocet studentu ve třídě je velikost třídy
                        for (int i = 0; i < dt_PracovniStitky.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[3]) == (int)TypStitek.Prednaska)
                                continue;
                            if (Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[3]) == (int)TypStitek.Cviceni)
                            {
                                this.DB_Data.updateStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[0]), Convert.ToInt32(dt_Predmet.Rows[0]["Velikost_Tridy"]));
                                pocetStitku--;
                            }
                        }
                        while (true)
                            if (pocetStitku > 0)
                            {
                                this.DB_Data.setPracovniStitek(string.Empty, Convert.ToInt32(dt_Predmet.Rows[0]["Id"]), TypStitek.Cviceni, Convert.ToInt32(dt_Predmet.Rows[0]["Velikost_Tridy"]),
                                    Convert.ToInt32(dt_Predmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dt_Predmet.Rows[0]["Pocet_Tydnu"]), Convert.ToInt32(dt_Predmet.Rows[0]["Jazyk"]),
                                    dt_Predmet.Rows[0].ItemArray[1] + " " + dt_Skupina.Rows[0].ItemArray[1], this.IdSkupina
                                    );
                                pocetStitku--;
                            }
                            else
                                break;

                    }
                    else
                    {
                        //Počet studentů vydělím velikostí třídy a zakorouhluji nahoru
                        int pocetStitku = Convert.ToInt32(Math.Ceiling(pocetStudentuNew / Convert.ToDouble(dt_Predmet.Rows[0]["Velikost_Tridy"])));
                        //Počet studentů vydělím počtem štítků a tento počet nakonec odečtu od počtu studentů u posledního štítku, tj. druhé volání vygenerování počet stítků
                        int pocetStudentuNaStitku = (int)Math.Ceiling(pocetStudentuNew / (double)pocetStitku);
                        int posledniStitekPocetStudent = (pocetStudentuNew - ((pocetStitku-1) * pocetStudentuNaStitku) == 0) ? pocetStudentuNaStitku : pocetStudentuNew - ((pocetStitku - 1 ) * pocetStudentuNaStitku);

                        for (int i = 0; i < dt_PracovniStitky.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[3]) == (int)TypStitek.Prednaska)
                                this.DB_Data.updateStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[0]), pocetStudentuNew);
                            if (Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[3]) == (int)TypStitek.Cviceni)
                            {
                                this.DB_Data.updateStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i].ItemArray[0]), pocetStudentuNaStitku);
                                pocetStitku--;
                            }
                        }

                        while (true)
                            if (pocetStitku == 1)
                            {
                                this.DB_Data.setPracovniStitek(string.Empty, Convert.ToInt32(dt_Predmet.Rows[0]["Id"]), TypStitek.Cviceni, posledniStitekPocetStudent,
                                                                   Convert.ToInt32(dt_Predmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dt_Predmet.Rows[0]["Pocet_Tydnu"]), Convert.ToInt32(dt_Predmet.Rows[0]["Jazyk"]),
                                                                   dt_Predmet.Rows[0].ItemArray[1] + " " + dt_Skupina.Rows[0].ItemArray[1], this.IdSkupina
                                                                   );
                                pocetStitku--;
                            }
                            else if (pocetStitku > 0)
                            {
                                this.DB_Data.setPracovniStitek(string.Empty, Convert.ToInt32(dt_Predmet.Rows[0]["Id"]), TypStitek.Cviceni, pocetStudentuNaStitku,
                                    Convert.ToInt32(dt_Predmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dt_Predmet.Rows[0]["Pocet_Tydnu"]), Convert.ToInt32(dt_Predmet.Rows[0]["Jazyk"]),
                                    dt_Predmet.Rows[0].ItemArray[1] + " " + dt_Skupina.Rows[0].ItemArray[1], this.IdSkupina
                                    );
                                pocetStitku--;
                            }
                            else
                                break;



                    }


                }
            }


        }
    }
}
