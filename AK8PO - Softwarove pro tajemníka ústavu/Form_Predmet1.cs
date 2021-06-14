using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AK8PO___Softwarove_pro_tajemníka_ústavu.Database_Tool;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{

    public partial class Form_Predmet1 : MetroFramework.Forms.MetroForm
    {
        Database_Tool DB_Data;
        Form_Seznam_Predmet _parent;
        int id = -99;
        public Form_Predmet1(Form_Seznam_Predmet parent)
        {
            _parent = parent;
            InitializeComponent();
            DB_Data = new Database_Tool();

        }

        private void Form_Predmet_Load(object sender, EventArgs e)
        {
            //naplnění comboboxu pro jazyk
            DataTable dataT_jazyky = DB_Data.getJazyk();
            DataTable dataT_způsob_zakonceni = DB_Data.getZpusobZakonceni();
            DataTable dataT_skupiny = DB_Data.getSkupina();
            List<combobox_item> col_jazyky = new List<combobox_item>();
            List<combobox_item> col_způsob_zakonceni = new List<combobox_item>();
            List<combobox_item> col_skupiny = new List<combobox_item>();


            foreach (DataRow dr in dataT_jazyky.Rows)
            {
                col_jazyky.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }

            foreach (DataRow dr in dataT_způsob_zakonceni.Rows)
            {
                col_způsob_zakonceni.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), zkratka = dr.ItemArray[1].ToString().Trim(), nazev = dr.ItemArray[2].ToString().Trim() });

            }

            foreach (DataRow dr in dataT_skupiny.Rows)
            {
                col_skupiny.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), nazev = dr.ItemArray[1].ToString().Trim(), zkratka = null });

            }

            //Zdroje comboboxů
            comboBox_Jazyk.DataSource = col_jazyky;
            comboBox_Zpusob_Zakonceni.DataSource = col_způsob_zakonceni;
            comboBox_Seznam_Skupin.DataSource = col_skupiny;

            //Select default empty value
            comboBox_Jazyk.SelectedIndex = -1;
            comboBox_Zpusob_Zakonceni.SelectedIndex = -1;
            comboBox_Seznam_Skupin.SelectedIndex = -1;

        }

        private void button_Pridat_Click(object sender, EventArgs e)
        {
            if (id != -99)
            {
                DB_Data.setPredmet(id,
                    textBox_Zkratka.Text.ToString(),
                    Convert.ToInt32(textBox_Pocet_Tyden.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Prednasek.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Seminar.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Cviceni.Text),
                    (comboBox_Zpusob_Zakonceni.SelectedItem as combobox_item).id,
                    (comboBox_Jazyk.SelectedItem as combobox_item).id,
                    Convert.ToInt32(textBox_Velikost_Trida.Text),
                    (comboBox_Seznam_Skupin.SelectedItem as combobox_item).id);

                this.UpravaPocetStudentuUStitku((comboBox_Seznam_Skupin.SelectedItem as combobox_item).id, this.id);
                return;
            }


            try
            {
                int IdPredmet = DB_Data.setPredmet(
                    textBox_Zkratka.Text.ToString(),
                    Convert.ToInt32(textBox_Pocet_Tyden.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Prednasek.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Seminar.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Cviceni.Text),
                    (comboBox_Zpusob_Zakonceni.SelectedItem as combobox_item).id,
                    (comboBox_Jazyk.SelectedItem as combobox_item).id,
                    Convert.ToInt32(textBox_Velikost_Trida.Text),
                    (comboBox_Seznam_Skupin.SelectedItem as combobox_item).id);
                MessageBox.Show("Předmět přidán");
                Thread.Sleep(100);
                this._vygenerovaniStitku(IdPredmet);
                MessageBox.Show("Štítky automaticky vygenerovány");
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba v přidávání předmětu " + ex.Message);
            }
            this.Close();
            this._parent.Form_Seznam_Predmet_Load(this, null);
        }

        private void UpravaPocetStudentuUStitku(int IdSkupina, int IdPredmet)
        {
            DataTable dataSkupina = DB_Data.getSkupina((comboBox_Seznam_Skupin.SelectedItem as combobox_item).id.ToString());
            DataTable dataPredmet = DB_Data.getPredmet(IdPredmet);

            //Počet studentů vydělím velikostí třídy a zakorouhluji nahoru
            int pocetStitku = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dataSkupina.Rows[0]["Pocet_Student"]) / Convert.ToDouble(dataPredmet.Rows[0]["Velikost_Tridy"])));
            //Počet studentů vydělím počtem štítků a tento počet nakonec odečtu od počtu studentů u posledního štítku, tj. druhé volání vygenerování počet stítků
            int pocetStudentuNaStitku = (int)Math.Ceiling(Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) / (double)pocetStitku);
            int posledniStitekPocetStudent = (pocetStitku * pocetStudentuNaStitku) - Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]);
            //pocetStudentuNaStitku - posledniStitekPocetStudent

            DataTable dt_PracovniStitky = new DataTable();
            dt_PracovniStitky = DB_Data.getPracovniStitkyDlePredmetu(IdPredmet);
            bool cviceni = Convert.ToInt32(dataPredmet.Rows[0].ItemArray[9]) > 0 ? true: false;
            if (cviceni)
            {
                int pocetStitkuCv = pocetStitku;
                int pocetStudentuNaStitkuCv = pocetStudentuNaStitku;
                int posledniStitekPocetStudentCv = posledniStitekPocetStudent;

                pregenerujStitku(TypStitek.Cviceni, pocetStitkuCv, pocetStudentuNaStitkuCv, posledniStitekPocetStudentCv, dt_PracovniStitky, dataPredmet, dataSkupina);
                
                
            }

            bool seminar = Convert.ToInt32(dataPredmet.Rows[0].ItemArray[4]) > 0 ? true : false;
            if (seminar)
            {
                int pocetStitkuCv = pocetStitku;
                int pocetStudentuNaStitkuCv = pocetStudentuNaStitku;
                int posledniStitekPocetStudentCv = posledniStitekPocetStudent;

                pregenerujStitku(TypStitek.Seminar, pocetStitkuCv, pocetStudentuNaStitkuCv, posledniStitekPocetStudentCv, dt_PracovniStitky, dataPredmet, dataSkupina);
            }



        }

        private void pregenerujStitku(TypStitek typ, int pocetStitku, int pocetStudentuNaStitku, int posledniStitekPocetStudent, DataTable dt_PracovniStitky, DataTable dataPredmet, DataTable dataSkupina)
        {
            int pocetStitkuCv = pocetStitku;
            int pocetStudentuNaStitkuCv = pocetStudentuNaStitku;
            int posledniStitekPocetStudentCv = posledniStitekPocetStudent;
            int IdPredmet = Convert.ToInt32(dataPredmet.Rows[0].ItemArray[0]);
            for (int i = 0; i < dt_PracovniStitky.Rows.Count; i++)
            {
                if (pocetStitkuCv == 0 && Convert.ToInt32(dt_PracovniStitky.Rows[i]["Typ_Stitek"]) == (int)typ)
                {
                    DB_Data.setPracovniStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i][0]), 0);
                }

                else if (pocetStitkuCv == 1 && Convert.ToInt32(dt_PracovniStitky.Rows[i]["Typ_Stitek"]) == (int)typ)
                {
                    DB_Data.setPracovniStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i][0]), pocetStudentuNaStitku - posledniStitekPocetStudent);
                    pocetStitkuCv--;
                }

                else if (Convert.ToInt32(dt_PracovniStitky.Rows[i]["Typ_Stitek"]) == (int)typ)
                {
                    DB_Data.setPracovniStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i][0]), pocetStudentuNaStitku);
                    pocetStitkuCv--;
                }

            }

            if (pocetStitkuCv > 1)
            {
                _VygenerovaniPocetStitku(typ, IdPredmet, pocetStudentuNaStitku,
                  Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                  (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
                  pocetStitku - 1
                  );


                _VygenerovaniPocetStitku(typ, IdPredmet, pocetStudentuNaStitku - posledniStitekPocetStudent,
                    Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                    (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
                    1
                    );

            }
        }

        internal void Init(int id,
                string zkratka, string pocet_tyden, string hodin_prednasek,
                string hodin_cviceni, string hodin_seminar, string zpusob_zakonceni,
                string jazyk, string velikost_tridy, string skupina)
        {
            this.id = id;
            textBox_Zkratka.Text = zkratka;
            textBox_Pocet_Tyden.Text = pocet_tyden;
            textBox_Pocet_Hodin_Prednasek.Text = hodin_prednasek;
            textBox_Pocet_Hodin_Cviceni.Text = hodin_cviceni;
            textBox_Pocet_Hodin_Seminar.Text = hodin_seminar;

            for (int i = 0; i < comboBox_Zpusob_Zakonceni.Items.Count; i++)
                if ((comboBox_Zpusob_Zakonceni.Items[i] as combobox_item).zkratka.Trim() == zpusob_zakonceni.Trim())
                {
                    comboBox_Zpusob_Zakonceni.SelectedIndex = i;
                    comboBox_Zpusob_Zakonceni.SelectedItem = comboBox_Jazyk.Items[i];
                }
            for (int i = 0; i < comboBox_Jazyk.Items.Count; i++)
                if ((comboBox_Jazyk.Items[i] as combobox_item).zkratka.Trim() == jazyk.Trim())
                {
                    comboBox_Jazyk.SelectedIndex = i;
                    comboBox_Jazyk.SelectedItem = comboBox_Jazyk.Items[i];
                }
            //comboBox_Jazyk.SelectedIndex = comboBox_Jazyk.;
            textBox_Velikost_Trida.Text = velikost_tridy;

            for (int i = 0; i < comboBox_Seznam_Skupin.Items.Count; i++)
                if ((comboBox_Seznam_Skupin.Items[i] as combobox_item).nazev.Trim() == skupina.Trim())
                {
                    comboBox_Seznam_Skupin.SelectedIndex = i;
                    comboBox_Seznam_Skupin.SelectedItem = comboBox_Jazyk.Items[i];
                }
            comboBox_Seznam_Skupin.SelectedIndex = comboBox_Seznam_Skupin.FindStringExact(skupina);

            button_Pridat.Text = "Upravit";
        }

        private void _vygenerovaniStitku(int IdPredmet)
        {

            DataTable dataSkupina = DB_Data.getSkupina((comboBox_Seznam_Skupin.SelectedItem as combobox_item).id.ToString());
            DataTable dataPredmet = DB_Data.getPredmet(IdPredmet);

            //DataTable data = new DataTable();
            //data = DB_Data.getPredmetNJSkupina();
            //getPredmetNJSkupina
            // 0. Id, 1. Zkratka, 2. Pocet týdnů, 3. Počet hodin přednášek, 4. Počet hodin seminářů
            //5. Způsob ukončení, 6. jazyk, 7. Velikost třídy, 8. Skupina
            //9. Počet hodin cvičení 
            //14. počet studentů


            //Vytvoří přednášku
            DB_Data.setPracovniStitek(
                String.Empty /*ZAMĚSTNANEC*/,
                IdPredmet,
                Database_Tool.TypStitek.Prednaska,
                Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) /*POČET STUDENTŮ ŠTÍTKU U PŘEDNÁŠKY, MAX POČET U SKUPINY*/,
                Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Prednasek"]) /*POČET HODIN U PŘEDNÁŠKY*/  ,
                Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                (comboBox_Jazyk.SelectedItem as combobox_item).id/*ID JAZYKA*/,
                dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1] /*NÁZEV ŠTÍTKU*/);

            bool isCviceni = false;
            bool isSeminar = false;
            //VYTVOŘENÍ ŠTÍTKU PRO CVIČENÍ A PRO PŘEDNÁŠKU
            if (Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]) > 0)
                isCviceni = true;

            if (Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Seminar"]) > 0)
                isSeminar = true;


            if (Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) % Convert.ToInt32(dataPredmet.Rows[0]["Velikost_Tridy"]) == 0)
            {
                if (isCviceni)
                    _VygenerovaniPocetStitku(Database_Tool.TypStitek.Cviceni, IdPredmet, Convert.ToInt32(Convert.ToInt32(dataPredmet.Rows[0]["Velikost_Tridy"])),
                        Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                        (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
                        Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) / Convert.ToInt32(dataPredmet.Rows[0]["Velikost_Tridy"])
                        );
                if (isSeminar)
                    _VygenerovaniPocetStitku(Database_Tool.TypStitek.Seminar, IdPredmet, Convert.ToInt32(Convert.ToInt32(dataPredmet.Rows[0]["Velikost_Tridy"])),
                        Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                        (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
                        Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) / Convert.ToInt32(dataPredmet.Rows[0]["Velikost_Tridy"])
                        );
            }
            else
            {
                //Počet studentů vydělím velikostí třídy a zakorouhluji nahoru
                int pocetStitku = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dataSkupina.Rows[0]["Pocet_Student"]) / Convert.ToDouble(dataPredmet.Rows[0]["Velikost_Tridy"])));
                //Počet studentů vydělím počtem štítků a tento počet nakonec odečtu od počtu studentů u posledního štítku, tj. druhé volání vygenerování počet stítků
                int pocetStudentuNaStitku = (int)Math.Ceiling(Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) / (double)pocetStitku);
                {
                    int posledniStitekPocetStudent = (pocetStitku * pocetStudentuNaStitku) - Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]);

                    if (isCviceni)
                    {
                        _VygenerovaniPocetStitku(Database_Tool.TypStitek.Cviceni, IdPredmet, pocetStudentuNaStitku,
                            Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                            (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
                            pocetStitku - 1);

                        //zde
                        _VygenerovaniPocetStitku(Database_Tool.TypStitek.Cviceni, IdPredmet, pocetStudentuNaStitku - posledniStitekPocetStudent,
                            Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                            (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
                            1);

                    }
                    if (isSeminar)
                    {
                        _VygenerovaniPocetStitku(Database_Tool.TypStitek.Seminar, IdPredmet, pocetStudentuNaStitku,
                            Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                            (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
                            pocetStitku - 1);

                        //zde
                        _VygenerovaniPocetStitku(Database_Tool.TypStitek.Seminar, IdPredmet, pocetStudentuNaStitku - posledniStitekPocetStudent,
                            Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                            (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
                            1);
                    }
                }

            }


        }

        private void _VygenerovaniPocetStitku(Database_Tool.TypStitek typStitek, int IdPredmet,
            int pocetStudentu, int PocetHodin, int PocetTydnu, int idJazyka, string nazevStitku, int pocetStitku)
        {
            for (int i = 0; i < pocetStitku; i++)
                _VygenerovaniKonkertniStitku(typStitek, IdPredmet, pocetStudentu, PocetHodin, PocetTydnu, idJazyka, nazevStitku + (i + 1));

        }

        private void _VygenerovaniKonkertniStitku(Database_Tool.TypStitek typStitek, int IdPredmet,
            int pocetStudentu, int PocetHodin, int PocetTydnu, int idJazyka, string nazevStitku)
        {
            DB_Data.setPracovniStitek(
                String.Empty /*ZAMĚSTNANEC*/,
                IdPredmet,
                typStitek,
                pocetStudentu,
                PocetHodin,
                PocetTydnu,
                idJazyka,
                nazevStitku
                );
        }

        //private void _vygenerovaniStitku()
        //{

        //    DataTable dataSkupina = dt.getSkupina((comboBox_Seznam_Skupin.SelectedItem as combobox_item).id.ToString());
        //    DataTable dataPredmet = dt.getPredmet(textBox_Zkratka.Text.ToString());

        //    DataTable data = new DataTable();
        //    data = dt.getPredmetNJSkupina();
        //    //getPredmetNJSkupina
        //    // 0. Id, 1. Zkratka, 2. Pocet týdnů, 3. Počet hodin přednášek, 4. Počet hodin seminářů
        //    //5. Způsob ukončení, 6. jazyk, 7. Velikost třídy, 8. Skupina
        //    //9. Počet hodin cvičení 
        //    //14. počet studentů


        //    //Vytvoří přednášku
        //    dt.setPracovniStitek(String.Empty, Convert.ToInt32(dataPredmet.Rows[0].ItemArray[0]), 1 /*Přednáška*/,
        //        Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4]), 0, 0, (comboBox_Jazyk.SelectedItem as combobox_item).id,
        //        dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1]);

        //    double pocet_stitku = Convert.ToDouble(Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4])) / Convert.ToDouble(textBox_Velikost_Trida.Text); //Počet studentů / velikost třídy
        //    pocet_stitku = Math.Ceiling(pocet_stitku);

        //    int pocet_studentu_stitek = (int)Math.Ceiling(Convert.ToDouble(Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4])) / pocet_stitku);
        //    List<int> pocet_student_list = new List<int>();
        //    do
        //    {
        //        pocet_student_list.Add(pocet_studentu_stitek);

        //    } while (pocet_student_list.Take(pocet_student_list.Count()).Sum() + pocet_studentu_stitek < Convert.ToInt32(Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4])));

        //    int pocet_studentu_posledni_prvek = Convert.ToInt32(Convert.ToInt32(dataSkupina.Rows[0].ItemArray[4])) - pocet_student_list.Take(pocet_student_list.Count()).Sum();
        //    if (pocet_studentu_posledni_prvek != 0)
        //        pocet_student_list.Add(pocet_studentu_posledni_prvek);

        //    foreach (int studenti in pocet_student_list)
        //        dt.setPracovniStitek(string.Empty, Convert.ToInt32(dataPredmet.Rows[0].ItemArray[0]), 2 /*Cvičení*/, studenti, Convert.ToInt32(dataPredmet.Rows[0].ItemArray[9]),
        //            Convert.ToInt32(dataPredmet.Rows[0].ItemArray[2]), Convert.ToInt32(dataPredmet.Rows[0].ItemArray[6]), dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1]);





        //}
    }
}
