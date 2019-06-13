using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Dropbox.Api;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace CloudStorage
{
    /// <summary>
    /// Логика взаимодействия для DropBoxWindow.xaml
    /// </summary>
    public partial class DropBoxWindow : Window
    {
        public DropBoxWindow()
        {
            InitializeComponent();
        }

        FolderObject rootFolder = new FolderObject();
        private DropboxClient _dropBoxClient = new DropboxClient("YVYQ5wYdbvAAAAAAAAAAGNpdkTM-sAJxBzSb8VDccFkrU3vA7bQyGpsvBAXnEuoi");

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            UpdateDataGrid();
        }

        private async void ButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            var fileRoutes = _dropBoxClient.Files;

            var fileName = dialog.FileName.Remove(0, 3);
            fileName = "/" + fileName;
            fileName = fileName.Replace('\\', '/');

            byte[] byteArray = File.ReadAllBytes(dialog.FileName);
            MemoryStream stream = new MemoryStream(byteArray);
            await fileRoutes.UploadAsync(fileName, body: stream );

            UpdateDataGrid();
        }

        private async void UpdateDataGrid()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.dropboxapi.com/2/files/list_folder"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", "Bearer YVYQ5wYdbvAAAAAAAAAAGNpdkTM-sAJxBzSb8VDccFkrU3vA7bQyGpsvBAXnEuoi");

                    request.Content = new StringContent("{\"path\": \"\",\"recursive\": true,\"include_media_info\": false,\"include_deleted\": false,\"include_has_explicit_shared_members\": false,\"include_mounted_folders\": true,\"include_non_downloadable_files\": true}", Encoding.UTF8, "application/json");

                    var response = await httpClient.SendAsync(request);

                    var jsonString = await response.Content.ReadAsStringAsync();

                    rootFolder = JsonConvert.DeserializeObject<FolderObject>(jsonString);
                }

                if (rootFolder.HasMore)
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.dropboxapi.com/2/files/list_folder/continue"))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", "Bearer YVYQ5wYdbvAAAAAAAAAAGNpdkTM-sAJxBzSb8VDccFkrU3vA7bQyGpsvBAXnEuoi");

                        request.Content = new StringContent("{\"cursor\": \"" + rootFolder.Cursor + "\"}", Encoding.UTF8, "application/json");

                        var response = await httpClient.SendAsync(request);

                        var jsonString = await response.Content.ReadAsStringAsync();

                        rootFolder = JsonConvert.DeserializeObject<FolderObject>(jsonString);
                    }
                }
            }

            dataGrid.ItemsSource = rootFolder.Entries;
        }
    }
}
