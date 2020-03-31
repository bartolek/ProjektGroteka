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
        public string Cid;
        public GameInfo(string id)
        {
            
            InitializeComponent();
            init(id);
            Cid = (int.Parse(id) + 1).ToString();
        }

        public void init(string id)
        {
            id = (int.Parse(id) + 1).ToString();
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM GameInfo where GameID = " + id;
         SQLiteDataReader dr = sql_cmd.ExecuteReader();
            string turniej="";
            string opis="";
            string err = "https://www.ricoh.pl/media/error_93-12813.jpeg";
            while (dr.Read())
            {
                if (dr[2].ToString() != "")
                {
                    Iscreen1.Source = new BitmapImage(new Uri(dr[2].ToString()));
                }
                else
                {
                    Iscreen1.Source = new BitmapImage(new Uri(err));
                    
                }

                if (dr[3].ToString() != "")
                {
                    Iscreen2.Source = new BitmapImage(new Uri(dr[3].ToString()));
                }
                else
                {
                    Iscreen2.Source = new BitmapImage(new Uri(err));
                    
                }                
                if (dr[4].ToString() != "")
                {
                    Iscreen3.Source = new BitmapImage(new Uri(dr[4].ToString()));
                }
                else
                {    
                    Iscreen3.Source = new BitmapImage(new Uri(err));

                }
                 opis = dr[5].ToString();
                 turniej = dr[6].ToString();
                 TTurniej.Text = turniej;
                 TOpis.Text = opis;
            }

            init_kom(id);


        }

        public void init_kom(string id)
        {
            SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
            sql_con.Open();
            SQLiteCommand sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = "SELECT * FROM komentarze where id_gry = " + id;
            SQLiteDataReader dr = sql_cmd.ExecuteReader();
            SQLiteDataAdapter DB = new SQLiteDataAdapter(sql_cmd.CommandText, sql_con);
            DataSet DS = new DataSet();
            DB.Fill(DS);
            Comments.ItemsSource = DS.Tables[0].DefaultView;
            sql_con.Close();
        }

        public void addcm(object sender, RoutedEventArgs routedEventArgs)
        {
            Window addkom = new addcm(Cid,this);
            addkom.Show();
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            Window edit = new EditWindow(Cid,this);
            edit.Show();
            
        }

        private void cls(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}