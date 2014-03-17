using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Projekt1.Resources;

namespace Projekt1
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            DayText.Text = DateTime.Today.Day.ToString();
            showMonth();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            using (ImieninyContext ctx = new ImieninyContext(ImieninyContext.ConnectionString))
            {
                ctx.CreateIfNotExists();
                ctx.LogDebug = true;
               // MainLongListSelector.ItemsSource = ctx.Tabela.ToList();
                MainLongListSelector.ItemsSource = ctx.Tabela.Where(d => d.Dzien == DateTime.Today.Day).Where(d => d.Miesiac == DateTime.Today.Month).ToList();


                JutroList.ItemsSource = ctx.Tabela.Where(d => d.Dzien == DateTime.Today.Day + 1).Where(d => d.Miesiac == DateTime.Today.Month).ToList();

                ZnajomiList.ItemsSource = ctx.Tabela.Where(d => d.Znajomy == "Visible").ToList();

            }
        }

        void showMonth(){

            int month = DateTime.Today.Month;

            switch (month)
            {

                case(1):
                    MonthText.Text = "Stycznia";
                    break;
                case (2):
                    MonthText.Text = "Lutego";
                    break;
                case (3):
                    MonthText.Text = "Marca";
                    break;
                case (4):
                    MonthText.Text = "Kwietnia";
                    break;
                case (5):
                    MonthText.Text = "Maja";
                    break;
                case (6):
                    MonthText.Text = "Czerwca";
                    break;
                case (7):
                    MonthText.Text = "Lipca";
                    break;
                case (8):
                    MonthText.Text = "Sierpnia";
                    break;
                case (9):
                    MonthText.Text = "Września";
                    break;
                case (10):
                    MonthText.Text = "Października";
                    break;
                case (11):
                    MonthText.Text = "Listopada";
                    break;
                case (12):
                    MonthText.Text = "Grudnia";
                    break;

            }

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Dodaj.xaml", UriKind.Relative));
        }
    }
}