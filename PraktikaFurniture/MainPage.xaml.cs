using PraktikaFurniture.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System;
using Xceed.Words.NET;
using System.Diagnostics;
using Xceed.Document.NET;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Octokit;
using System.IO;

namespace PraktikaFurniture
{
    public partial class MainPage : System.Windows.Controls.Page
    {
        public MainPage()
        {
            InitializeComponent();
            EmptyPanel.Visibility = Visibility.Hidden;
            PriceyRadioBttn.IsChecked = true;
            AppDomain.CurrentDomain.UnhandledException += GlobalUnhandledExceptionHandler;

            BitmapImage image = new BitmapImage();
            
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PraktikaFurniture.myphoto.jpeg")) 
            {
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
                testImage.Source = image;
            };

            UpdateListView();
        }

        // CRUD
        private void UpdateListView()
        {
            List<Product> currentProducts = FurnitureContext.dbContext.Products.ToList();

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

        // Exception handler
        private void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            string exception = "Message: " + ex.Message
                             + "\nBase exception: " + ex.GetBaseException()
                             + "\nInner exception: " + ex.InnerException
                             + "\nSource: " + ex.Source
                             + "\nStack trace: " + ex.StackTrace;
            SendMessage(exception, ex);
            MessageBox.Show("The support is already warned via email.\nWe're gonna fix it up soon.", "An unexpected error occured!", MessageBoxButton.OK, MessageBoxImage.Error);
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c taskkill /f /im \"{AppDomain.CurrentDomain.FriendlyName + ".exe"}\" && timeout /t 1 && {Process.GetCurrentProcess().MainModule.FileName}",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                });
            }
            catch (Exception exс) { MessageBox.Show(exс.Message); }
        }
        private void SendMessage(string exceptionMessage, Exception exc)
        {
            string smtpServer = "smtp.mail.ru";
            int smtpPort = 587;
            string smtpUsername = "praktikasuppport@mail.ru";
            string smtpPassword = "Zd?Em?qhXZ?tAy?1?hgC?HU?hWg".Replace("?", "");

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                smtpClient.EnableSsl = true;

                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(smtpUsername);
                    mailMessage.To.Add("praktikasuppport@mail.ru");
                    mailMessage.Subject = $"Ошибка типа: {exc.GetType().FullName}";
                    mailMessage.Body = exceptionMessage;

                    try
                    {
                        smtpClient.Send(mailMessage);
                        MessageBox.Show("Message sent successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Message sending error: {ex.Message}");
                    }
                }
            }
        }

        // Report creating feature
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            try
            {
                if(ListViewProducts.SelectedItems != null && ListViewProducts.SelectedItem != null)
                {
                    using (var templateDoc = DocX.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("PraktikaFurniture.doc-template.docx")))
                    {
                        var rand = new Random(); string docNumber = rand.Next(100, 1000).ToString();
                        ReplaceKeywordWithValue(templateDoc, "[doc-number]", docNumber);
                        ReplaceKeywordWithValue(templateDoc, "[at-date]", DateTime.UtcNow.ToString("f"));

                        int sumQuant = 0;
                        foreach (var item in ListViewProducts.SelectedItems) sumQuant += (item as Product).Quantity;
                        ReplaceKeywordWithValue(templateDoc, "[sum-quantity]", sumQuant.ToString());
                        decimal sumPrice = 0;
                        foreach (var item in ListViewProducts.SelectedItems) sumPrice += (item as Product).Price;
                        ReplaceKeywordWithValue(templateDoc, "[sum-price]", sumPrice.ToString());

                        var reportTable = templateDoc.Tables[1];
                        var rowPattern = reportTable.Rows[1];
                        int counter = 1;
                        foreach (var item in ListViewProducts.SelectedItems)
                        {
                            AddItemToTable(counter, reportTable, rowPattern, item as Product);
                            counter++;
                        }
                        rowPattern.Remove();
                        templateDoc.SaveAs($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Возвратная накладная No_{docNumber}");

                        MessageBox.Show("Документ успешно создан. Вы можете найти его на рабочем столе.", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show($"Ошибка при создании документа: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private static void AddItemToTable(int number, Table table, Row rowPattern, Product product)
        {
            var newItem = table.InsertRow(rowPattern, table.RowCount - 1);

            newItem.ReplaceText(new StringReplaceTextOptions() { SearchValue = "%NUMBER%", NewValue = number.ToString() });
            newItem.ReplaceText(new StringReplaceTextOptions() { SearchValue = "%NAME%", NewValue = product.ProductName });
            newItem.ReplaceText(new StringReplaceTextOptions() { SearchValue = "%CODE%", NewValue = product.ProductCode });
            newItem.ReplaceText(new StringReplaceTextOptions() { SearchValue = "%UNIT%", NewValue = product.Unit });
            newItem.ReplaceText(new StringReplaceTextOptions() { SearchValue = "%QUANTITY%", NewValue = product.Quantity.ToString() });
            newItem.ReplaceText(new StringReplaceTextOptions() { SearchValue = "%PRICE%", NewValue = product.Price.ToString() });
        }
        private void ReplaceKeywordWithValue(DocX document, string keyword, string value)
        {
            foreach (var paragraph in document.Paragraphs)
            {
                if (paragraph.Text.Contains(keyword))
                {
                    paragraph.ReplaceText(keyword, value);
                }
            }
        }
    }
}
