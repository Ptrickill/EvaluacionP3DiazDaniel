using GoogleGson.Annotations;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvaluacionP3DiazDaniel.Clases
{
    public class BuscarViewModel : BaseViewModel
    {
        private string _pais;
        private string _resultado;

        public string Pais
        {
            get => _pais;
            set => SetProperty(ref _pais, value);
        }

        public string Resultado
        {
            get => _resultado;
            set => SetProperty(ref _resultado, value);
        }

        public ICommand BuscarCommand {  get; }
        public ICommand LimpiarCommand { get; }

        public BuscarViewModel()
        {
            BuscarCommand = new Command(OnBuscar);
        }

        private async void OnBuscar()
        {
            if (string.IsNullOrEmpty(Pais))
            {
                Resultado = "Por favor ingrese su nombre";
                return;
            }
            try
            {
                var client = new HttpClient();
                var response = await client.GetStringAsync($"https://restcountries.com/v3.1/name/{Pais}?fields=name,region,maps");
                var data = JsonSerializer.Deserialize<List<PaisModel>>(response);
                if (data != null && data.Any())
                {
                    var pais = data.First();
                    await App.Database.SavePaisAsync(new PaisDb
                    {
                        Nombre = pais.Name,
                        Region = pais.Region,
                        LinkMaps = pais.Maps.GoogleMaps
                    });

                    Resultado = $"Nombre:{pais.Name}Region:{pais.Region},Link:{pais.Maps.GoogleMaps}";
                    else 
                    {
                        Resultado = "No se encontro pais";
                    }
                }

            }
        }
    }
}
