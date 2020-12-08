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
            this.Title = "Groteka";
        }

        private void Init_list()
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

        private void Init_galery()
        {
            try
            {
                Galery.Items.Clear();
                List<Image> GaleryList = new List<Image>();

                SQLiteConnection sql_con = new SQLiteConnection("DataSource=BazaGier.db;Read Only=false");
                sql_con.Open();
                SQLiteCommand sql_cmd = sql_con.CreateCommand();
                sql_cmd.CommandText = "SELECT obraz FROM GRY";
                
                SQLiteDataReader DR = sql_cmd.ExecuteReader();
                string path;
                while (DR.Read())
                {
                    path = DR[0].ToString();
                    if (path != "")
                    {
                        try
                        {
                            GaleryList.Add(new Image
                            {
                                Source = new BitmapImage(new Uri(path)),
                                Stretch = Stretch.Fill,
                                Width = 200,
                                Height = 200
                            });
                        }
                        catch
                        {
                            GaleryList.Add(new Image
                            {
                                Source = new BitmapImage(new Uri("https://www.ricoh.pl/media/error_93-12813.jpeg")),
                                Stretch = Stretch.Fill,
                                Width = 200,
                                Height = 200
                            });
                        }
                    }
                    else
                    {
                        GaleryList.Add(new Image
                        {
                            Source = new BitmapImage(new Uri("https://www.ricoh.pl/media/error_93-12813.jpeg")),
                            Stretch = Stretch.Fill,
                            Width = 200,
                            Height = 200
                        });
                    }
                }

                foreach (var img in GaleryList)
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
        
        //Wyświetlanie informacji
        
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

        //Obsługa przycisków
        
        
        void new_click(object sender, RoutedEventArgs e)
        {
            Window addWindow = new AddWindow(this);
            addWindow.Show();
            ref_click(null,null);
        }

        public void ref_click(object sender, RoutedEventArgs e)
        {
            Init_list();
            Init_galery();
        }

        void exit_click(object sender, RoutedEventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
        
        //Zamykanie okien
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

    }
}