using System.Data;
using System.Data.SQLite;
using System.Windows;

namespace Projekt_Groteka
{
    public partial class addcm : Window
    {
        private string cid;
        private GameInfo gi;
        public addcm(string cid2, GameInfo gameInfo)
        {
            InitializeComponent();
            cid = cid2;
            gi = gameInfo;
        }

        private void zapisz(object sender, RoutedEventArgs routedEventArgs)
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "insert into komentarze(id,id_gry,komentarz,ocena) values (NULL,'"+cid+"','"+Komentarz.Text+"','"+Ocena.Text+"');";
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
            gi.init((int.Parse(cid)-1).ToString());
            this.Close();
        }
    }
//dupa
}