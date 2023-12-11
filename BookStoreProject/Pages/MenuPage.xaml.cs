using BookStoreProject.Windows;
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

namespace BookStoreProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        #region Navigation
        private void ToClient(object sender, RoutedEventArgs e)
        {
            ClientsPage examplePage = new ClientsPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = examplePage.Title;
            mainWindow.MainFrame.Navigate(examplePage);

        }

        private void ToEmployees(object sender, RoutedEventArgs e)
        {
            EmployeesPage examplePage = new EmployeesPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = examplePage.Title;
            mainWindow.MainFrame.Navigate(examplePage);
        }

        private void ToOrders(object sender, RoutedEventArgs e)
        {
            OrdersPage examplePage = new OrdersPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = examplePage.Title;
            mainWindow.MainFrame.Navigate(examplePage);
        }

        private void ToProducts(object sender, RoutedEventArgs e)
        {
            ProductsPage examplePage = new ProductsPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = examplePage.Title;
            mainWindow.MainFrame.Navigate(examplePage);
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
        }
        #endregion


    }
}
