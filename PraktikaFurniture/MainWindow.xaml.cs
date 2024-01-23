using System.Reflection;
using System.Windows;

namespace PraktikaFurniture
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
            VersionTextBlock.Text += Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void VersionTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (Updater.IsConnectionOk())
            {
                UpdaterWindow updaterWindow = new UpdaterWindow();
                updaterWindow.ShowDialog();
            }
            else { MessageBox.Show("Fix up your internet connection to update the app", "Internet connection fail", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
