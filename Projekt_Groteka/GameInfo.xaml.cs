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
            Cid = id = (int.Parse(id) + 1).ToString();
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
            Image Screen1, Screen2, Screen3;
            while (dr.Read())
            {
                if (dr[2].ToString() != "")
                {
                    Screen1 = new Image
                    {
                        Source = new BitmapImage(new Uri(dr[2].ToString())),
                        Stretch = Stretch.Fill,
                        Width = 200,
                        Height = 200

                    };
                }
                else
                {
                    Screen1 = new Image
                    {
                        Source = new BitmapImage(new Uri("https://www.ricoh.pl/media/error_93-12813.jpeg")),
                        Stretch = Stretch.Fill,
                        Width = 200,
                        Height = 200

                    };
                    
                }

                if (dr[3].ToString() != "")
                {
                    Screen2 = new Image
                    {
                        Source = new BitmapImage(new Uri(dr[3].ToString())),
                        Stretch = Stretch.Fill,
                        Width = 200,
                        Height = 200

                    };
                }
                else
                {
                    Screen2 = new Image
                    {
                        Source = new BitmapImage(new Uri("https://www.ricoh.pl/media/error_93-12813.jpeg")),
                        Stretch = Stretch.Fill,
                        Width = 200,
                        Height = 200

                    };
                    
                }                
                if (dr[4].ToString() != "")
                {
                    Screen3 = new Image
                    {
                        Source = new BitmapImage(new Uri(dr[4].ToString())),
                        Stretch = Stretch.Fill,
                        Width = 200,
                        Height = 200

                    };
                }
                else
                {
                    Screen3 = new Image
                    {
                        Source = new BitmapImage(new Uri("https://www.ricoh.pl/media/error_93-12813.jpeg")),
                        Stretch = Stretch.Fill,
                        Width = 200,
                        Height = 200

                    };
                    
                }
                 opis = dr[5].ToString();
                 turniej = dr[6].ToString();
                 TTurniej.Text = turniej;
                 TOpis.Text = opis;
                 Iscreen1 = Screen1;
                 Iscreen2 = Screen2;
                 Iscreen3 = Screen3;
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
            Window addkom = new addcm(Cid);
            addkom.Show();
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            Window edit = new EditWindow(Cid);
            edit.Show();
        }

        private void cls(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}