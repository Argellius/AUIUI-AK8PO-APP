using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AK8PO___Softwarove_pro_tajemníka_ústavu
{
    public class Database_Tool
    {
        private SqlConnection conn;
        public Database_Tool()
        {
            this.Init();
        }


        private void Init()
        {
            String lala = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
        System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString() + @"\Database.mdf;" +
        @"Integrated Security=True;Connect Timeout=30;User Instance=False";
            this.conn = new SqlConnection(lala);
        }

        internal DataTable getPracovniStitekNJZamestnanec(int v = -1)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();
            string where = string.Empty;
            if (v != -1)
                where = " WHERE Zamestnanec.Id ='" + v + "'";

            SqlCommand command = new SqlCommand("Select * from Pracovni_Stitek JOIN Zamestnanec ON Pracovni_Stitek.Zamestnanec=Zamestnanec.Id" + where, conn);
            // int result = command.ExecuteNonQuery();
            var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            adapter.Fill(dtDatabases);
            conn.Close();

            return dtDatabases;
        }

        public DataTable getJazyk(int id = -1)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            string where = string.Empty;
            if (id != -1)
                where = " WHERE Id ='" + id + "'";

            SqlCommand command = new SqlCommand("Select * from Jazyk" + where, conn);
            // int result = command.ExecuteNonQuery();

            var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            adapter.Fill(dtDatabases);

            conn.Close();

            return dtDatabases;
        }

        public void setJazyk(string zkratka, string name)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Jazyk (zkratka, nazev) VALUES (@zkratka, @nazev)";
                command.Parameters.AddWithValue("@zkratka", zkratka);
                command.Parameters.AddWithValue("@nazev", name);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        internal void SetNullSkupinaFromStitek(int value)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Pracovni_Stitek SET Skupina = @Skupina WHERE Skupina = @SkupinaW";
                command.Parameters.AddWithValue("@Skupina", DBNull.Value);
                command.Parameters.AddWithValue("@SkupinaW", value);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                    ;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba v metodě SetNullSkupinaFromStitek: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        internal void SetNullSkupinaFromPredmet(int value)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Predmet SET Skupina = @Skupina WHERE Skupina = @SkupinaW";
                command.Parameters.AddWithValue("@Skupina", DBNull.Value);
                command.Parameters.AddWithValue("@SkupinaW", value);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                    ;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba v metodě SetNullSkupinaFromStitek: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        internal void DeleteSkupina(int value)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM Skupina WHERE Id='" + value + "'";

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při mazání skupiny: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        internal void DeletePredmet(int id_Predmet)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM Predmet WHERE Id='" + id_Predmet + "'";

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při mazání předmětu: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        internal void setPracovniStitekToNullByZamestnanec(int value)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Pracovni_Stitek SET Zamestnanec = @Zamestnanec WHERE Zamestnanec = @ZamestnanecW";
                command.Parameters.AddWithValue("@Zamestnanec", DBNull.Value);
                command.Parameters.AddWithValue("@ZamestnanecW", value);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                    ;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při mazani zaměstnance u pracovního štítku: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        internal void DeleteZamestnanec(int value)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM Zamestnanec WHERE Id='" + value + "'";

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při mazání zaměstnance: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        internal DataTable getPracovniStitekDleSkup(int idSkupina)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            string where = string.Empty;
            if (idSkupina != -1)
                where = " WHERE Id = '" + idSkupina + "'";

            SqlCommand command = new SqlCommand("Select * from Predmet" + where, conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var DataTable = new DataTable();
                adapter.Fill(dtDatabases);

            }

            conn.Close();

            return dtDatabases;
        }

        internal void DeletePracovniStitek(int id_Predmet, int id_skupiny, Zpusob_Vytvoreni zpusob)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM Pracovni_Stitek WHERE Predmet='" + id_Predmet + "' AND Skupina ='" + id_skupiny + "' AND Zpusob_Vytvoreni ='" + (int)zpusob + "'";

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při mazání pracovních štítků: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        internal void DeletePredmetAndSkupina(string ixp, int id_skupiny)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM Predmet WHERE ixp='" + ixp + "' AND Skupina ='" + id_skupiny + "'";

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při mazání předmětu: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        internal void updateStitekStudent(int idStitek, int pocetStudentuNew)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Pracovni_Stitek SET Pocet_Student = '" + pocetStudentuNew + "' WHERE Id = '" + idStitek + "'";

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při update hodnot u skupiny: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public DataTable getFormaStudia(int id = -1)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            string where = string.Empty;
            if (id != -1)
                where = " WHERE Id ='" + id + "'";

            SqlCommand command = new SqlCommand("Select * from Forma_Studia" + where, conn);
            // int result = command.ExecuteNonQuery();
            var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            adapter.Fill(dtDatabases);

            conn.Close();

            return dtDatabases;
        }

        public void setFormaStudia(string zkratka, string name)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Forma_Studia (zkratka, nazev) VALUES (@zkratka, @nazev)";
                command.Parameters.AddWithValue("@zkratka", zkratka);
                command.Parameters.AddWithValue("@nazev", name);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }


        public DataTable getSemestr(int id = -1)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            string where = string.Empty;
            if (id != -1)
                where = " WHERE Id ='" + id + "'";

            SqlCommand command = new SqlCommand("Select * from Semestr" + where, conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var DataTable = new DataTable();
                adapter.Fill(dtDatabases);
            }

            conn.Close();

            return dtDatabases;
        }

        public void setSemestr(string zkratka, string name)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Semestr (zkratka, nazev) VALUES (@zkratka, @nazev)";
                command.Parameters.AddWithValue("@zkratka", zkratka);
                command.Parameters.AddWithValue("@nazev", name);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public DataTable getTypStitek()
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            SqlCommand command = new SqlCommand("Select * from Typ_Stitek", conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var DataTable = new DataTable();
                adapter.Fill(dtDatabases);
            }

            conn.Close();

            return dtDatabases;
        }

        public void setTypStitek(string zkratka, string name)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Typ_Stitek (zkratka, nazev) VALUES (@zkratka, @nazev)";
                command.Parameters.AddWithValue("@zkratka", zkratka);
                command.Parameters.AddWithValue("@nazev", name);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public DataTable getTypStudia(int id = -1)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            string where = string.Empty;
            if (id != -1)
                where = " WHERE Id ='" + id + "'";

            SqlCommand command = new SqlCommand("Select * from Typ_Studia" + where, conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                adapter.Fill(dtDatabases);
            }

            conn.Close();

            return dtDatabases;
        }

        public void setTypStudia(string zkratka, string name)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Typ_Studia (zkratka, nazev) VALUES (@zkratka, @nazev)";
                command.Parameters.AddWithValue("@zkratka", zkratka);
                command.Parameters.AddWithValue("@nazev", name);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public DataTable getZpusobZakonceni(int id = -1)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            string where = string.Empty;
            if (id != -1)
                where = " WHERE Id ='" + id + "'";

            SqlCommand command = new SqlCommand("Select * from Zpusob_Zakonceni" + where, conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var DataTable = new DataTable();
                adapter.Fill(dtDatabases);
            }

            conn.Close();

            return dtDatabases;
        }

        internal DataTable getSkupinyDleIXP(string ixp)
        {


            DataTable dtDatabases = new DataTable();
            conn.Open();

            SqlCommand command = new SqlCommand("Select * from Skupina JOIN Predmet ON Predmet.Skupina=Skupina.Id WHERE Predmet.ixp ='" + ixp + "'", conn);
            // int result = command.ExecuteNonQuery();
            var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            adapter.Fill(dtDatabases);
            conn.Close();

            return dtDatabases;
        }

        public void setZpusobZakonceni(string zkratka, string name)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Zpusob_Zakonceni (zkratka, nazev) VALUES (@zkratka, @nazev)";
                command.Parameters.AddWithValue("@zkratka", zkratka);
                command.Parameters.AddWithValue("@nazev", name);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public DataTable getPredmet(int Id = -1)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            string where = string.Empty;
            if (Id != -1)
                where = " WHERE Id = '" + Id + "'";

            SqlCommand command = new SqlCommand("Select * from Predmet" + where, conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var DataTable = new DataTable();
                adapter.Fill(dtDatabases);

            }

            conn.Close();

            return dtDatabases;
        }

        public DataTable getPredmetDleSkupiny(int IdSkupina = -1)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            string where = string.Empty;
            if (IdSkupina != -1)
                where = " WHERE Skupina = '" + IdSkupina + "'";

            SqlCommand command = new SqlCommand("Select * from Predmet" + where, conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                adapter.Fill(dtDatabases);

            }

            conn.Close();

            return dtDatabases;
        }

        public DataTable getPracovniStitkyDlePredmetu(int IdPredmet = -1)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            string where = string.Empty;
            if (IdPredmet != -1)
                where = " WHERE Predmet = '" + IdPredmet + "'";

            SqlCommand command = new SqlCommand("Select * from Pracovni_Stitek" + where, conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                adapter.Fill(dtDatabases);

            }

            conn.Close();

            return dtDatabases;
        }

        public void updatePredmetByIXP(string ixp, string Zkratka, int Pocet_Tydnu, int Hodin_Prednasek, int Hodin_Seminar, int Hodin_Cviceni, int Zpusob_Zakonceni, int Jazyk, int Velikost_Tridy)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                //command.CommandText = "UPDATE Pracovni_Stitek SET Pocet_Student = @Pocet_Student WHERE Id = @Id";
                command.CommandText = "UPDATE Predmet SET Zkratka = @Zkratka, Pocet_Tydnu = @Pocet_Tydnu, Hodin_Prednasek = @Hodin_Prednasek," +
                    "Hodin_Seminar = @Hodin_Seminar, Zpusob_Zakonceni = @Zpusob_Zakonceni, Jazyk = @Jazyk," +
                    "Velikost_Tridy = @Velikost_Tridy, Hodin_Cviceni = @Hodin_Cviceni" +
                    "  WHERE ixp = @ixp";

                command.Parameters.AddWithValue("@Zkratka", Zkratka);
                command.Parameters.AddWithValue("@Pocet_Tydnu", Pocet_Tydnu);
                command.Parameters.AddWithValue("@Hodin_Prednasek", Hodin_Prednasek);
                command.Parameters.AddWithValue("@Hodin_Seminar", Hodin_Seminar);
                command.Parameters.AddWithValue("@Zpusob_Zakonceni", Zpusob_Zakonceni);
                command.Parameters.AddWithValue("@Jazyk", Jazyk);
                command.Parameters.AddWithValue("@Velikost_Tridy", Velikost_Tridy);
                command.Parameters.AddWithValue("@Hodin_Cviceni", Hodin_Cviceni);
                command.Parameters.AddWithValue("@ixp", ixp);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);

                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public int setPredmet(string Zkratka, int Pocet_Tydnu, int Hodin_Prednasek, int Hodin_Seminar, int Hodin_Cviceni, int Zpusob_Zakonceni, int Jazyk, int Velikost_Tridy, int Seznam_Skupin, string ixp)
        {

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Predmet " +
                    "(Zkratka, Pocet_Tydnu, Hodin_Prednasek, Hodin_Seminar, Zpusob_Zakonceni, Jazyk, Velikost_Tridy, Skupina, Hodin_Cviceni, ixp) " +
                    "output inserted.Id " +
                    " VALUES (@Zkratka, @Pocet_Tydnu, @Hodin_Prednasek, @Hodin_Seminar, @Zpusob_Zakonceni, @Jazyk, @Velikost_Tridy, @Skupina, @Hodin_Cviceni, @ixp)";
                command.Parameters.AddWithValue("@Zkratka", Zkratka);
                command.Parameters.AddWithValue("@Pocet_Tydnu", Pocet_Tydnu);
                command.Parameters.AddWithValue("@Hodin_Prednasek", Hodin_Prednasek);
                command.Parameters.AddWithValue("@Hodin_Seminar", Hodin_Seminar);
                command.Parameters.AddWithValue("@Zpusob_Zakonceni", Zpusob_Zakonceni);
                command.Parameters.AddWithValue("@Jazyk", Jazyk);
                command.Parameters.AddWithValue("@Velikost_Tridy", Velikost_Tridy);
                if (Seznam_Skupin == -99)
                    command.Parameters.AddWithValue("@Skupina", DBNull.Value);
                else
                command.Parameters.AddWithValue("@Skupina", Seznam_Skupin);
                command.Parameters.AddWithValue("@Hodin_Cviceni", Hodin_Cviceni);
                command.Parameters.AddWithValue("@ixp", ixp);
                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;


                try
                {
                    conn.Open();
                    return (int)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                    return -1;
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public int setPredmetGenerIXP(string Zkratka, int Pocet_Tydnu, int Hodin_Prednasek, int Hodin_Seminar, int Hodin_Cviceni, int Zpusob_Zakonceni, int Jazyk, int Velikost_Tridy, int Seznam_Skupin, string ixp)
        {
            if (ixp == string.Empty)
                ixp = Guid.NewGuid().ToString();

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Predmet " +
                    "(Zkratka, Pocet_Tydnu, Hodin_Prednasek, Hodin_Seminar, Zpusob_Zakonceni, Jazyk, Velikost_Tridy, Skupina, Hodin_Cviceni, ixp) " +
                    "output inserted.Id " +
                    " VALUES (@Zkratka, @Pocet_Tydnu, @Hodin_Prednasek, @Hodin_Seminar, @Zpusob_Zakonceni, @Jazyk, @Velikost_Tridy, @Skupina, @Hodin_Cviceni, @ixp)";
                command.Parameters.AddWithValue("@Zkratka", Zkratka);
                command.Parameters.AddWithValue("@Pocet_Tydnu", Pocet_Tydnu);
                command.Parameters.AddWithValue("@Hodin_Prednasek", Hodin_Prednasek);
                command.Parameters.AddWithValue("@Hodin_Seminar", Hodin_Seminar);
                command.Parameters.AddWithValue("@Zpusob_Zakonceni", Zpusob_Zakonceni);
                command.Parameters.AddWithValue("@Jazyk", Jazyk);
                command.Parameters.AddWithValue("@Velikost_Tridy", Velikost_Tridy);
                command.Parameters.AddWithValue("@Skupina", Seznam_Skupin);
                command.Parameters.AddWithValue("@Hodin_Cviceni", Hodin_Cviceni);
                command.Parameters.AddWithValue("@ixp", ixp);
                command.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;


                try
                {
                    conn.Open();
                    return (int)command.ExecuteScalar();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                    return -1;
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public DataTable getSkupina(string Id = "")
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();
            string where = string.Empty;
            if (Id != "")
                where = " WHERE Id='" + Id + "'";
            SqlCommand command = new SqlCommand(String.Format("Select * from Skupina" + where), conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                adapter.Fill(dtDatabases);

            }

            conn.Close();

            return dtDatabases;
        }

        public void setSkupinaZmenaStudent(string IdPredmetu, int pocetStudent)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Skupina SET Pocet_Student = '" + pocetStudent + "' WHERE Id = '" + IdPredmetu + "'";

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při update hodnot u skupiny: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public void setSkupina(string Zkratka, int Rocnik, int Semestr, int Pocet_Student, int Forma_Studia, int Typ_Studia, int Jazyk)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Skupina (Zkratka, Rocnik, Semestr, Pocet_Student, Forma_Studia, Typ_Studia, Jazyk) VALUES (@Zkratka, @Rocnik, @Semestr, @Pocet_Student, @Forma_Studia, @Typ_Studia, @Jazyk)";
                command.Parameters.AddWithValue("@Zkratka", Zkratka);
                command.Parameters.AddWithValue("@Rocnik", Rocnik);
                command.Parameters.AddWithValue("@Semestr", Semestr);
                command.Parameters.AddWithValue("@Pocet_Student", Pocet_Student);
                command.Parameters.AddWithValue("@Forma_Studia", Forma_Studia);
                command.Parameters.AddWithValue("@Typ_Studia", Typ_Studia);
                command.Parameters.AddWithValue("@Jazyk", Jazyk);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public DataTable getZamestnanec()
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            SqlCommand command = new SqlCommand("Select * from Zamestnanec", conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var DataTable = new DataTable();
                adapter.Fill(dtDatabases);
            }

            conn.Close();

            return dtDatabases;
        }

        public String getZamestnanecJmeno(int id)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            SqlCommand command = new SqlCommand("Select jmeno, prijmeni from Zamestnanec where Id=" + id, conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var DataTable = new DataTable();
                adapter.Fill(dtDatabases);
            }

            conn.Close();

            return dtDatabases.Rows[0][0] + " " + dtDatabases.Rows[0][1];
        }

        public void setZamestnanec(string Jmeno, string Prijmeni, string Pracovni_Email, string Soukromy_Email, byte Doktorand, double Uvazek)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Zamestnanec (Jmeno, Prijmeni, Pracovni_Email, Soukromy_Email, Velikost_Tridy) VALUES (@Jmeno, @Prijmeni, @Pracovni_Email, @Soukromy_Email, @Velikost_Tridy)";
                command.Parameters.AddWithValue("@Jmeno", Jmeno);
                command.Parameters.AddWithValue("@Prijmeni", Prijmeni);
                command.Parameters.AddWithValue("@Pracovni_Email", Pracovni_Email);
                command.Parameters.AddWithValue("@Soukromy_Email", Soukromy_Email);
                command.Parameters.AddWithValue("@Doktorand", Doktorand);
                command.Parameters.AddWithValue("@Uvazek", Uvazek);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public DataTable getPracovniStitek()
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            SqlCommand command = new SqlCommand("Select * from Pracovni_Stitek", conn);
            // int result = command.ExecuteNonQuery();
            var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            adapter.Fill(dtDatabases);
            conn.Close();

            return dtDatabases;

        }       

      
        public enum TypStitek
        {
            Prednaska = 1,
            Cviceni = 2,
            Seminar = 3,
            Zapocet = 4,
            Klasifik_Zapoc = 7,
            Zkouska = 8,


        }

        public enum Zpusob_Vytvoreni
        {
            Automaticky = 1,
            Manualne = 2,

        }

        public enum TypJazyk
        {
            CZ = 1,

            ENG = 2,
        }

        public void setPracovniStitek(
            string Zamestnanec, int Predmet,
            TypStitek Typ_Stitek, int Pocet_Student,
            int Pocet_Hodin, int Pocet_Tyden,
            int Jazyk, string nazev, string Skupina, Zpusob_Vytvoreni zpusob)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT into Pracovni_Stitek (Zamestnanec, Predmet, Typ_Stitek, Pocet_Student, Pocet_Hodin, Pocet_Tyden, Jazyk, nazev, Skupina, Zpusob_Vytvoreni) " +
                    "VALUES (@Zamestnanec, @Predmet, @Typ_Stitek, @Pocet_Student, @Pocet_Hodin, @Pocet_Tyden, @Jazyk, @nazev, @Skupina, @Zpusob_Vytvoreni)";
                if (Zamestnanec == string.Empty)
                    command.Parameters.AddWithValue("@Zamestnanec", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Zamestnanec", Zamestnanec);
                command.Parameters.AddWithValue("@Predmet", Predmet);
                command.Parameters.AddWithValue("@Typ_Stitek", (int)Typ_Stitek);
                command.Parameters.AddWithValue("@Pocet_Student", Pocet_Student);
                command.Parameters.AddWithValue("@Pocet_Hodin", Pocet_Hodin);
                command.Parameters.AddWithValue("@Pocet_Tyden", Pocet_Tyden);
                command.Parameters.AddWithValue("@Jazyk", (int)Jazyk);
                command.Parameters.AddWithValue("@nazev", nazev);
                if (Skupina == string.Empty)
                    command.Parameters.AddWithValue("@Skupina", DBNull.Value);
                else
                    command.Parameters.AddWithValue("@Skupina", Skupina);
                command.Parameters.AddWithValue("@Zpusob_Vytvoreni", (int)zpusob);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                    ;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public void setPracovniStitek(int Id_Predmet, int Zamestnanec)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Pracovni_Stitek SET Zamestnanec = @Zamestnanec WHERE Id = @Id";
                command.Parameters.AddWithValue("@Zamestnanec", Zamestnanec);
                command.Parameters.AddWithValue("@Id", Id_Predmet);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                    ;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public void setPracovniStitekStudent(int Id, int pocetStudentu)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = this.conn;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE Pracovni_Stitek SET Pocet_Student = @Pocet_Student WHERE Id = @Id";
                command.Parameters.AddWithValue("@Pocet_Student", pocetStudentu);
                command.Parameters.AddWithValue("@Id", Id);

                try
                {
                    conn.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                    ;
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Nastala chyba při vkládání hodnot: " + e.Message);
                }
                finally
                {
                    conn.Close();
                }


            }
        }

        public string getNazevTypStitek(int id)
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            SqlCommand command = new SqlCommand("Select nazev from Typ_Stitek where Id=" + id, conn);
            // int result = command.ExecuteNonQuery();

            {
                var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
                var DataTable = new DataTable();
                adapter.Fill(dtDatabases);
            }

            conn.Close();

            return dtDatabases.Rows[0][0].ToString();
        }

        public DataTable getPredmetNJSkupina()
        {
            DataTable dtDatabases = new DataTable();
            conn.Open();

            SqlCommand command = new SqlCommand("Select * from Predmet JOIN Skupina ON Predmet.Skupina=Skupina.Id", conn);
            // int result = command.ExecuteNonQuery();
            var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            adapter.Fill(dtDatabases);
            conn.Close();

            return dtDatabases;
        }







    }
}
