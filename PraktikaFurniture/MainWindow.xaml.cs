using System.Diagnostics;
using System;
using System.Reflection;
using System.Windows;

namespace PraktikaFurniture
{
    public partial class MainWindow : Window
    {
        Updater updater = new Updater();
        string currVer = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainPage());
            VersionTextBlock.Text += currVer;
        }

        private void VersionTextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UpdaterWindow updaterWindow = new UpdaterWindow();
            updaterWindow.ShowDialog();
        }
    }
}
