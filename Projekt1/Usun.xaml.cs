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
    public partial class Usun : PhoneApplicationPage
    {
        public Usun()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            using (ImieninyContext ctx = new ImieninyContext(ImieninyContext.ConnectionString))
            {
                ctx.CreateIfNotExists();

                DodajList.ItemsSource = ctx.Tabela.Where(d => d.Znajomy == "Visible").ToList();

            }
        }

        private void UsunButton_Click(object sender, RoutedEventArgs e)
        {
            using (ImieninyContext ctx = new ImieninyContext(ImieninyContext.ConnectionString))
            {
                Button _button = (Button)sender;

                var bla = (from p in ctx.Tabela where p.Id == (int)_button.Tag select p).Single();
                bla.Znajomy = "Collapsed";

                ctx.SubmitChanges();

                DodajList.ItemsSource = ctx.Tabela.Where(d => d.Znajomy == "Visible").ToList();
            }
        }
    }
}