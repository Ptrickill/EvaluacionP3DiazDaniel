using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluacionP3DiazDaniel.Data;
using EvaluacionP3DiazDaniel.Models;
using EvaluacionP3DiazDaniel.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace EvaluacionP3DiazDaniel.ViewModels
{
    public class SearchCountryViewModel : ObservableObject
    {
        private readonly RestCountriesService _restCountriesService;
        private readonly SQLiteHelper _database;

        public SearchCountryViewModel(RestCountriesService restCountriesService, SQLiteHelper database)
        {
            _restCountriesService = restCountriesService;
            _database = database;

            SearchCommand = new RelayCommand(async () => await SearchCountryAsync());
            ClearCommand = new RelayCommand(ClearSearch);
        }

        private string _countryName;
        public string CountryName
        {
            get => _countryName;
            set => SetProperty(ref _countryName, value);
        }

        private string _resultMessage;
        public string ResultMessage
        {
            get => _resultMessage;
            set => SetProperty(ref _resultMessage, value);
        }

        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        private async Task SearchCountryAsync()
        {
            if (string.IsNullOrWhiteSpace(CountryName))
            {
                ResultMessage = "Por favor, ingrese un nombre de pais";
                return;
            }

            var country = await _restCountriesService.GetCountryByNameAsync(CountryName);

            if (country == null)
            {
                country.CustomName = "DDiaz";
                await _database.SaveCountryAsync(country);

                ResultMessage = $"Pais encontrado: {country.Name}, region: {country.Region}. Guardado en la base de datos"; 
            }
            else
            {
                ResultMessage = "No se encontro ningun pais con ese nombre";
            }
        }

        private void ClearSearch()
        {
            CountryName = string.Empty;
            ResultMessage = string.Empty;
        }
    }
}
