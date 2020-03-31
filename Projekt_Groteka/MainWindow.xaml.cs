using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace Projekt_Groteka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Init_list();
            Init_galery();
        }

        public void Init_list()
        {
            try
            { 
                Galery.Items.Clear();
                SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
                sql_con.Open();
                SQLiteCommand sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = "SELECT * FROM GRY";
                SQLiteDataAdapter DB = new SQLiteDataAdapter(sql_cmd.CommandText, sql_con);
                DataSet DS = new DataSet();
                DB.Fill(DS);
                MenuList.ItemsSource = DS.Tables[0].DefaultView;
                sql_con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }
        public void Init_galery()
        {
            try
            {
                Galery.Items.Clear();
                List<Image> myList = new List<Image>();

                SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
                sql_con.Open();
                SQLiteCommand sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = "SELECT obraz FROM GRY";

                SQLiteDataReader dr = sql_cmd.ExecuteReader();
                string path;
                while (dr.Read())
                {
                    path = dr[0].ToString();
                    if (path != "")
                    {
                        myList.Add(new Image
                        {
                            Source = new BitmapImage(new Uri(path)),
                            Stretch = Stretch.Fill,
                            Width = 200,
                            Height = 200
                        });
                    }
                    else
                    {
                        myList.Add(new Image
                        {
                            Source = new BitmapImage(new Uri("https://www.ricoh.pl/media/error_93-12813.jpeg")),
                            Stretch = Stretch.Fill,
                            Width = 200,
                            Height = 200
                        });
                    }
                }

                foreach (var img in myList)
                {
                    Galery.Items.Add(img);
                }

                sql_con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        void new_click(object sender, RoutedEventArgs e)
        {
            Window dodaj = new AddWindow(ref_click);
            dodaj.Show();
            ref_click(null,null);
        }

        void ref_click(object sender, RoutedEventArgs e)
        {
            Init_list();
            Init_galery();
        }

        void exit_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        void item_menu_list(object sender, RoutedEventArgs e)
        {

            string id = MenuList.SelectedIndex.ToString();
            GameInfo gameinfo = new GameInfo(id);
            gameinfo.Show();
        }
        void item_menu_galery(object sender, RoutedEventArgs e)
        {
            string id = Galery.SelectedIndex.ToString();
            GameInfo gameinfo = new GameInfo(id);
            gameinfo.Show();
        }
        
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

    }
}