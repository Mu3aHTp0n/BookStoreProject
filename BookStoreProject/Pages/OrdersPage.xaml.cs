using BookStoreProject.Infrastructure.Database;
using BookStoreProject.Infrastructure.ViewModels;
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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private OrderingRepository _repository;
        public OrdersPage()
        {
            InitializeComponent();
            // Источник данных для таблицы с заказами
            _repository = new OrderingRepository();
            OrdersGrid.ItemsSource = _repository.GetList();
        }

        // Вернуться на главную страницу
        private void ToMenu(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }

        private void UpdateGrid()
        {
            OrdersGrid.ItemsSource = _repository.GetList();
        }

        private void AddOrderings(object sender, RoutedEventArgs e)
        {
            AddOrderingWindow addOrderingWindow = new AddOrderingWindow();
            addOrderingWindow.Show();
            Window.GetWindow(this).Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (OrdersGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
                return;
            }

            var item = OrdersGrid.SelectedItem as OrderingViewModel;
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
                OrdersGrid.ItemsSource = _repository.GetList();
            }
            else
            {
                List<OrderingViewModel> result = _repository.Search(search);
                OrdersGrid.ItemsSource = result;
            }
        }
    }
}
