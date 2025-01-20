using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using EvaluacionP3DiazDaniel.Data;
using EvaluacionP3DiazDaniel.Models;
using CommunityToolkit.Mvvm.ComponentModel;


namespace EvaluacionP3DiazDaniel.ViewModels
{
    public class CountriesListViewModel : ObservableObject
    {
        private readonly SQLiteHelper _database;

        public CountriesListViewModel(SQLiteHelper database)
        {
            _database = database;
            Countries = new ObservableCollection<Country>();
            LoadCountriesAsync();
        }

        public ObservableCollection<DisplayCountry> Countries { get; }

        private async void LoadCountriesAsync()
        {
            var countryList = await _database.GetCountriesAsync();
            Countries.Clear();

            foreach (var country in countryList)
            {
                Countries.Add(new DisplayCountry
                {
                    DisplayText = $"Nombre Pais: {country.Name}, Region: {country.Region} Link: {country.GoogleMapsLink}, NombreBD: {country.CustomName}"
                });
            }
        }
    }

    public class DisplayCountry
    {
        public string DisplayText { get; set; }
    }

    public class CountriesListPage : ContentPage
    {
        public CountriesListPage(SQLiteHelper database)
        {
            InitializeComponent();
            BindingContext = new CountriesListViewModel(database);
        }
    }
}
