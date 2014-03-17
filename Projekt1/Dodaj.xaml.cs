using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace Projekt1
{
    public partial class Dodaj : PhoneApplicationPage
    {
        public Dodaj()
        {
            InitializeComponent();
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            using (ImieninyContext ctx = new ImieninyContext(ImieninyContext.ConnectionString))
            {
                Button _button = (Button)sender;

                var bla = (from p in ctx.Tabela where p.Id == (int)_button.Tag select p).Single();
                bla.Znajomy = "Visible";

                ctx.SubmitChanges();

                DodajList.ItemsSource = ctx.Tabela.Where(d => d.Znajomy == "Collapsed").Where(d => d.Imieniny == Szukane.Text).OrderBy(d => d.Imieniny).ToList();
            }
        }

        private void SzukajButton_Click(object sender, RoutedEventArgs e)
        {
            using (ImieninyContext ctx = new ImieninyContext(ImieninyContext.ConnectionString))
            {
                ctx.CreateIfNotExists();

                DodajList.ItemsSource = ctx.Tabela.Where(d => d.Znajomy == "Collapsed").Where(d => d.Imieniny == Szukane.Text).OrderBy(d => d.Imieniny).ToList();
            }
        }

        private void Szukane_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                SzukajButton.Focus();
        }

        private void Szukane_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Szukane.Text == "Wpisz szukane imię")
            {
                Szukane.Text = "";
                SolidColorBrush Brush1 = new SolidColorBrush();
                Brush1.Color = Colors.Black;
                Szukane.Foreground = Brush1;
            }
        }

        private void Szukane_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Szukane.Text == String.Empty)
            {
                Szukane.Text = "Wpisz szukane imię";
                SolidColorBrush Brush2 = new SolidColorBrush();
                Brush2.Color = Colors.Gray;
                Szukane.Foreground = Brush2;
            }
        }

    }
}