using Plugin.Geolocator;
using PM2E10988.Models;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PM2E10988.Views
{
    public partial class HomePage : ContentPage
    {
        double Lat;
        double Lon;

        public HomePage()
        {
            InitializeComponent();
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DescL.Text))
            {
                await DisplayAlert("Alerta", "La descripción es obligatoria", "Cerrar");
            }

            if (string.IsNullOrEmpty(DescC.Text))
            {
                await DisplayAlert("Alerta", "La descripción corta es obligatoria", "Cerrar");
            }

            Ubicacion ubicacion = new Ubicacion
            {
                Lat = double.Parse(Latitud.Text),
                Lon = double.Parse(Longitud.Text),
                Descl = DescL.Text,
                Descc = DescC.Text
            };
            await App.SQLiteDB.SaveUbicationAsync(ubicacion);
            DescL.Text = "";
            DescC.Text = "";

            await DisplayAlert("Registro", "Datos guardados correctamente", "Ok");
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            if (!locator.IsGeolocationEnabled)
            {
                await DisplayAlert("Alerta", "El GPS no está activo", "Cerrar");
                Latitud.Text = "0";
                Longitud.Text = "0";
            }
            else
            {
                var localization = await Geolocation.GetLocationAsync();
                Lat = localization.Latitude;
                Lon = localization.Longitude;
                Latitud.Text = Lat.ToString();
                Longitud.Text = Lon.ToString();
            }
        }
    }
}