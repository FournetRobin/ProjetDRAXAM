using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TD3.Models;
using TD3.Service;
using Xamarin.Forms;

namespace TD3.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        string querry;
        public string Querry
        {
            get { return querry; }
            set { SetProperty(ref querry, value); }
        }

        string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        string city;
        public string City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }

        string windSpeed;
        public string WindSpeed
        {
            get { return windSpeed; }
            set { SetProperty(ref windSpeed, value); }
        }

        string humidity;
        public string Humidity
        {
            get { return humidity; }
            set { SetProperty(ref humidity, value); }
        }

        string visibility;
        public string Visibility
        {
            get { return visibility; }
            set { SetProperty(ref visibility, value); }
        }

        string temperature;
        public string Temperature
        {
            get { return temperature; }
            set { SetProperty(ref temperature, value); }
        }

        string description;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        string feelslike;
        public string Feelslike
        {
            get { return feelslike; }
            set { SetProperty(ref feelslike, value); }
        }

        string dt;
        public string Dt
        {
            get { return dt; }
            set { SetProperty(ref dt, value); }
        }

        string sunrise;
        public string Sunrise
        {
            get { return sunrise; }
            set { SetProperty(ref sunrise, value); }
        }

        string sunset;
        public string Sunset
        {
            get { return sunset; }
            set { SetProperty(ref sunset, value); }
        }

        string timezone;
        public string Timezone
        {
            get { return timezone; }
            set { SetProperty(ref timezone, value); }
        }

        string icon;
        public string Icon
        {
            get { return icon; }
            set { SetProperty(ref icon, value); }
        }

        public ICommand GetCommand => new Command(() => Task.Run(LoadWeatherData));

        async Task LoadWeatherData()
        {
            if (IsBusy) return;
            IsBusy = true;
            var client = HttpService.GetInstance();
            var result = await
            client.GetAsync($"https://api.openweathermap.org/data/2.5/weather?q={Querry}&APPID=e54c7db0a0ee6f0b1976a61e8cc693ab&units=metric&lang=fr");
            var serializedResponse = await result.Content.ReadAsStringAsync();
            var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(serializedResponse);
            if (weatherResponse?.Weather != null && weatherResponse.Weather.Any())
            {
                ErrorMessage = "";
                City = weatherResponse.Name;
                WindSpeed = $"{weatherResponse.Wind.Speed} km/h";
                Humidity = $"{weatherResponse.Main.Humidity}%";
                Visibility = $"{weatherResponse.Visibility}m";
                Temperature = $"{weatherResponse.Main.Temp}°";
                Description = $"{weatherResponse.Weather[0].Description}";
                Feelslike = $"{weatherResponse.Main.Feelslike}°";
                //Dt = $"{weatherResponse.dt}";
                Sunrise = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(weatherResponse.Sys.Sunrise + weatherResponse.Timezone).ToString("dd/MM/yyyy HH:mm");
                Sunset = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(weatherResponse.Sys.Sunset + weatherResponse.Timezone).ToString("dd/MM/yyyy HH:mm");
                Dt = new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(weatherResponse.Dt + weatherResponse.Timezone).ToString("dd/MM/yyyy HH:mm");
                Icon = $"{"https://openweathermap.org/img/wn/" + weatherResponse.Weather[0].Icon + ".png"}";
            }
            else
            {
                ErrorMessage = weatherResponse?.Message ?? "Unknown error";
                City = "unknown";
                WindSpeed = "unknown";
                Humidity = "unknown";
                Visibility = "unknown";
                Temperature = "unknown";
                Description = "unknown";
                Feelslike = "unknown";
                Dt = "unknown";
                Sunset = "unknown";
                Sunrise = "unknow";
            }
            IsBusy = false;
        }
    }

}
