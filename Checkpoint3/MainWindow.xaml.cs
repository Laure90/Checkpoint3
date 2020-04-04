using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.Win32;
using System.IO;
using System.ServiceModel;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Checkpoint3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisplayFile_Button_Click(object sender, RoutedEventArgs e)
        {
            var Client = new WebClient();
            var path = PathTextBox.Text;
            var text = Client.DownloadString($"http://localhost:1234/file/" + path);
            var post = JsonConvert.DeserializeObject(text);
            TextBlock.Text = (string)post;
        }

        private void DeleteFile_Button_Click(object sender, RoutedEventArgs e)
        {           
            var path = PathTextBox.Text;
            var url = $"http://localhost:1234/file/" + path;
            using (var client = new WebClient())
            {
                client.UploadString(url, "DELETE", "");
                TextBlock.Text = "File deleted";
            }

            var request = WebRequest.Create(url);
            request.Method = "DELETE";
            var response = (HttpWebResponse)request.GetResponse();
        }

        private void CreateFile_Button_Click(object sender, RoutedEventArgs e)
        {
            var path = PathTextBox.Text;
            var url = $"http://localhost:1234/file/" + path;
            using (var client = new WebClient())
            {
                client.UploadString(url,"PUT", "");
                TextBlock.Text = "File created";
            }

            var request = WebRequest.Create(url);
            request.Method = "PUT";
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            PathTextBox.Text = String.Empty;
            TextBlock.Text = String.Empty;
        }
    }
}
