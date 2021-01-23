using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Projekt_Groteka
{
    public partial class addcm : Window
    {
        private string DB_ID;
        private GameInfo GI;
        public addcm(string cid, GameInfo gameInfo)
        {
            InitializeComponent();
            DB_ID = cid;
            GI = gameInfo;
        }
    
        //Obsługa przycisków
        
        private void add_click(object sender, RoutedEventArgs routedEventArgs)
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "insert into komentarze(id,id_gry,komentarz,ocena) values (NULL,'"+DB_ID+"','"+Comment.Text+"','"+Rating.Text+"');";
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
            GI.init((int.Parse(DB_ID)-1).ToString());
            this.Close();
        }
    }
}