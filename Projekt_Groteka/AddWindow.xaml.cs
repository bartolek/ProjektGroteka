using System;
using System.Data.SQLite;
using System.Windows;

namespace Projekt_Groteka
{
   
    public partial class AddWindow : Window
    { 
        MainWindow Main;
        public AddWindow(MainWindow mw)
        {
            InitializeComponent();
            Main = mw;
        }
        
        //Obsługa Przycisków
        
        void add_click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            string Game = Title.Text;
            string Cover = GameCover.Text;
            sql_cmd.CommandText = "insert into Gry(id,Nazwa,obraz) values(null,'" + Game + "','" +
                                  Cover + "');";
            sql_cmd.ExecuteNonQuery();
            sql_cmd.CommandText = "insert into GameInfo(id,GameID,Screen1,Screen2,Screen3,Opis,Turniej) values(null,(select id from Gry where Nazwa = '"+Game+"'),null,null,null,null,null);";
            sql_cmd.ExecuteNonQuery();
            Main.ref_click(null,null);
            this.Close();
        }
    }
}