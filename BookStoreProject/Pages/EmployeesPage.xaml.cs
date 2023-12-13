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

        private void MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (EmployeesGrid.SelectedItem == null)
                return;
            var employeeCard = new AddEmployeeCardWindow(EmployeesGrid.SelectedItem as PeopleViewModel);
            employeeCard.ShowDialog();
            UpdateGrid();
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            //if (EmployeesGrid.SelectedItem == null)
            //    return;
            //var employeeCard = new AddEmployeeCardWindow();
            //employeeCard.ShowDialog();
            //UpdateGrid();
        }

        private void DeleteEmployee(object sender, RoutedEventArgs e)
        {
            //if (EmployeesGrid.SelectedItem == null)
            //    // Bывод модального окна с информацией о том, что ничего не выбрано для удаления
            //    MessageBox.Show("Не выбран сотрудник для удаления");
            //    var item = EmployeesGrid.SelectedItem as PeopleViewModel;

            //if (item == null)
            //    // Вывод модального окна, что не удалось получить данные
            //    MessageBox.Show("Не удалось получить данные");
            //    _repository.Delete(item.ID);
            //UpdateGrid();
        }
    }
}  