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
using System.Windows.Shapes;
using BookStoreProject.Infrastructure;
using BookStoreProject.Infrastructure.Consts;
using BookStoreProject.Infrastructure.Database;
using BookStoreProject.Infrastructure.ViewModels;
using BookStoreProject.Pages;

namespace BookStoreProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private UserRepository _userRepository;
        public AuthWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }
        private void Autentificate(object sender, RoutedEventArgs e)
        {
            string login = loginField.Text;
            string password = passwordField.Password;

            _userRepository.Login(login, password);
            if ((login == "" && password == "") || (login == "") || (password == ""))
            {
                MessageBox.Show("Не все поля заполнены!");
                return;
            }

            var context = new Context { };

            var client = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password && x.RoleId == 1);
            var employee = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password && x.RoleId == 2);
            var admin = context.Users.FirstOrDefault(x => x.Login == login && x.Password == password && x.RoleId == 3);

            if ( client != null )
            {
                Application.Current.Resources[UserInfoConsts.RoleId] = "1";
                Application.Current.Resources[UserInfoConsts.RoleName] = "Клиент";
                Application.Current.Resources[UserInfoConsts.Username] = $" {login}";
            }
            else if ( employee != null )
            {
                Application.Current.Resources[UserInfoConsts.RoleId] = "2";
                Application.Current.Resources[UserInfoConsts.RoleName] = "Сотрудник";
                Application.Current.Resources[UserInfoConsts.Username] = $"{login}";
            }
            else if  ( admin != null )
            {
                Application.Current.Resources[UserInfoConsts.RoleId] = "3";
                Application.Current.Resources[UserInfoConsts.RoleName] = "Админ";
                Application.Current.Resources[UserInfoConsts.Username] = $"{login}";
            } else
            {
                MessageBox.Show("Неверный логин или пароль");
                return;
            }

            // Открытие главного окна
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void GuestEnter(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[UserInfoConsts.RoleId] = 4;
            Application.Current.Resources[UserInfoConsts.RoleName] = "Гость";
            Application.Current.Resources[UserInfoConsts.Username] = "Гость";

            // Открытие главного окна
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
