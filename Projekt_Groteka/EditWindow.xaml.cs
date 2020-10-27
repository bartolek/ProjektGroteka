using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Projekt_Groteka
{
    public partial class EditWindow : Window
    {
        private string id;
        private GameInfo gameInfo;
        public EditWindow(string cid,GameInfo gi)
        {
            InitializeComponent();
            id = cid;
            init();
            gameInfo = gi;
        }

        private void init()
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM GameInfo where id = "+ id;
            SQLiteDataAdapter DB = new SQLiteDataAdapter(sql_cmd.CommandText, sql_con);
            DataSet DS = new DataSet();
            DB.Fill(DS);
            sql_con.Close();
            scren1.Text = DS.Tables[0].Rows[0]["Screen1"].ToString();
            scren2.Text = DS.Tables[0].Rows[0]["Screen2"].ToString();
            scren3.Text = DS.Tables[0].Rows[0]["Screen3"].ToString();
            Opis.Text = DS.Tables[0].Rows[0]["Opis"].ToString();
            Turniej.Text = DS.Tables[0].Rows[0]["Turniej"].ToString();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM Gry where id = "+ id;
            DB = new SQLiteDataAdapter(sql_cmd.CommandText, sql_con);
            DS = new DataSet();
            DB.Fill(DS);
            sql_con.Close();
            okladka.Text = DS.Tables[0].Rows[0]["obraz"].ToString();
            nazwa.Text = DS.Tables[0].Rows[0]["Nazwa"].ToString();
        }

        private void zapisz(object sender, RoutedEventArgs routedEventArgs)
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "Update GameInfo set Screen1 ='" + scren1.Text + "', Screen2 ='"+scren2.Text+"', Screen3 ='"
                                  + scren3.Text+"', Opis = '"+Opis.Text+"', Turniej = '"+Turniej.Text + "' where id='"+id+"';";
            sql_cmd.ExecuteNonQuery();
            sql_cmd.CommandText = "Update Gry set obraz = '"+okladka.Text+"' where id='"+id+"';";
            sql_cmd.ExecuteNonQuery();
            sql_cmd.CommandText = "Update Gry set Nazwa = '"+nazwa.Text+"' where id='"+id+"';";
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
            gameInfo.init((int.Parse(id)-1).ToString());
            this.Close();
        }
    }
}