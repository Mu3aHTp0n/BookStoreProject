using BookStoreProject.Infrastructure;
using BookStoreProject.Infrastructure.Consts;
using BookStoreProject.Infrastructure.Database;
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
        private UserRepository _userRepository;
        public MenuPage()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
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
        #endregion

        // Выход из сеанса
        private void Exit(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Application.Current.Resources[UserInfoConsts.RoleId] = null;
            Application.Current.Resources[UserInfoConsts.RoleName] = null;
            Application.Current.Resources[UserInfoConsts.Username] = null;
            Window.GetWindow(this).Close();
        }


        // Вывод имени и роли юзера
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            userName.Text = $"Пользователь: {Application.Current.Resources[UserInfoConsts.Username].ToString()}";
            userRole.Text = $"Роль: {Application.Current.Resources[UserInfoConsts.RoleName].ToString()}";
        }
        
    }
}
