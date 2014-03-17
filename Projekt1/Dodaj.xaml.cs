using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Projekt1
{
    public partial class Dodaj : PhoneApplicationPage
    {
        public Dodaj()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            using (ImieninyContext ctx = new ImieninyContext(ImieninyContext.ConnectionString))
            {
                ctx.CreateIfNotExists();
                ctx.LogDebug = true;
                // MainLongListSelector.ItemsSource = ctx.Tabela.ToList();
                DodajList.ItemsSource = ctx.Tabela.Where(d => d.Znajomy == "Collapsed").OrderBy(d => d.Imieniny).ToList();

            }
        }

        private void DodajButton_Click(object sender, RoutedEventArgs e)
        {
            using (ImieninyContext ctx = new ImieninyContext(ImieninyContext.ConnectionString))
            {
                ctx.LogDebug = true;
                Button _button = (Button)sender;
                //var osoba = ctx.Tabela.Where(d => d.Id == (int)_button.Tag).Single();

                var bla = (from p in ctx.Tabela where p.Id == (int)_button.Tag select p).Single();
                bla.Znajomy = "Visible";

                //osoba.Znajomy = "Visible";

                ctx.SubmitChanges();
            }
        }

    }
}