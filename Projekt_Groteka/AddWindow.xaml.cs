using System;
using System.Data.SQLite;
using System.Windows;

namespace Projekt_Groteka
{
    public partial class AddWindow : Window
    {
        private Action<object, RoutedEventArgs> rload;
        public AddWindow(Action<object, RoutedEventArgs> reload)
        {
            InitializeComponent();
            rload = reload;
        }

        void Dodaj_OnClick(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            string gra = NazwaGry.Text;
            string obraz = ObrazekGry.Text;
            sql_cmd.CommandText = "insert into Gry(id,Nazwa,obraz) values(null,'" + NazwaGry.Text + "','" +
                                  ObrazekGry.Text + "');";
            sql_cmd.ExecuteNonQuery();
            rload(null, null);
            this.Close();
        }
    }
}