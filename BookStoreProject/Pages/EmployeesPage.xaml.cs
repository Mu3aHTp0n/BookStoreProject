using BookStoreProject.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using BookStoreProject.Infrastructure;
using BookStoreProject.Infrastructure.Database;
using BookStoreProject.Infrastructure.ViewModels;
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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private PeopleRepository _repository;
        private UserRepository _rep;
        public EmployeesPage()
        {
            InitializeComponent();
            _repository = new PeopleRepository();
            EmployeesGrid.ItemsSource = _repository.GetList();
        }

        private void ToMenu(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }

        private void UpdateGrid()
        {
            EmployeesGrid.ItemsSource = _repository.GetList();
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            AddPeopleWindow addPeopleWindow = new AddPeopleWindow();
            addPeopleWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
                return;
            }

            var item = EmployeesGrid.SelectedItem as PeopleViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
                return;
            }
            _repository.Delete(item.ID);
            UpdateGrid();
        }

        private void F5(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string search = find.Text;
            if (string.IsNullOrEmpty(search))
            {
                EmployeesGrid.ItemsSource = _repository.GetList();
            }
            else
            {
                List<PeopleViewModel> result = _repository.Search(search);
                EmployeesGrid.ItemsSource = result;
            }
        }
    }
}  