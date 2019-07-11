using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwait
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Game> _games = new List<Game>();

        private async void WindowLoaded(object sender, RoutedEventArgs e)
        {
            List<Id> idList = new List<Id>();

            using (var client = new WebClient())
            {
                client.Headers.Add("user-key", "b54767b80a891fd65001937d4f40d44f");

                string jsonString = await Task.Run(() => client.DownloadString("https://api-v3.igdb.com/games/?platform=pc"));
                idList = JsonConvert.DeserializeObject<List<Id>>(jsonString);


                jsonString = await Task.Run(() => client.DownloadString($"https://api-v3.igdb.com/games/?id={idList[0].Identifier}&fields=*"));
                _games.AddRange(JsonConvert.DeserializeObject<Game[]>(jsonString));
            }

            CardsFilling();
        }

        private async void CardsFilling()
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("user-key", "b54767b80a891fd65001937d4f40d44f");


                firstNameTextBox.Text = _games[0].Name;
                //string jsonString = await Task.Run(() => client.DownloadString("https://api-v3.igdb.com/genres/{_games[0].Genres[0]}/?fields=*"));
                firstReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[0].FirstReleaseDate)));
                firstPopularityTextBox.Text = "Популярность: " + string.Concat(_games[0].Popularity);

                secondNameTextBox.Text = _games[1].Name;
                secondReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[1].FirstReleaseDate)));
                secondPopularityTextBox.Text = "Популярность: " + string.Concat(_games[1].Popularity);

                thirdNameTextBox.Text = _games[2].Name;
                thirdReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[2].FirstReleaseDate)));
                thirdPopularityTextBox.Text = "Популярность: " + string.Concat(_games[2].Popularity);

                forthNameTextBox.Text = _games[3].Name;
                forthReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[3].FirstReleaseDate)));
                forthPopularityTextBox.Text = "Популярность: " + string.Concat(_games[3].Popularity);

                fifthNameTextBox.Text = _games[4].Name;
                fifthReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[4].FirstReleaseDate)));
                fifthPopularityTextBox.Text = "Популярность: " + string.Concat(_games[4].Popularity);

                sixthNameTextBox.Text = _games[5].Name;
                sixthReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[5].FirstReleaseDate)));
                sixthPopularityTextBox.Text = "Популярность: " + string.Concat(_games[5].Popularity);

                seventhNameTextBox.Text = _games[6].Name;
                seventhReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[6].FirstReleaseDate)));
                seventhPopularityTextBox.Text = "Популярность: " + string.Concat(_games[6].Popularity);

                eighthNameTextBox.Text = _games[7].Name;
                eighthReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[7].FirstReleaseDate)));
                eighthPopularityTextBox.Text = "Популярность: " + string.Concat(_games[7].Popularity);

                ninthNameTextBox.Text = _games[8].Name;
                ninthReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[8].FirstReleaseDate)));
                ninthPopularityTextBox.Text = "Популярность: " + string.Concat(_games[8].Popularity);

                tenthNameTextBox.Text = _games[8].Name;
                tenthReleaseDateTextBox.Text = "Дата релиза: " + string.Concat(new DateTime((_games[9].FirstReleaseDate)));
                tenthPopularityTextBox.Text = "Популярность: " + string.Concat(_games[9].Popularity);
            }

        }
    }
}
