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
        int Id_Predmet = -99;
        string velikost_tridy = String.Empty;
        private string ixp;
        private DataTable skupinyUPredmetu;

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
                //col_skupiny.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), nazev = dr.ItemArray[1].ToString().Trim(), zkratka = null });
                checkedListBox1.Items.Add(new combobox_item { id = Convert.ToInt32(dr.ItemArray[0]), nazev = dr.ItemArray[1].ToString().Trim(), zkratka = null });
            }

            //Zdroje comboboxů
            comboBox_Jazyk.DataSource = col_jazyky;
            comboBox_Zpusob_Zakonceni.DataSource = col_způsob_zakonceni;
            //comboBox_Seznam_Skupin.DataSource = col_skupiny;

            //Select default empty value
            comboBox_Jazyk.SelectedIndex = -1;
            comboBox_Zpusob_Zakonceni.SelectedIndex = -1;
            //comboBox_Seznam_Skupin.SelectedIndex = -1;

        }

        private void button_Pridat_Click(object sender, EventArgs e)
        {
            if (Id_Predmet != -99)
            {
                DataTable predmet = DB_Data.getPredmet(Id_Predmet);
                if (Convert.ToString(predmet.Rows[0]["Skupina"]).Trim() == String.Empty)
                    DB_Data.DeletePredmet(Id_Predmet);

                DB_Data.updatePredmetByIXP(
                    this.ixp,
                          textBox_Zkratka.Text.ToString(),
                          Convert.ToInt32(textBox_Pocet_Tyden.Text),
                          Convert.ToInt32(textBox_Pocet_Hodin_Prednasek.Text),
                          Convert.ToInt32(textBox_Pocet_Hodin_Seminar.Text),
                          Convert.ToInt32(textBox_Pocet_Hodin_Cviceni.Text),
                          (comboBox_Zpusob_Zakonceni.SelectedItem as combobox_item).id,
                          (comboBox_Jazyk.SelectedItem as combobox_item).id,
                          Convert.ToInt32(textBox_Velikost_Trida.Text)
                          );

                List<int> pred_skupiny = new List<int>();
                List<int> aktual_skupiny = new List<int>();

                foreach (var item in checkedListBox1.CheckedItems)
                {
                    aktual_skupiny.Add((item as combobox_item).id);
                }
                foreach (DataRow item in this.skupinyUPredmetu.Rows)
                {
                    pred_skupiny.Add(Convert.ToInt32(item.ItemArray[0]));
                }

                List<int> skupiny_smazat = pred_skupiny.Except(aktual_skupiny).ToList();
                List<int> skupiny_pridat = aktual_skupiny.Except(pred_skupiny).ToList();


                foreach (var item in skupiny_smazat)
                {
                    DB_Data.DeletePracovniStitek(this.Id_Predmet, item, Zpusob_Vytvoreni.Automaticky);
                    DB_Data.DeletePredmetAndSkupina(this.ixp, item);

                }


                foreach (var item in skupiny_pridat)
                {
                    int id = DB_Data.setPredmet(
                          textBox_Zkratka.Text.ToString(),
                          Convert.ToInt32(textBox_Pocet_Tyden.Text),
                          Convert.ToInt32(textBox_Pocet_Hodin_Prednasek.Text),
                          Convert.ToInt32(textBox_Pocet_Hodin_Seminar.Text),
                          Convert.ToInt32(textBox_Pocet_Hodin_Cviceni.Text),
                          (comboBox_Zpusob_Zakonceni.SelectedItem as combobox_item).id,
                          (comboBox_Jazyk.SelectedItem as combobox_item).id,
                          Convert.ToInt32(textBox_Velikost_Trida.Text),
                          item, this.ixp);

                    this._vygenerovaniStitku(id, item);

                }

                if (skupiny_smazat.Count() == pred_skupiny.Count() && skupiny_pridat.Count() == 0)
                    DB_Data.setPredmet(
                          textBox_Zkratka.Text.ToString(),
                          Convert.ToInt32(textBox_Pocet_Tyden.Text),
                          Convert.ToInt32(textBox_Pocet_Hodin_Prednasek.Text),
                          Convert.ToInt32(textBox_Pocet_Hodin_Seminar.Text),
                          Convert.ToInt32(textBox_Pocet_Hodin_Cviceni.Text),
                          (comboBox_Zpusob_Zakonceni.SelectedItem as combobox_item).id,
                          (comboBox_Jazyk.SelectedItem as combobox_item).id,
                          Convert.ToInt32(textBox_Velikost_Trida.Text), -99
                          , this.ixp);

                if (this.velikost_tridy.Trim() != textBox_Velikost_Trida.Text.Trim())
                {
                    foreach (combobox_item item in checkedListBox1.CheckedItems)
                        this.pregenerujStitky(item.id);

                    MessageBox.Show("Štítky přegenerovány");
                };

                this._parent.Form_Seznam_Predmet_Load(this, null);
                //this.UpravaPocetStudentuUStitku((comboBox_Seznam_Skupin.SelectedItem as combobox_item).id, this.id);
                MessageBox.Show("Hotovo!");
                this.Close();
                return;
            }


            try
            {
                var ixp = Guid.NewGuid().ToString();
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    int IdPredmet = DB_Data.setPredmetGenerIXP(
                    textBox_Zkratka.Text.ToString(),
                    Convert.ToInt32(textBox_Pocet_Tyden.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Prednasek.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Seminar.Text),
                    Convert.ToInt32(textBox_Pocet_Hodin_Cviceni.Text),
                    (comboBox_Zpusob_Zakonceni.SelectedItem as combobox_item).id,
                    (comboBox_Jazyk.SelectedItem as combobox_item).id,
                    Convert.ToInt32(textBox_Velikost_Trida.Text),
                    (item as combobox_item).id, ixp);
                    Thread.Sleep(100);
                    this._vygenerovaniStitku(IdPredmet, (item as combobox_item).id);
                    Thread.Sleep(100);
                }
                MessageBox.Show("Předmět přidán");
                MessageBox.Show("Štítky automaticky vygenerovány");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chyba v přidávání předmětu " + ex.Message);
            }
            this.Close();
            this._parent.Form_Seznam_Predmet_Load(this, null);
        }

        private void pregenerujStitky(int IdSkupina)
        {
            DataTable dataPredmet = DB_Data.getPredmetDleSkupiny(IdSkupina);

            for (int i = 0; i < dataPredmet.Rows.Count; i++)
                UpravaPocetStudentuUStitku(IdSkupina, Convert.ToInt32(dataPredmet.Rows[0].ItemArray[0]));
        }

        private void UpravaPocetStudentuUStitku(int IdSkupina, int IdPredmet)
        {

            DataTable dataSkupina = DB_Data.getSkupina(IdSkupina.ToString());
            DataTable dataPredmet = DB_Data.getPredmet(IdPredmet);

            //Počet studentů vydělím velikostí třídy a zakorouhluji nahoru
            int pocetStitku = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dataSkupina.Rows[0]["Pocet_Student"]) / Convert.ToDouble(dataPredmet.Rows[0]["Velikost_Tridy"])));
            //Počet studentů vydělím počtem štítků a tento počet nakonec odečtu od počtu studentů u posledního štítku, tj. druhé volání vygenerování počet stítků
            int pocetStudentuNaStitku = (int)Math.Ceiling(Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) / (double)pocetStitku);
            int posledniStitekPocetStudent = (pocetStitku * pocetStudentuNaStitku) - Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]);
            //pocetStudentuNaStitku - posledniStitekPocetStudent





            DataTable dt_PracovniStitky = new DataTable();
            dt_PracovniStitky = DB_Data.getPracovniStitkyDlePredmetu(IdPredmet, IdSkupina);

            for (int i = 0; i < dt_PracovniStitky.Rows.Count; i++)
            {
                if (Convert.ToInt32(dt_PracovniStitky.Rows[0]["Typ_Stitek"]) == (int)TypStitek.Prednaska)
                {
                    DB_Data.setPracovniStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[0][0]), Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]));
                    break;
                }
            }

            bool cviceni = Convert.ToInt32(dataPredmet.Rows[0].ItemArray[9]) > 0 ? true : false;
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
                  Convert.ToInt32(dataPredmet.Rows[0]["Jazyk"]), dataPredmet.Rows[0].ItemArray[1] + " - Cvičení, " + dataSkupina.Rows[0].ItemArray[1] + " ",
                  pocetStitku - 1, Convert.ToInt32(dataSkupina.Rows[0].ItemArray[0])
                  );


                _VygenerovaniPocetStitku(typ, IdPredmet, pocetStudentuNaStitku - posledniStitekPocetStudent,
                    Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                    Convert.ToInt32(dataPredmet.Rows[0]["Jazyk"]), dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
                    1, Convert.ToInt32(dataSkupina.Rows[0].ItemArray[0]), pocetStitku - 1
                    );

            }
        }



        //private void pregenerujStitky(int IdSkupina)
        //{
        //    DataTable dataPredmet = DB_Data.getPredmetDleSkupiny(IdSkupina);

        //    for (int i = 0; i < dataPredmet.Rows.Count; i++)
        //        UpravaPocetStudentuUStitku(IdSkupina, Convert.ToInt32(dataPredmet.Rows[0].ItemArray[0]));
        //}


        //private void UpravaPocetStudentuUStitku(int IdSkupina, int IdPredmet)
        //{
        //    foreach (combobox_item item in checkedListBox1.CheckedItems)
        //    {
        //        DataTable dataSkupina = DB_Data.getSkupina(item.id.ToString());
        //        DataTable dataPredmet = DB_Data.getPredmet(IdPredmet);

        //        //Počet studentů vydělím velikostí třídy a zakorouhluji nahoru
        //        int pocetStitku = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(dataSkupina.Rows[0]["Pocet_Student"]) / Convert.ToDouble(dataPredmet.Rows[0]["Velikost_Tridy"])));
        //        //Počet studentů vydělím počtem štítků a tento počet nakonec odečtu od počtu studentů u posledního štítku, tj. druhé volání vygenerování počet stítků
        //        int pocetStudentuNaStitku = (int)Math.Ceiling(Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) / (double)pocetStitku);
        //        int posledniStitekPocetStudent = (pocetStitku * pocetStudentuNaStitku) - Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]);
        //        //pocetStudentuNaStitku - posledniStitekPocetStudent

        //        DataTable dt_PracovniStitky = new DataTable();
        //        dt_PracovniStitky = DB_Data.getPracovniStitkyDlePredmetu(IdPredmet);
        //        bool cviceni = Convert.ToInt32(dataPredmet.Rows[0].ItemArray[9]) > 0 ? true : false;
        //        if (cviceni)
        //        {
        //            int pocetStitkuCv = pocetStitku;
        //            int pocetStudentuNaStitkuCv = pocetStudentuNaStitku;
        //            int posledniStitekPocetStudentCv = posledniStitekPocetStudent;

        //            pregenerujStitku(TypStitek.Cviceni, pocetStitkuCv, pocetStudentuNaStitkuCv, posledniStitekPocetStudentCv, dt_PracovniStitky, dataPredmet, dataSkupina);


        //        }

        //        bool seminar = Convert.ToInt32(dataPredmet.Rows[0].ItemArray[4]) > 0 ? true : false;
        //        if (seminar)
        //        {
        //            int pocetStitkuCv = pocetStitku;
        //            int pocetStudentuNaStitkuCv = pocetStudentuNaStitku;
        //            int posledniStitekPocetStudentCv = posledniStitekPocetStudent;

        //            pregenerujStitku(TypStitek.Seminar, pocetStitkuCv, pocetStudentuNaStitkuCv, posledniStitekPocetStudentCv, dt_PracovniStitky, dataPredmet, dataSkupina);
        //        }

        //    }

        //}

        //private void pregenerujStitku(TypStitek typ, int pocetStitku, int pocetStudentuNaStitku, int posledniStitekPocetStudent, DataTable dt_PracovniStitky, DataTable dataPredmet, DataTable dataSkupina)
        //{
        //    int pocetStitkuCv = pocetStitku;
        //    int pocetStudentuNaStitkuCv = pocetStudentuNaStitku;
        //    int posledniStitekPocetStudentCv = posledniStitekPocetStudent;
        //    int IdPredmet = Convert.ToInt32(dataPredmet.Rows[0].ItemArray[0]);
        //    for (int i = 0; i < dt_PracovniStitky.Rows.Count; i++)
        //    {
        //        if (pocetStitkuCv == 0 && Convert.ToInt32(dt_PracovniStitky.Rows[i]["Typ_Stitek"]) == (int)typ)
        //        {
        //            DB_Data.setPracovniStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i][0]), 0);
        //        }

        //        else if (pocetStitkuCv == 1 && Convert.ToInt32(dt_PracovniStitky.Rows[i]["Typ_Stitek"]) == (int)typ)
        //        {
        //            DB_Data.setPracovniStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i][0]), pocetStudentuNaStitku - posledniStitekPocetStudent);
        //            pocetStitkuCv--;
        //        }

        //        else if (Convert.ToInt32(dt_PracovniStitky.Rows[i]["Typ_Stitek"]) == (int)typ)
        //        {
        //            DB_Data.setPracovniStitekStudent(Convert.ToInt32(dt_PracovniStitky.Rows[i][0]), pocetStudentuNaStitku);
        //            pocetStitkuCv--;
        //        }

        //    }

        //    if (pocetStitkuCv > 1)
        //    {
        //        _VygenerovaniPocetStitku(typ, IdPredmet, pocetStudentuNaStitku,
        //          Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
        //          (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " - Cvičení, " + dataSkupina.Rows[0].ItemArray[1] + " ",
        //          pocetStitku - 1, Convert.ToInt32(dataSkupina.Rows[0].ItemArray[0])
        //          );


        //        _VygenerovaniPocetStitku(typ, IdPredmet, pocetStudentuNaStitku - posledniStitekPocetStudent,
        //            Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
        //            (comboBox_Jazyk.SelectedItem as combobox_item).id, dataPredmet.Rows[0].ItemArray[1] + " " + dataSkupina.Rows[0].ItemArray[1],
        //            1, Convert.ToInt32(dataSkupina.Rows[0].ItemArray[0]), pocetStitku - 1
        //            );

        //    }
        //}

        internal void Init(int id,
                string zkratka, string pocet_tyden, string hodin_prednasek,
                string hodin_cviceni, string hodin_seminar, string zpusob_zakonceni,
                string jazyk, string velikost_tridy, string skupina, string ixp)
        {
            this.Id_Predmet = id;
            this.ixp = ixp;
            this.velikost_tridy = velikost_tridy;

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

            this.skupinyUPredmetu = DB_Data.getSkupinyDleIXP(ixp);


            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                foreach (DataRow row in skupinyUPredmetu.Rows)
                {
                    if ((checkedListBox1.Items[i] as combobox_item).id == Convert.ToInt32(row.ItemArray[0]))
                        checkedListBox1.SetItemChecked(i, true);
                }


            //for (int i = 0; i < comboBox_Seznam_Skupin.Items.Count; i++)
            //    if ((comboBox_Seznam_Skupin.Items[i] as combobox_item).nazev.Trim() == skupina.Trim())
            //    {
            //        comboBox_Seznam_Skupin.SelectedIndex = i;
            //        comboBox_Seznam_Skupin.SelectedItem = comboBox_Jazyk.Items[i];
            //    }
            //comboBox_Seznam_Skupin.SelectedIndex = comboBox_Seznam_Skupin.FindStringExact(skupina);

            button_Pridat.Text = "Upravit";
        }

        private void _vygenerovaniStitku(int IdPredmet, int IdSkupina)
        {

            DataTable dataSkupina = DB_Data.getSkupina(IdSkupina.ToString());
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
                dataPredmet.Rows[0].ItemArray[1] + " - Přednáška, " + dataSkupina.Rows[0].ItemArray[1], /*NÁZEV ŠTÍTKU*/
                IdSkupina.ToString(),
                Zpusob_Vytvoreni.Automaticky);

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
                    _VygenerovaniPocetStitku(
                        Database_Tool.TypStitek.Cviceni,
                        IdPredmet,
                        Convert.ToInt32(Convert.ToInt32(dataPredmet.Rows[0]["Velikost_Tridy"])),
                        Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]),
                        Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                        (comboBox_Jazyk.SelectedItem as combobox_item).id,
                        dataPredmet.Rows[0].ItemArray[1] + " - Cvičení, " + dataSkupina.Rows[0].ItemArray[1] + " ",
                        Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) / Convert.ToInt32(dataPredmet.Rows[0]["Velikost_Tridy"]),
                        IdSkupina
                        );
                if (isSeminar)
                    _VygenerovaniPocetStitku(
                        Database_Tool.TypStitek.Seminar,
                        IdPredmet, Convert.ToInt32(Convert.ToInt32(dataPredmet.Rows[0]["Velikost_Tridy"])),
                        Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Seminar"]),
                        Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                        (comboBox_Jazyk.SelectedItem as combobox_item).id,
                        dataPredmet.Rows[0].ItemArray[1] + " - Seminář, " + dataSkupina.Rows[0].ItemArray[1] + " ",
                        Convert.ToInt32(dataSkupina.Rows[0]["Pocet_Student"]) / Convert.ToInt32(dataPredmet.Rows[0]["Velikost_Tridy"]),
                        IdSkupina
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
                            (comboBox_Jazyk.SelectedItem as combobox_item).id,
                            dataPredmet.Rows[0].ItemArray[1] + " - Cvičení, " + dataSkupina.Rows[0].ItemArray[1] + " ",
                            pocetStitku - 1, IdSkupina);

                        //zde
                        _VygenerovaniPocetStitku(Database_Tool.TypStitek.Cviceni, IdPredmet, pocetStudentuNaStitku - posledniStitekPocetStudent,
                            Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Cviceni"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                            (comboBox_Jazyk.SelectedItem as combobox_item).id,
                            dataPredmet.Rows[0].ItemArray[1] + " - Cvičení, " + dataSkupina.Rows[0].ItemArray[1] + " ",
                            1, IdSkupina, pocetStitku - 1);

                    }
                    if (isSeminar)
                    {
                        _VygenerovaniPocetStitku(Database_Tool.TypStitek.Seminar, IdPredmet, pocetStudentuNaStitku,
                            Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Seminar"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                            (comboBox_Jazyk.SelectedItem as combobox_item).id,
                            dataPredmet.Rows[0].ItemArray[1] + " - Seminář, " + dataSkupina.Rows[0].ItemArray[1] + " ",
                            pocetStitku - 1, IdSkupina);

                        //zde
                        _VygenerovaniPocetStitku(Database_Tool.TypStitek.Seminar, IdPredmet, pocetStudentuNaStitku - posledniStitekPocetStudent,
                            Convert.ToInt32(dataPredmet.Rows[0]["Hodin_Seminar"]), Convert.ToInt32(dataPredmet.Rows[0]["Pocet_Tydnu"]),
                            (comboBox_Jazyk.SelectedItem as combobox_item).id,
                            dataPredmet.Rows[0].ItemArray[1] + " - Seminář, " + dataSkupina.Rows[0].ItemArray[1] + " ",
                            1, IdSkupina, pocetStitku - 1);
                    }
                }

            }


        }

        private void _VygenerovaniPocetStitku(Database_Tool.TypStitek typStitek, int IdPredmet,
            int pocetStudentu, int PocetHodin, int PocetTydnu, int idJazyka, string nazevStitku, int pocetStitku, int IdSkupina, int pocetVytvorenychStitku = 0)
        {
            for (int i = 0; i < pocetStitku; i++)
            {
                string nazevStitkuFor;
                if (pocetVytvorenychStitku == 0)
                    nazevStitkuFor = nazevStitku + (i + 1) + ".";
                else
                    nazevStitkuFor = nazevStitku + (pocetVytvorenychStitku + 1) + ".";
                _VygenerovaniKonkertniStitku(typStitek, IdPredmet, pocetStudentu, PocetHodin, PocetTydnu, idJazyka, nazevStitkuFor, IdSkupina);
            }

        }

        private void _VygenerovaniKonkertniStitku(Database_Tool.TypStitek typStitek, int IdPredmet,
            int pocetStudentu, int PocetHodin, int PocetTydnu, int idJazyka, string nazevStitku, int IdSkupina)
        {
            DB_Data.setPracovniStitek(
                String.Empty /*ZAMĚSTNANEC*/,
                IdPredmet,
                typStitek,
                pocetStudentu,
                PocetHodin,
                PocetTydnu,
                idJazyka,
                nazevStitku,
                IdSkupina.ToString(),
                Zpusob_Vytvoreni.Automaticky
                );
        }

        private void textBox_Pocet_Tyden_Leave(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox_Pocet_Tyden.Text, out parsedValue))
            {
                MessageBox.Show("Zadejte prosím Vás číslo");
                return;
            }
        }

        private void textBox_Pocet_Hodin_Prednasek_Leave(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox_Pocet_Hodin_Prednasek.Text, out parsedValue))
            {
                MessageBox.Show("Zadejte prosím Vás číslo");
                return;
            }
        }

        private void textBox_Pocet_Hodin_Cviceni_Leave(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox_Pocet_Hodin_Cviceni.Text, out parsedValue))
            {
                MessageBox.Show("Zadejte prosím Vás číslo");
                return;
            }

        }

        private void textBox_Pocet_Hodin_Seminar_Leave(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox_Pocet_Hodin_Seminar.Text, out parsedValue))
            {
                MessageBox.Show("Zadejte prosím Vás číslo");
                return;
            }

        }

        private void textBox_Velikost_Trida_Leave(object sender, EventArgs e)
        {
            int parsedValue;
            if (!int.TryParse(textBox_Velikost_Trida.Text, out parsedValue))
            {
                MessageBox.Show("Zadejte prosím Vás číslo");
                return;
            }
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
