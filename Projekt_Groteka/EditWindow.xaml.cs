using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Projekt_Groteka
{
    public partial class EditWindow : Window
    {
        private string ID;
        private GameInfo gameInfo;
        public EditWindow(string DB_ID,GameInfo gi)
        {
            InitializeComponent();
            ID = DB_ID;
            init();
            gameInfo = gi;
        }

        private void init()
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM GameInfo where id = "+ ID;
            SQLiteDataAdapter DB = new SQLiteDataAdapter(sql_cmd.CommandText, sql_con);
            DataSet DS = new DataSet();
            DB.Fill(DS);
            sql_con.Close();
            TopScreenLink.Text = DS.Tables[0].Rows[0]["Screen1"].ToString();
            CenterScreenLink.Text = DS.Tables[0].Rows[0]["Screen2"].ToString();
            BottomScreenLink.Text = DS.Tables[0].Rows[0]["Screen3"].ToString();
            Desc.Text = DS.Tables[0].Rows[0]["Opis"].ToString();
            Tournament.Text = DS.Tables[0].Rows[0]["Turniej"].ToString();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM Gry where id = "+ ID;
            DB = new SQLiteDataAdapter(sql_cmd.CommandText, sql_con);
            DS = new DataSet();
            DB.Fill(DS);
            sql_con.Close();
            CoverLink.Text = DS.Tables[0].Rows[0]["obraz"].ToString();
            Title.Text = DS.Tables[0].Rows[0]["Nazwa"].ToString();
        }

        // Obsługa przycisków
        private void save_click(object sender, RoutedEventArgs routedEventArgs)
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "Update GameInfo set Screen1 ='" + TopScreenLink.Text + "', Screen2 ='"+CenterScreenLink.Text+"', Screen3 ='"
                                  + BottomScreenLink.Text+"', Opis = '"+Desc.Text+"', Turniej = '"+Tournament.Text + "' where id='"+ID+"';";
            sql_cmd.ExecuteNonQuery();
            sql_cmd.CommandText = "Update Gry set obraz = '"+CoverLink.Text+"' where id='"+ID+"';";
            sql_cmd.ExecuteNonQuery();
            sql_cmd.CommandText = "Update Gry set Nazwa = '"+Title.Text+"' where id='"+ID+"';";
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
            gameInfo.init((int.Parse(ID)-1).ToString());
            this.Close();
        }
    }
}