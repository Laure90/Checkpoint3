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
            var text = Client.DownloadString($"http://localhost:1234/file/C:/Users/Wilder/" + path);
            
        }

        private void DeleteFile_Button_Click(object sender, RoutedEventArgs e)
        {
            var Client = new WebClient();
            var path = PathTextBox.Text;
            var text = Client.DownloadString($"http://localhost:1234/file/C:/Users/Wilder/" + path);
        }

        private void CreateFile_Button_Click(object sender, RoutedEventArgs e)
        {
            var Client = new WebClient();
            var path = PathTextBox.Text;
            var text = Client.DownloadString($"http://localhost:1234/file/C:/Users/Wilder/" + path);
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock.Text = String.Empty;
        }
    }
}
