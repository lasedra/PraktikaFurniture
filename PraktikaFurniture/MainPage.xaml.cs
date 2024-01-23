using PraktikaFurniture.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PraktikaFurniture
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            EmptyPanel.Visibility = Visibility.Hidden;
            PriceyRadioBttn.IsChecked = true;

            UpdateListView();
        }

        private void UpdateListView()
        {
            var currentProducts = FurnitureContext.dbContext.Products.ToList();

            if (string.IsNullOrWhiteSpace(SearchTextBox.Text) == true)
                SearchTextBox.Text = "";
            else
                currentProducts = currentProducts.Where(u => u.ProductName.ToLower().Contains(SearchTextBox.Text.ToLower()) ||
                                                                            u.ProductCode.ToString().Contains(SearchTextBox.Text.ToLower())).ToList();

            if (CheapRadioBttn.IsChecked == true)
                currentProducts = currentProducts.OrderBy(p => p.Price).ToList();
            else
                currentProducts = currentProducts.OrderByDescending(p => p.Price).ToList();

            ListViewProducts.ItemsSource = currentProducts;

            EmptyPanel.Visibility = ListViewProducts.HasItems ? Visibility.Hidden : Visibility.Visible;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) => UpdateListView();
        private void CheapRadioBttn_Checked(object sender, RoutedEventArgs e) => UpdateListView();
        private void PriceyRadioBttn_Checked(object sender, RoutedEventArgs e) => UpdateListView();

        private void DropFilters_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
            PriceyRadioBttn.IsChecked = true;
            UpdateListView();
        }
    }
}
