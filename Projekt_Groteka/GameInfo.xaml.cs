using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.MessageBox;

namespace Projekt_Groteka
{
    public partial class GameInfo : Window
    {
        private string DB_ID;

        public string get_DB_ID()
        {
            return DB_ID;
        }
        public void set_DB_ID(string value)
        {
            DB_ID = value;
        }
        public GameInfo(string id)
        {
            InitializeComponent();
            init(id);
            //Obliczanie ID gry w Bazie danych
            DB_ID = (int.Parse(id) + 1).ToString();
        }

        public void init(string id)
        {
            id = (int.Parse(id) + 1).ToString();
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM GameInfo where GameID = " + id; 
            SQLiteDataReader DR = sql_cmd.ExecuteReader(); 
            string err = "https://www.ricoh.pl/media/error_93-12813.jpeg";
            while (DR.Read())
            {
                if (DR[2].ToString() != "")
                {
                    LeftScreen.Source = new BitmapImage(new Uri(DR[2].ToString()));
                }
                else
                {
                    LeftScreen.Source = new BitmapImage(new Uri(err));
                    
                }

                if (DR[3].ToString() != "")
                {
                    CenterScreen.Source = new BitmapImage(new Uri(DR[3].ToString()));
                }
                else
                {
                    CenterScreen.Source = new BitmapImage(new Uri(err));
                    
                }                
                if (DR[4].ToString() != "")
                {
                    RightScreen.Source = new BitmapImage(new Uri(DR[4].ToString()));
                }
                else
                {    
                    RightScreen.Source = new BitmapImage(new Uri(err));

                }
                TournamentDate.Text = DR[6].ToString();
                GameDesc.Text = DR[5].ToString();
            }

            init_kom(id);


        }

        private void init_kom(string id)
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM komentarze where id_gry = " + id;
            SQLiteDataReader DR = sql_cmd.ExecuteReader();
            SQLiteDataAdapter DB = new SQLiteDataAdapter(sql_cmd.CommandText, sql_con);
            DataSet DS = new DataSet();
            DB.Fill(DS);
            Comments.ItemsSource = DS.Tables[0].DefaultView;
            sql_con.Close();
        }

        //Obsługa przycisków 
        
        public void addcm_click(object sender, RoutedEventArgs routedEventArgs)
        {
            Window addkom = new addcm(DB_ID,this);
            addkom.Show();
        }

        private void edit_click(object sender, RoutedEventArgs e)
        {
            Window edit = new EditWindow(DB_ID,this);
            edit.Show();
            
        }

        private void exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}