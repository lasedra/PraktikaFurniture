using Octokit;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;

namespace PraktikaFurniture
{
    public partial class UpdaterWindow : Window
    {
        #region Disallow_closing
        // Prep stuff needed to remove close button on window
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        void ToolWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Code to remove close box from window
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
        #endregion

        Updater updater = new Updater();
        string currVer = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public UpdaterWindow()
        {
            InitializeComponent();
            if (updater.Releases.Result.Any())
                VersionsComboBox.ItemsSource = updater.Releases.Result;
            else
            {
                AvailableVersionsTextBlock.Text = "No any available version(";
                MessageTextBlock.Text = "Stay tuned and follow my GitHub!";
                VersionsComboBox.IsEnabled = false;
                UpdateBttn.IsEnabled = false;
            }
        }

        private void UpdateBttn_Click(object sender, RoutedEventArgs e)
        {
            if (VersionsComboBox.SelectedItem != null)
            {
                var releaseToDownload = ((Release)VersionsComboBox.SelectedItem);
                TagNameTextBox.Text += releaseToDownload.TagName;
                NoteTextBox.Text = releaseToDownload.Body;

                if (releaseToDownload.TagName.Trim() != currVer)
                {
                    ToolWindow_Loaded(sender, e);
                    MessageStackPanel.Visibility = Visibility.Hidden;
                    MessageDockPanel.Visibility = Visibility.Hidden;
                    DownloadStackPanel.Visibility = Visibility.Visible;
                    DownloadProgressBar.Visibility = Visibility.Visible;

                    using (WebClient client = new WebClient())
                    {
                        client.Headers.Add("Authorization", $"Bearer {updater.GitClient.Credentials.GetToken()}");
                        client.Headers.Add("User-Agent", "smth");

                        client.DownloadProgressChanged += (s, e)
                            => DownloadProgressBar.Value = e.ProgressPercentage;
                        client.DownloadFileCompleted += (s, e) =>
                        {
                            MessageBox.Show("The download is done!");
                            this.Close();
                            updater.ApplyNewUpdateCmd();
                        };
                        client.DownloadFileAsync(new Uri(releaseToDownload.Assets[0].BrowserDownloadUrl), $"newUpdate.exe");
                    }
                }
                else { MessageBox.Show($"bruh...", "", MessageBoxButton.OK, MessageBoxImage.Question); }
            }
        }
    }
}
