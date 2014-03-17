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
            MonthText.Text = showMonth(DateTime.Today.Month);

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            using (ImieninyContext ctx = new ImieninyContext(ImieninyContext.ConnectionString))
            {
                ctx.CreateIfNotExists();

                MainLongListSelector.ItemsSource = ctx.Tabela.Where(d => d.Dzien == DateTime.Today.Day).Where(d => d.Miesiac == DateTime.Today.Month).ToList();

                JutroList.ItemsSource = ctx.Tabela.Where(d => d.Dzien == DateTime.Today.AddDays(1).Day).Where(d => d.Miesiac == DateTime.Today.AddDays(1).Month).ToList();

                ZnajomiList.ItemsSource = ctx.Tabela.Where(d => d.Znajomy == "Visible").ToList();

            }
        }

        String showMonth(int month){

            switch (month)
            {

                case(1):
                    return "Stycznia";
                case (2):
                    return "Lutego";
                case (3):
                    return "Marca";
                case (4):
                    return "Kwietnia";
                case (5):
                    return "Maja";
                case (6):
                    return "Czerwca";
                case (7):
                    return "Lipca";
                case (8):
                    return "Sierpnia";
                case (9):
                    return "Września";
                case (10):
                    return "Października";
                case (11):
                    return "Listopada";
                case (12):
                    return "Grudnia";

            }

            return "";

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Dodaj.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Usun.xaml", UriKind.Relative));
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
    }
}